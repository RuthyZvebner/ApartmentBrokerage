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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public Task<IEnumerable<Apartment>> GetAsync()
        {
            return _apartmentRepository.GetAsync();
        }

        public Task<Apartment> GetByIdAsync(int id)
        {
            return _apartmentRepository.GetByIdAsync(id);
        }

        public Task<Apartment> PostAsync(Apartment apartment)
        {
            return _apartmentRepository.PostAsync(apartment);
        }

        public Task<Apartment> PutAsync(int id, Apartment apartment)
        {
            return _apartmentRepository.PutAsync(id, apartment);
        }
        public Task<Apartment> DeleteAsync(int id)
        {
            return _apartmentRepository.DeleteAsync(id);
        }
    }
}
