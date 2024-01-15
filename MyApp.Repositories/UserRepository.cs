using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.IRepositories;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public async Task<User> GetUserLogin(string emailAddress, string password)
        {
            return await _dbContext.Set<User>()
                                            .FirstOrDefaultAsync(u => u.EmailAddress == emailAddress && u.Password == password);
        }
    }
}
