 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ManageUsersApi.Util;

namespace ManageUsersApi.Dtos
{
public class UserCreateDto
    {
        [Required]
        [StringLength(250, ErrorMessage="Name string length should be less then 250")]
        public string Name { get; set; }
        [Required] 
        [EmailAddress(ErrorMessage="Not a valid e-mail address")]         
        public string EmailAdress { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage="Monthly salary should be greater then zero")] 
        public double MonthlySalary { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage="Monthly expenes should be greater then zero")]  
        public double MonthlyExpenes { get; set; }      
    }
}