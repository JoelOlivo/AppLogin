using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;
using AppLogin.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AppLogin.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //Inyecta dbcontext (dbset)
        private readonly AppLoginDbContext _context;

        public UserRepository(AppLoginDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Update(User user)
        {
            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(User user)
        {
            _context.Remove(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<User> GetById(UserId id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmail(UserEmail email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
