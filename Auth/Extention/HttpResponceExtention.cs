///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Http;

namespace Auth.Extention
{
    /// <summary>
    /// Extenstion method  fir the Http response to return the error messages 
    /// </summary>
    public static class HttpResponceExtention
    {
        public static void AddApplicationError(this HttpResponse res, string message)
        {
            res.Headers.Add("Application-Error", message);
            res.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            res.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
