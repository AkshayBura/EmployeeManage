using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Dto.UserDto;

namespace MyApp.IServices
{
    public interface IAuthService
    {
        Task<(string AccessToken, string RefreshToken)> GenerateJwtToken(string EmailAddress, Guid UserId);
        Task<(string AccessToken, string RefreshToken, User user)> RefreshAccessTokenAsync(string refreshToken);
    }
}
