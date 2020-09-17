///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Linq;
using System.Threading.Tasks;
using Auth.DataAccess.Contexts;
using Auth.DataAccess.InterfaceContexts;
using Auth.Model;

namespace Auth.DataAccess
{
    /// <summary>
    /// Api Database Access to obtain the API key using authenticated user
    /// This maps the user to each API key which the user is authorized to use
    /// </summary>
    public class ApiDbContext : IApiDbContext
    {
        public readonly DataContextApi _context;

        /// <summary>
        /// Inject context this is how the base implementation should be throught the
        /// application as to abstract the access to Database
        /// </summary>
        /// <param name="context"></param>

        public ApiDbContext(DataContextApi context)
        {
            _context = context;
        }
      

        /// <summary>
        /// Using the user password hash map the API key to the user in question
        /// TODO this needs a maintainer service to assure when passwords are changed or user leave that the mappings are updated
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="apiKeyToSave"></param>
        /// <param name="compareHash"></param>
        /// <returns></returns>
        public async Task<int> SaveChanges(ApiDbItem item)
        {
                return await NowSaveApiKey(item );
        }

        private async Task<int> NowSaveApiKey(ApiDbItem item)
        {
           // byte[] testHash = new Byte ["l;aksjdlfjkl;asdkjfghs".GetHashCode()];
          
          // Test Api  var apiKeyToSave = "5da2f821eee4035db4771edab942a4cc";
            await _context.apiDBItem.AddAsync(item);
           return  await _context.SaveChangesAsync();
        }
        /// <summary>
        /// With Hash To compare to retrieve the relevant Api Key
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="compareHash"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<string> GetApiKey(string apiName,byte[] compareHash)
        {
            var api = _context.apiDBItem.First(x => x.APIName == apiName);
            if(!api.UserHash.SequenceEqual(compareHash)) throw new UnauthorizedAccessException("Access Denied");
            return api.ApiKey;
        }
    }
}