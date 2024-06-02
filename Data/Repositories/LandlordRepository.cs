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
    public class LandlordRepository:ILandlordRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LandlordRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Landlord>> GetAsync()
        {
            var landlords = _context.Landlords;
            return await Task.FromResult(landlords);
        }

        public async Task<Landlord> GetByIdAsync(Guid id)
        {
            var landlord = _context.Landlords.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(landlord);
        }

        public async Task<Landlord> PostAsync(Landlord landlord)
        {
            _context.Landlords.Add(landlord);
            await _context.SaveChangesAsync();
            return landlord;
        }

        public async Task<Landlord> PutAsync(Guid id, Landlord landlord)
        {
            Landlord landlordToUpdate = await _context.Landlords.FindAsync(id);
            if (landlordToUpdate == null)
                return null;
            landlordToUpdate.UserId=landlord.UserId;    
            await _context.SaveChangesAsync();
            return landlordToUpdate;
        }

        public async Task<Landlord> DeleteAsync(Guid id)
        {
            Landlord landlordToDelete = _context.Landlords.Where(x => x.Id == id).First();
            if (landlordToDelete != null)
            {
                _context.Landlords.Remove(landlordToDelete);
                await _context.SaveChangesAsync();
                return landlordToDelete;
            }
            return null;
        }
    }
}
