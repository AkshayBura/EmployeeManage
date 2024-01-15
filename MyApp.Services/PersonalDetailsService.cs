using MyApp.Dto;
using MyApp.IRepositories;
using MyApp.IServices;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly IPersonalDetailRepository _repository;
        public PersonalDetailsService(IPersonalDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPersonalDetailsDto> AddPersonalDetailAsync(AddPersonalDetailsDto detailsDto)
        {
            var existingDetails = await _repository.GetByUserIdAsync(detailsDto.UserId);
            if (existingDetails != null)
            {
                var val = "Personal details have been add already for current User";
                throw new ArgumentException(val);
            }

            var detail = await _repository.AddAsync(new PersonalDetails() { Address = detailsDto.Address, UserId = detailsDto.UserId, DOB = detailsDto.DOB, AadhaarNumber = detailsDto.AadhaarNumber, DegreeId = detailsDto.DegreeId, StatusId = detailsDto.StatusId });
            return new GetPersonalDetailsDto(detail.Id, detail.UserId, detail.Address, detail.DOB, detail.AadhaarNumber, detail.DegreeId, detail.StatusId);
        }

        public async Task<bool> DeletePersonalDetailAsync(Guid Id)
        {
            var detail = await _repository.GetByIdAsync(Id);
            if (detail != null)
            {
                return await _repository.DeleteByIdAsync(detail);
            }
            return false; throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetPersonalDetailsDto>> GetAllPersonalDetailAsync()
        {
            var details = await _repository.GetAllAsync();
            var detailsDto = details.Select(detail => new GetPersonalDetailsDto(detail.Id, detail.UserId, detail.Address, detail.DOB, detail.AadhaarNumber, detail.DegreeId, detail.StatusId));
            return detailsDto;
        }

        public async Task<GetPersonalDetailsDto> GetPersonalDetailByIdAsync(Guid Id)
        {
            var detail = await _repository.GetByIdAsync(Id);

            return new GetPersonalDetailsDto(detail.Id, detail.UserId, detail.Address, detail.DOB, detail.AadhaarNumber, detail.DegreeId, detail.StatusId);
        }

        public async Task<IEnumerable<GetPersonalDetailsDto>> GetPersonalDetailByUserIdAsync(Guid userId)
        {
            var details = await _repository.GetByUserIdAsync(userId);

            var detailsDto = details.Select(detail => new GetPersonalDetailsDto(detail.Id, detail.UserId, detail.Address, detail.DOB, detail.AadhaarNumber, detail.DegreeId, detail.StatusId));
            return detailsDto;
        }

        public async Task<GetPersonalDetailsDto> UpdatePersonalDetailAsync(Guid Id, UpdatePersonalDetailsDto detailDto)
        {
            var olddetail = await _repository.GetByIdAsync(Id);
            if (olddetail != null)
            {
                olddetail.Address = detailDto.Address;
                olddetail.DOB = detailDto.DOB;
                olddetail.AadhaarNumber = detailDto.AadhaarNumber;
                olddetail.DegreeId = detailDto.DegreeId;
                olddetail.StatusId = detailDto.StatusId;

                await _repository.UpdateByIdAsync(olddetail);
                return new GetPersonalDetailsDto(olddetail.Id, olddetail.UserId, olddetail.Address, olddetail.DOB, olddetail.AadhaarNumber, olddetail.DegreeId, olddetail.StatusId);
            }
            else
            {
                return null;
            }
        }
    }
}
