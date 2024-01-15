using MyApp.Dto;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IServices
{
    public interface IPersonalDetailsService
    {
        Task<GetPersonalDetailsDto> GetPersonalDetailByIdAsync(Guid Id);
        Task<IEnumerable<GetPersonalDetailsDto>> GetPersonalDetailByUserIdAsync(Guid userId);
        Task<IEnumerable<GetPersonalDetailsDto>> GetAllPersonalDetailAsync();
        Task<GetPersonalDetailsDto> AddPersonalDetailAsync(AddPersonalDetailsDto detailsDto);
        Task<GetPersonalDetailsDto> UpdatePersonalDetailAsync(Guid Id, UpdatePersonalDetailsDto detailDto);
        Task<bool> DeletePersonalDetailAsync(Guid Id);
    }
}
