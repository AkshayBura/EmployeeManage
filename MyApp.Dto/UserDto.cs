using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Dto
{
    public class UserDto
    {
        public record CreateUserDto(
        [Required(ErrorMessage = "FirstName is required")] string FirstName,
        string LastName,
        [Required(ErrorMessage = "Email is required")] string EmailAddress,
        [Required(ErrorMessage = "Mobile Number is required")] long MobileNumber,
        [Required(ErrorMessage = "Password is required")] string Password
        );

        public record GetUserDto(
            Guid UserId,
            string FirstName,
            string LastName,
            string EmailAddress,
            long MobileNumber
            );

        public record UpdateUserDto(
            [Required(ErrorMessage = "FirstName is required")] string FirstName,
            string LastName,
            [Required(ErrorMessage = "Email is required")] string EmailAddress,
            [Required(ErrorMessage = "Mobile Number is required")] long MobileNumber,
            [Required(ErrorMessage = "Password is required")] string Password
            );
    }
}
