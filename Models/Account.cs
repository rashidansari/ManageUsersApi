using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageUsersApi.Models
{
 public class Account
    {
        [Key, ForeignKey("User")]  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]     
        [Required]
        public int UserId { get; set; }
        [MaxLength(250)]

        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}