using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
{
    /// <summary>
    /// Has not been implemented yet but will hold all the summary elements returned form TaxJar
    /// </summary>
    public class SummayRates
    {
        [Key]
        public Guid SummaryId { get; set; }
        public string country_code { get; set; }
        public string country { get; set; }
        public string region_code { get; set; }
        public string region { get; set; }
        public MinimumRate minimum_rate { get; set; }
        public AverageRate average_rate { get; set; }


        public class MinimumRate
        {
            [Key]
            public Guid minRateId { get; set; }
            public string label { get; set; }
            public double rate { get; set; }
        }
        public class AverageRate
        {
            [Key]
            public Guid AveRateId { get; set; }
            public string label { get; set; }
            public double rate { get; set; }
        }



        


    }
    
}