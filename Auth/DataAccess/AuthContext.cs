
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet Reinhard
/// Company: Iron Finacials LLC
/// Date: 08/28/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Auth.DataAccess.Contexts;
using Auth.DataAccess.InterfaceContexts;
using Auth.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.DataAccess
{
    public class AuthContext:  IAuthContext
    {
        public readonly DataContext _context;
        public AuthContext(DataContext context)
        {
            _context = context;
        }
        
        public async Task<AuthModel> Login(string username, string password)
        {
            return await LoginCall(username,password);
        }
        private async Task<AuthModel> LoginCall(string username, string password)
        {
            var user = await _context.auth.FirstOrDefaultAsync(res => res.Username == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            Console.WriteLine("IN LOGIN FUNCTION");
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }
            return true;
        }
        /// <summary>
        /// Get User Hash for api key authorization
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<string> GetUserHash(string username, string password)
        {
            return await GetUserHashApi(username, password);
        }
        private async Task<string> GetUserHashApi(string username,string password)
        {
            var user = await _context.auth.FirstOrDefaultAsync(res => res.Username == username);
            if (user == null)
                return "NO ACCESS";
            return user.PasswordHash.ToString();
        }
        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthModel> Register(AuthModel user, string password)
        {
            return await RegisterCall(user,password);
        }
        private async Task<AuthModel> RegisterCall(AuthModel user, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.AutheticationLevel = AuthLevel.AuthLevelOmega;
            await _context.auth.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        /// <summary>
        /// TODO still need proper thought
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthModel> Update(AuthModel userToUpdate,string username, string password)
        {
            var user = await _context.auth.FirstOrDefaultAsync(res => res.Username == username);
            
            if (user == null) return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;
               
            var userUpdate = await _context.auth.FirstOrDefaultAsync(res => res.UserId == userToUpdate.UserId);
            
            if(user.UserId != userToUpdate.UserId && user.AutheticationLevel < AuthLevel.AuthLevelPrime) return null;              
            if(userUpdate.Username != userToUpdate.Username)
            {
                userUpdate.Username = userToUpdate.Username;
            }
            if (userUpdate.Pasword != userToUpdate.Pasword)
            {
                userUpdate.Pasword = userToUpdate.Pasword;
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                userUpdate.PasswordHash = passwordHash;
                userUpdate.PasswordSalt = passwordSalt;   
            }
            if (userUpdate.AutheticationLevel != userToUpdate.AutheticationLevel && userToUpdate.AutheticationLevel <= AuthLevel.AuthLevelPrime)
            {
                userUpdate.AutheticationLevel = userToUpdate.AutheticationLevel;
            }
            _context.Update(userToUpdate);
            return userToUpdate;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        /// <summary>
        /// Find if the user is in Database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<bool> UserExists(string username)
        {
            if (await _context.auth.AnyAsync(res => res.Username == username))
                return true;
            return false;
        }
    }
}
