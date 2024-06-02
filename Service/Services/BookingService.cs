using Core.Dtos;
using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<IEnumerable<BookingDto>> GetAsync()
        {
            return _bookingRepository.GetAsync();
        }

        public Task<BookingDto> GetByIdAsync(int id)
        {
            return _bookingRepository.GetByIdAsync(id);
        }

        public Task<BookingDto> PostAsync(BookingDto bookingDto)
        {
            return _bookingRepository.PostAsync(bookingDto);
        }

        public Task<BookingDto> PutAsync(int id, BookingDto bookingDto)
        {
            return _bookingRepository.PutAsync(id, bookingDto);
        }
        public Task<Booking> DeleteAsync(int id)
        {
            return _bookingRepository.DeleteAsync(id);
        }
    }
}
