///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
{
    /// <summary>
    /// Base APi DB element for data interactions
    /// </summary>
    public class ApiDbItem
    {
        [Key]
        public Guid ApiId { get; set;}
        public string APIName { get; set;}
        public string ApiKey { get; set; }
        public Byte[] UserHash { get; set;}

    }
}