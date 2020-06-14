 using System;
using System.ComponentModel.DataAnnotations;

namespace ManageUsersApi.Models
{
public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string EmailAdress { get; set; }
        [Required]
        public double MonthlySalary { get; set; }
        [Required]
        public double MonthlyExpenes { get; set; }
        public DateTime CreatedDate { get; set; }   = DateTime.Now;

    }
}