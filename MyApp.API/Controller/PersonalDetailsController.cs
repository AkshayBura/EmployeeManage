using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.IServices;
using MyApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsService _detailService;
        public PersonalDetailsController(IPersonalDetailsService detailService) 
        {
            _detailService = detailService;
        }
        // GET: api/<PersonalDetailsController>
        [HttpGet]
        public async Task<IEnumerable<GetPersonalDetailsDto>> Get()
        {
            return await _detailService.GetAllPersonalDetailAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<GetPersonalDetailsDto> Get(Guid id)
        {
            return await _detailService.GetPersonalDetailByIdAsync(id);
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IEnumerable<GetPersonalDetailsDto>> GetByUserId(Guid userId)
        {
            return await _detailService.GetPersonalDetailByUserIdAsync(userId);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<GetPersonalDetailsDto> Post([FromBody] AddPersonalDetailsDto detailDto)
        {
            return await _detailService.AddPersonalDetailAsync(detailDto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<GetPersonalDetailsDto> Put(Guid id, [FromBody] UpdatePersonalDetailsDto detailDto)
        {
            return await _detailService.UpdatePersonalDetailAsync(id, detailDto);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _detailService.DeletePersonalDetailAsync(id);
        }
    }
}
