///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;

namespace TaxDemo.Model
{
    /// <summary>
    /// This is the data object responsible for transporting and storing the
    /// calculated results from the api calls
    /// </summary>
    public class TaxCalculationItemEvent
    {
        [Key]
        public Guid CalcId { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent { get; set; }
        public decimal CalculatedAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid TaxId { get; set; }
    }
}