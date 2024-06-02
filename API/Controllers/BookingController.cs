using Core.Dtos;
using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;   
        }


        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IEnumerable<BookingDto>> GetAsync()
        {
            return await _bookingService.GetAsync();
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<BookingDto> GetByIdAsync(int id)
        {
            return await _bookingService.GetByIdAsync(id);
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<BookingDto> PostAsync([FromBody] BookingDto bookingDto)
        {
            return await _bookingService.PostAsync(bookingDto);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<BookingDto> PutAsync(int id, [FromBody] BookingDto bookingDto)
        {
            return await _bookingService.PutAsync(id, bookingDto);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<Booking> DeleteAsync(int id)
        {
            return await _bookingService.DeleteAsync(id);
        }
    }
}
