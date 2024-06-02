using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        // GET: api/<ApartmentController>
        [HttpGet]
        public async Task<IEnumerable<Apartment>> GetAsync()
        {
            return await _apartmentService.GetAsync();
        }

        // GET api/<ApartmentController>/5
        [HttpGet("{id}")]
        public async Task<Apartment> GetByIdAsync(int id)
        {
            return await _apartmentService.GetByIdAsync(id);
        }

        // POST api/<ApartmentController>
        [HttpPost]
        public async Task<Apartment> PostAsync([FromBody] Apartment apartment)
        {
            return await _apartmentService.PostAsync(apartment);
        }

        // PUT api/<ApartmentController>/5
        [HttpPut("{id}")]
        public async Task<Apartment> PutAsync(int id, [FromBody] Apartment apartment)
        {
            return await _apartmentService.PutAsync(id, apartment);
        }

        // DELETE api/<ApartmentController>/5
        [HttpDelete("{id}")]
        public async Task<Apartment> DeleteAsync(int id)
        {
            return await _apartmentService.DeleteAsync(id);
        }
    }
}
