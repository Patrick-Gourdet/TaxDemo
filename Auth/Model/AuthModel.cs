///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Auth.Model
{
    /// <summary>
    /// Main authentication model to find authorization levels
    /// to register users or login
    /// </summary>
    public class AuthModel
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string Username { get; set; }
        static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthModel>().HasAlternateKey(b => b.Username);
        }
        public string Pasword { get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AuthLevel AutheticationLevel { get; set;}
    }
}
