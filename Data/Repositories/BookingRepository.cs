using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookingRepository:IBookingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAsync()
        {
            var bookingDto = _mapper.Map<IEnumerable<BookingDto>>(_context.Bookings);
            return await Task.FromResult(bookingDto);
        }

        public async Task<BookingDto> GetByIdAsync(int id)
        {
            var bookingDto = _mapper.Map<BookingDto>(_context.Bookings.Where(x => x.Id == id).First());
            return await Task.FromResult(bookingDto);
        }

        public async Task<BookingDto> PostAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            bookingDto.Id = booking.Id;
            return bookingDto;
        }

        public async Task<BookingDto> PutAsync(int id, BookingDto bookingDto)
        {
            Booking booking = _mapper.Map<Booking>(bookingDto);
            Booking bookingToUpdate = await _context.Bookings.FindAsync(id);
            if (bookingToUpdate == null)
                return null;
            bookingToUpdate.ApartmentId = bookingDto.ApartmentId;
            bookingToUpdate.TenantId = bookingDto.TenantId;
            bookingToUpdate.BookingDate = bookingDto.BookingDate;
      
            
            BookingStatus status;
            if (Enum.TryParse<BookingStatus>(bookingDto.Status, out status))
                bookingToUpdate.Status = status;
            else
                bookingToUpdate.Status = BookingStatus.Confirmed;

            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(bookingToUpdate);
        }

        public async Task<Booking> DeleteAsync(int id)
        {
            Booking bookingToDelete = _context.Bookings.Where(x => x.Id == id).First();
            if (bookingToDelete != null)
            {
                _context.Bookings.Remove(bookingToDelete);
                await _context.SaveChangesAsync();
                return bookingToDelete;
            }
            return null;
        }
    }
}
