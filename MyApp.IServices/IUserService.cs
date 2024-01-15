using MyApp.Dto;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Dto.UserDto;

namespace MyApp.IServices
{
    public interface IUserService
    {
        Task<GetUserDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<GetUserDto>> GetAllUserAsync();
        Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
        Task<GetUserDto> UpdateUserByIdAsync(Guid Id, UpdateUserDto userDto);
        Task<bool> DeleteUserByIdAsync(Guid id);
        Task<User> GetUserLoginAsync(LoginDto loginDto);
    }
}
