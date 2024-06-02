using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordController : ControllerBase
    {
        private readonly ILandlordService _landlordService;
        public LandlordController(ILandlordService landlordService)
        {
            _landlordService = landlordService;
        }


        // GET: api/<LandlordController>
        [HttpGet]
        public async Task<IEnumerable<Landlord>> GetAsync()
        {
            return await _landlordService.GetAsync();
        }

        // GET api/<LandlordController>/5
        [HttpGet("{id}")]
        public async Task<Landlord> GetByIdAsync(Guid id)
        {
            return await _landlordService.GetByIdAsync(id);
        }

        // POST api/<LandlordController>
        [HttpPost]
        public async Task<Landlord> PostAsync([FromBody] Landlord landlord)
        {
            return await _landlordService.PostAsync(landlord);
        }

        // PUT api/<LandlordController>/5
        [HttpPut("{id}")]
        public async Task<Landlord> PutAsync(Guid id, [FromBody] Landlord landlord)
        {
            return await _landlordService.PutAsync(id, landlord);
        }

        // DELETE api/<LandlordController>/5
        [HttpDelete("{id}")]
        public async Task<Landlord> DeleteAsync(Guid id)
        {
            return await _landlordService.DeleteAsync(id);
        }
    }
}
