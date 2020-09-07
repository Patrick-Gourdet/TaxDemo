using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
{
    /// <summary>
    /// Tax Item information for DB storage for possible later
    /// statistical analysis.
    /// </summary>
    public class TaxItemEvent
    {
        [Key]
        public Guid Id { get; set; }
        public string CustmerName { get; set; }
        public decimal Amount { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EndpointUsed { get; set; }
    }
}