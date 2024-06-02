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
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public Task<IEnumerable<Tenant>> GetAsync()
        {
            return _tenantRepository.GetAsync();
        }

        public Task<Tenant> GetByIdAsync(Guid id)
        {
            return _tenantRepository.GetByIdAsync(id);
        }

        public Task<Tenant> PostAsync(Tenant tenant)
        {
            return _tenantRepository.PostAsync(tenant);
        }

        public Task<Tenant> PutAsync(Guid id, Tenant tenant)
        {
            return _tenantRepository.PutAsync(id, tenant);
        }
        public Task<Tenant> DeleteAsync(Guid id)
        {
            return _tenantRepository.DeleteAsync(id);
        }
    }
}
