using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _landlordRepository;

        public LandlordService(ILandlordRepository landlordRepository)
        {
            _landlordRepository = landlordRepository;
        }

        public Task<IEnumerable<Landlord>> GetAsync()
        {
            return _landlordRepository.GetAsync();
        }

        public Task<Landlord> GetByIdAsync(Guid id)
        {
            return _landlordRepository.GetByIdAsync(id);
        }

        public Task<Landlord> PostAsync(Landlord landlord)
        {
            return _landlordRepository.PostAsync(landlord);
        }

        public Task<Landlord> PutAsync(Guid id, Landlord landlord)
        {
            throw new NotImplementedException();
        }
        public Task<Landlord> DeleteAsync(Guid id)
        {
            return _landlordRepository.DeleteAsync(id);
        }
    }
}
