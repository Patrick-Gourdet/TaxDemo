

using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
{
    /// <summary>
    /// The rate is the main object at this point
    /// this will carry oll the information needed
    /// </summary>
    public class rate
    {
    
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
        [Key]
        public string zip { get; set; } 
    }

    /// <summary>
    /// Rates is the wrapper for the rate class so that JSON can serialize and deserialize
    /// </summary>
    public class Rates
    {
        [Key] public Guid id { get; set; }
        public rate rate { get; set; }
    }
    
}