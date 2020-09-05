//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet 
/// Company: Iron Finacials LLC
/// Date: 08/28/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.DataAccess;
using Auth.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Controllers
{
    /// <summary>
    /// Authentication API Access for Gateway authentication method
    /// </summary>
    public class AuthController : Controller
    {
        // GET: AuthController
        private readonly IAuthContext _repo;
        private readonly IApiDbContext _repoApi;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;
        /// <summary>
        /// Constructor using IoC allowing the controller access to
        /// logging the repo tied to the Auth methods 
        /// and configuration methods from start
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        public AuthController(IAuthContext repo,IApiDbContext apiDbContext,IConfiguration config, ILogger<AuthController> logger)
        {
            _repo = repo;
            _config = config;
            _logger = logger;
            _repoApi = apiDbContext;
        }
        /// <summary>
        /// Registration method
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRegisterDto newUser)
        {

            if(await _repo.UserExists(newUser.Username)) return BadRequest("Error No Registration Permitted");
            var create = new AuthModel
            {
                Username = newUser.Username
            };
            var res = await _repo.Register(create,newUser.Pasword);
            return StatusCode(201);
        }
        /// <summary>
        /// To see if a user exists before attempting authorization process
        /// providing a layer of protection against brute force attacks
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("userexists")]
        public async Task<bool> UserExists(AuthRegisterDto user)
        {
           return (await _repo.UserExists(user.Username));
        }
        /// <summary>
        /// Standard login method using jwt tokens
        ///  [HttpPost("login")]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // GET: AuthController/Details/5
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRegisterDto user)
        {
            #region user authentication is being checked here

            try
            {
                // throw new Exception("Computer has Issues");
                if (user == null)
                    Debug.WriteLine("This object is NUll" + user);
                //Check if user exsists and if the password in correct
                var userInfo = await _repo.Login(user.Username.ToLower(), user.Pasword);
                
                if (userInfo == null)
                    return Unauthorized();

                #endregion

                #region Here the Token is created for the given session

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                    new Claim(ClaimTypes.Name, userInfo.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tockenDescripter = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };
                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tockenDescripter);
                return Ok(new { token = tokenHandler.WriteToken(token) });
            }
            catch (Exception e)
            {
                throw e;
            }

            #endregion
        }

        /// <summary>
        /// Test Hash 8743b52063cd84097a65d1633f5c74f5
        ///  [HttpPost("new-apikey/{apikey}/{apiName}/{user}/{password}")]
        /// A hash created to test string to byte conversion
        /// Add API Key To the api keys for a specific user
        /// eliminating the authorization as the assigning of api keys
        /// will be the authorization
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="apiName"></param>
        /// <param name="authorized"></param>
        /// <returns></returns>
        [HttpPost("new-apikey/{apikey}/{apiName}/{user}/{password}")]
        public async Task<ActionResult> SaveApi(string apikey="",string apiName="",string user= "",string password="")
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes
                (
                    _repo.GetUserHash(user, password).Result
                );

                await _repoApi.SaveChanges(new ApiDbItem()
                {
                    ApiId = Guid.NewGuid(),
                    ApiKey = apikey,
                    APIName = apiName,
                    UserHash = hash
                });
                return Ok(201);
            }
            catch 
            {
                return BadRequest(500);
            }
            

        }
    }
}
