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
    public class TenantRepository:ITenantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TenantRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tenant>> GetAsync()
        {
            var tenants = _context.Tenants;
            return await Task.FromResult(tenants);
        }

        public async Task<Tenant> GetByIdAsync(Guid id)
        {
            var tenant = _context.Tenants.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(tenant);
        }

        public async Task<Tenant> PostAsync(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }

        public async Task<Tenant> PutAsync(Guid id, Tenant tenant)
        {
            Tenant tenantToUpdate = await _context.Tenants.FindAsync(id);
            if (tenantToUpdate == null)
                return null;
            tenantToUpdate.UserId = tenant.UserId;
            await _context.SaveChangesAsync();
            return tenantToUpdate;
        }

        public async Task<Tenant> DeleteAsync(Guid id)
        {
            Tenant tenantToDelete = _context.Tenants.Where(x => x.Id == id).First();
            if (tenantToDelete != null)
            {
                _context.Tenants.Remove(tenantToDelete);
                await _context.SaveChangesAsync();
                return tenantToDelete;
            }
            return null;
        }
    }
}
