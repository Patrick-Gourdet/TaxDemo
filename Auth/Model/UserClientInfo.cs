using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Model
{
    public class UserClientInfo
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string Username { get; set; }
        // static void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Users>()
        //         .HasAlternateKey(b => b.Username)
        //         .HasName("PrimaryKey_Username");
        // }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmailList> Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set;} 
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public string Intersts { get; set; }
        public ICollection<Dependents> Dependents { get; set; }
        public ICollection<ToDo> Todo { get; set; }
        public ICollection<Calendar> Calendar { get; set; }
        public bool IsDeleted { get; set; }
    }
}
