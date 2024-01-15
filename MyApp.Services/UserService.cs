using MyApp.Dto;
using MyApp.IRepositories;
using MyApp.IServices;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Dto.UserDto;

namespace MyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var user = await _userRepository.AddAsync(new User() { FirstName = userDto.FirstName, LastName = userDto.LastName, EmailAddress = userDto.EmailAddress, MobileNumber = userDto.MobileNumber, Password = userDto.Password });

            return new GetUserDto(user.UserId, user.FirstName, user.LastName, user.EmailAddress, user.MobileNumber);
        }

        public async Task<bool> DeleteUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                return await _userRepository.DeleteByIdAsync(user);
            }
            return false; throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(user => new GetUserDto(user.UserId, user.FirstName, user.LastName, user.EmailAddress, user.MobileNumber));
            return usersDto;
        }

        public async Task<GetUserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return new GetUserDto(user.UserId, user.FirstName, user.LastName, user.EmailAddress, user.MobileNumber);
        }

        public async Task<User> GetUserLoginAsync(LoginDto loginDto)
        {
            return await _userRepository.GetUserLogin(loginDto.EmailAddress, loginDto.Password);
        }

        public async Task<GetUserDto> UpdateUserByIdAsync(Guid Id, UpdateUserDto userDto)
        {
            var olduser = await _userRepository.GetByIdAsync(Id);
            if (olduser != null)
            {
                olduser.FirstName = userDto.FirstName;
                olduser.LastName = userDto.LastName;
                olduser.EmailAddress = userDto.EmailAddress;
                olduser.MobileNumber = userDto.MobileNumber;

                await _userRepository.UpdateByIdAsync(olduser);
                return new GetUserDto(olduser.UserId, olduser.FirstName, olduser.LastName, olduser.EmailAddress, olduser.MobileNumber);
            }
            else
            {
                return null;
            }
        }
    }
}
