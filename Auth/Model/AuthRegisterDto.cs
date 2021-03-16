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

namespace Auth.Model
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
        public string SSN { get; set;}
        public DateTime DOB { get; set; }
        

    }

    public class Addresses
    {
        public string Street { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }

}
