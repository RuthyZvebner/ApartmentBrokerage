using AutoMapper;
using Core.Entities;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ApartmentRepository:IApartmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ApartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Apartment>> GetAsync()
        {
            var apartments = _context.Apartments;
            return await Task.FromResult(apartments);
        }

        public async Task<Apartment> GetByIdAsync(int id)
        {
            var apartment = _context.Apartments.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(apartment);
        }

        public async Task<Apartment> PostAsync(Apartment apartment)
        {            
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task<Apartment> PutAsync(int id, Apartment apartment)
        {
            Apartment apartmentToUpdate = await _context.Apartments.FindAsync(id);
            if (apartmentToUpdate == null)
                return null;
            apartmentToUpdate.Description = apartment.Description;
            apartmentToUpdate.Price = apartment.Price;
            apartmentToUpdate.Size= apartment.Size;
            apartmentToUpdate.Bedrooms = apartment.Bedrooms;
            apartmentToUpdate.Address = apartment.Address;
            apartmentToUpdate.Name = apartment.Name;
            apartmentToUpdate.IsAvailable = apartment.IsAvailable;
            await _context.SaveChangesAsync();
            return apartmentToUpdate;
        }

        public async Task<Apartment> DeleteAsync(int id)
        {
            Apartment apartmentToDelete = _context.Apartments.Where(x => x.Id == id).First();
            if (apartmentToDelete != null)
            {
                _context.Apartments.Remove(apartmentToDelete);
                await _context.SaveChangesAsync();
                return apartmentToDelete;
            }
            return null;
        }
    }
}
