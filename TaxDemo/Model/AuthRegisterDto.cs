///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxDemo.Model
{
    /// <summary>
    /// Smaller dto as to not expose the hash fields to a user
    /// </summary>
    public class AuthRegisterDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthModel>().HasAlternateKey(b => b.Username);
        }
        public string Pasword { get; set;}
        public AuthLevel AutheticationLevel { get; set;}
    }
}
