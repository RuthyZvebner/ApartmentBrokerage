using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetAsync();
        Task<Apartment> GetByIdAsync(int id);
        Task<Apartment> PostAsync(Apartment apartment);
        Task<Apartment> PutAsync(int id, Apartment apartment);
        Task<Apartment> DeleteAsync(int id);
    }
}
