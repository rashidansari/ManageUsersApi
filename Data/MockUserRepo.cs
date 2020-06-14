using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManageUsersApi.Models;

namespace ManageUsersApi.Data
{
    public class MockUserRepo   : IUserRepo
    {         
        public void Create(User user)
        {
            // do nothing
        }

        public void CreateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetUserByIdAsync<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
             throw new NotImplementedException();
            // return new List<User>() { 
            //     new User() {Id=1, EmailAdress="Rashidiipd@gmail.com", Name="Rashid", CreatedDate = DateTime.Now },
            //     new User() {Id=2, EmailAdress="Rashidiipd@gmail.com", Name="Rashid2", CreatedDate = DateTime.Now },
            //     new User() {Id=3, EmailAdress="Rashidiipd@gmail.com", Name="Rashid3", CreatedDate = DateTime.Now }
            // };
        }       

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
    
}