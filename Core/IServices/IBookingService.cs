using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAsync();
        Task<BookingDto> GetByIdAsync(int id);
        Task<BookingDto> PostAsync(BookingDto bookingDto);
        Task<BookingDto> PutAsync(int id, BookingDto bookingDto);
        Task<Booking> DeleteAsync(int id);
    }
}
