﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
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