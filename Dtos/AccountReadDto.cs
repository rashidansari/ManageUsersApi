 using System;
using System.ComponentModel.DataAnnotations;

namespace ManageUsersApi.Dtos
{
public class AccountReadDto
    {        
        public int UserId { get; set; }
        public string AccountType { get; set; }  
     
    }
}