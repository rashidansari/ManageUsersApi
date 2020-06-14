 using System;
using System.ComponentModel.DataAnnotations;

namespace ManageUsersApi.Dtos
{
public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
                
        public string EmailAdress { get; set; }
       
        public double MonthlySalary { get; set; }
       
        public double MonthlyExpenes { get; set; }       

    }
}