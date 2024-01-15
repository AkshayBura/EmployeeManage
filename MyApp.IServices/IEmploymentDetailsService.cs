using MyApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IServices
{
    public interface IEmploymentDetailsService
    {
        Task<GetEmploymentDetailsDto> GetEmploymentDetailByIdAsync(Guid Id);
        Task<IEnumerable<GetEmploymentDetailsDto>> GetEmploymentDetailByUserIdAsync(Guid userId);
        Task<IEnumerable<GetEmploymentDetailsDto>> GetAllEmploymentDetailAsync();
        Task<GetEmploymentDetailsDto> AddEmploymentDetailAsync(AddEmploymentDetailsDto detailsDto);
        Task<GetEmploymentDetailsDto> UpdateEmploymentDetailAsync(Guid Id, UpdateEmploymentDetailsDto detailDto);
        Task<bool> DeleteEmploymentDetailAsync(Guid Id);
    }
}
