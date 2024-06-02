using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAsync();
        Task<Tenant> GetByIdAsync(Guid id);
        Task<Tenant> PostAsync(Tenant tenant);
        Task<Tenant> PutAsync(Guid id, Tenant tenant);
        Task<Tenant> DeleteAsync(Guid id);
    }
}
