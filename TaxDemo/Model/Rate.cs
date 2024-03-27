///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaxDemo.Model
{
    
    /// <summary>
    /// Rates is the wrapper for the rate class so that JSON can serialize and deserialize
    /// </summary>
    public class RatesRate
    {
        [Key]
        public Guid id { get; set; }
         [ForeignKey("SubRateId")]
        public SubRate rate { get; set; }
    }
    /// <summary>
    /// The rate is the main object at this point
    /// this will carry oll the information needed
    /// </summary>
    
    public class SubRate
    {
       
        public Guid id { get; set; }

        [Key]
        public Guid rate_id { get; set; }
        public string city { get; set; } 
        public string city_rate { get; set; } 
        public string combined_district_rate { get; set; } 
        public string combined_rate { get; set; } 
        public string country { get; set; } 
        public string country_rate { get; set; } 
        public string county { get; set; } 
        public string county_rate { get; set; } 
        public bool freight_taxable { get; set; } 
        public string state { get; set; } 
        public string state_rate { get; set; }
        public string zip { get; set; } 
    }

    
}