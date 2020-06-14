using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageUsersApi.Data;
using ManageUsersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageUsersApi.Data
{
    public class PGUserRepo : IUserRepo
    {
        private readonly ManageUsersContext _context;

        public PGUserRepo(ManageUsersContext context)
        {
            _context = context;
        }      
        public async void CreateAsync<T>(T entity) where T : class
        {
             await _context.AddAsync(entity);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
             return await _context.Accounts.FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async  Task<User> GetUserByEmailAsync(string emailAddress)
        {
           return await _context.Users.FirstOrDefaultAsync(p => p.EmailAdress == emailAddress);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
             return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
           return await _context.Users.ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync() >= 0);
        }
    }
}