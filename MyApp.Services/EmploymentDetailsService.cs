using MyApp.Dto;
using MyApp.IRepositories;
using MyApp.IServices;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class EmploymentDetailsService : IEmploymentDetailsService
    {
        private readonly IEmploymentDetailsRepository _repository;

        public EmploymentDetailsService(IEmploymentDetailsRepository repository) 
        { 
            _repository = repository;
        }
        public async Task<GetEmploymentDetailsDto> AddEmploymentDetailAsync(AddEmploymentDetailsDto detailsDto)
        {
            var detail = await _repository.AddAsync(new EmploymentDetails() { CompanyName = detailsDto.CompanyName, JobRole = detailsDto.JobRole, DomainId = detailsDto.DomainId, SkillsDeveloped = detailsDto.SkillsDeveloped, JoiningDate = detailsDto.JoiningDate, TerminationDate = detailsDto.TerminationDate, UserId = detailsDto.UserId });

            return new GetEmploymentDetailsDto(detail.Id, detail.CompanyName, detail.JobRole, detail.DomainId, detail.SkillsDeveloped, detail.JoiningDate, detail.TerminationDate, detail.UserId);

        }

        public async Task<bool> DeleteEmploymentDetailAsync(Guid Id)
        {
            var detail = await _repository.GetByIdAsync(Id);
            if (detail != null)
            {
                return await _repository.DeleteByIdAsync(detail);
            }
            return false; throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetEmploymentDetailsDto>> GetAllEmploymentDetailAsync()
        {
            var details = await _repository.GetAllAsync();
            var detailsDto = details.Select(detail => new GetEmploymentDetailsDto(detail.Id, detail.CompanyName, detail.JobRole, detail.DomainId, detail.SkillsDeveloped, detail.JoiningDate, detail.TerminationDate, detail.UserId));
            return detailsDto;
        }

        public async Task<GetEmploymentDetailsDto> GetEmploymentDetailByIdAsync(Guid Id)
        {
            var detail = await _repository.GetByIdAsync(Id);

            return new GetEmploymentDetailsDto(detail.Id, detail.CompanyName, detail.JobRole, detail.DomainId, detail.SkillsDeveloped, detail.JoiningDate, detail.TerminationDate, detail.UserId);
        }

        public async Task<IEnumerable<GetEmploymentDetailsDto>> GetEmploymentDetailByUserIdAsync(Guid userId)
        {
            var details = await _repository.GetByUserIdAsync(userId);

            var detailsDto = details.Select(detail => new GetEmploymentDetailsDto(detail.Id, detail.CompanyName, detail.JobRole, detail.DomainId, detail.SkillsDeveloped, detail.JoiningDate, detail.TerminationDate, detail.UserId));
            return detailsDto;
        }

        public async Task<GetEmploymentDetailsDto> UpdateEmploymentDetailAsync(Guid Id, UpdateEmploymentDetailsDto detailDto)
        {
            var olddetail = await _repository.GetByIdAsync(Id);
            if (olddetail != null)
            {
                olddetail.CompanyName = detailDto.CompanyName;
                olddetail.JobRole = detailDto.JobRole;
                olddetail.DomainId = detailDto.DomainId;
                olddetail.SkillsDeveloped = detailDto.SkillsDeveloped;
                olddetail.JoiningDate = detailDto.JoiningDate;
                olddetail.TerminationDate = detailDto.TerminationDate;
                olddetail.UserId = detailDto.UserId;

                await _repository.UpdateByIdAsync(olddetail);
                return new GetEmploymentDetailsDto(olddetail.Id, olddetail.CompanyName, olddetail.JobRole, olddetail.DomainId, olddetail.SkillsDeveloped, olddetail.JoiningDate, olddetail.TerminationDate, olddetail.UserId);
            }
            else
            {
                return null;
            }
        }
    }
}
