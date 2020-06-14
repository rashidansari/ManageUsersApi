 using System;
using System.ComponentModel.DataAnnotations;

namespace ManageUsersApi.Dtos
{
public class AccountCreateDto
    {
        
        [Required]
        public int UserId { get; set; }
        [StringLength(250)]
        public string AccountType { get; set; }        
    }
}