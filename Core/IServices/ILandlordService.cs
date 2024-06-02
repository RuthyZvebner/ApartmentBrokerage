using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ILandlordService
    {
        Task<IEnumerable<Landlord>> GetAsync();
        Task<Landlord> GetByIdAsync(Guid id);
        Task<Landlord> PostAsync(Landlord landlord);
        Task<Landlord> PutAsync(Guid id, Landlord landlord);
        Task<Landlord> DeleteAsync(Guid id);
    }
}
