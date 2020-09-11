///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Threading.Tasks;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Serves as the extenstion for the memento pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITax<T>
    {
        Task GetTaxInfo(T action);
    }
}