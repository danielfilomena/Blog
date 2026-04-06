using Blog.Data.Context;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly BlogContext _context;

        public UserRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(string userName)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<bool> SaveUser(User user)
        {

            var success = false;

            _context.User.Add(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                success = true;

            return success;

        }
    }
}
