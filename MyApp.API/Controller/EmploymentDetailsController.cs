using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentDetailsController : ControllerBase
    {
        private readonly IEmploymentDetailsService _employmentDetailsService;
        public EmploymentDetailsController(IEmploymentDetailsService employmentDetailsService) 
        { 
            _employmentDetailsService = employmentDetailsService;
        }
        // GET: api/<EmploymentDetailsController>
        [HttpGet]
        public async Task<IEnumerable<GetEmploymentDetailsDto>> Get()
        {
            return await _employmentDetailsService.GetAllEmploymentDetailAsync();
        }

        // GET api/<EmploymentDetailsController>/5
        [HttpGet("{id}")]
        public async Task<GetEmploymentDetailsDto> Get(Guid id)
        {
            return await _employmentDetailsService.GetEmploymentDetailByIdAsync(id);
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IEnumerable<GetEmploymentDetailsDto>> GetByUserId(Guid userId)
        {
            return await _employmentDetailsService.GetEmploymentDetailByUserIdAsync(userId);
        }

        // POST api/<EmploymentDetailsController>
        [HttpPost]
        public async Task<GetEmploymentDetailsDto> Post([FromBody] AddEmploymentDetailsDto detailDto)
        {
            return await _employmentDetailsService.AddEmploymentDetailAsync(detailDto);
        }

        // PUT api/<EmploymentDetailsController>/5
        [HttpPut("{id}")]
        public async Task<GetEmploymentDetailsDto> Put(Guid id, [FromBody] UpdateEmploymentDetailsDto detailDto)
        {
            return await _employmentDetailsService.UpdateEmploymentDetailAsync(id, detailDto);

        }

        // DELETE api/<EmploymentDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _employmentDetailsService.DeleteEmploymentDetailAsync(id);

        }
    }
}
