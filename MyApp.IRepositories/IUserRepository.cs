using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserLogin(string emailAddress, string password);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
