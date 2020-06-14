using System.Collections.Generic;
using System.Threading.Tasks;
using ManageUsersApi.Models;

namespace ManageUsersApi.Data
{
    public interface IUserRepo
    {
        //General
        void CreateAsync<T> (T entity) where T : class;        
        
        Task<User> GetUserByIdAsync(int id);
        Task<Account> GetAccountByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string emailAddress);
        Task<IEnumerable<User>> GetUsersAsync();
         Task<bool> SaveChangesAsync();       
    }
    
}