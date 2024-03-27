//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet Reinhard
/// Company: Iron Finacials LLC
/// Date: 08/28/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using TaxDemo.Model;

namespace TaxDemo.DataAccess.InterfaceContexts
{
    /// <summary>
    /// Interface for Authorization calls
    /// </summary>
    public interface IAuthContext
    {

        /// <summary>
        /// Register User Interface 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        Task<AuthModel> Register(AuthModel username, string password);
        /// <summary>
        /// Login consisting of User Password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AuthModel> Login(string user, string password);
        /// <summary>
        /// User Lookup by Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> UserExists(string username);
        /// <summary>
        /// Gets the user hash to see if the user is allowed to
        /// access api key
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> GetUserHash(string username, string password);

    }
}
