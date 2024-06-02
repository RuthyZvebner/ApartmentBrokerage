using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }


        // GET: api/<TenantController>
        [HttpGet]
        public async Task<IEnumerable<Tenant>> GetAsync()
        {
            return await _tenantService.GetAsync();
        }

        // GET api/<TenantController>/5
        [HttpGet("{id}")]
        public async Task<Tenant> GetByIdAsync(Guid id)
        {
            return await _tenantService.GetByIdAsync(id);
        }

        // POST api/<TenantController>
        [HttpPost]
        public async Task<Tenant>DeleteAsync([FromBody] Tenant tenant)
        {
            return await _tenantService.PostAsync(tenant);
        }

        // PUT api/<TenantController>/5
        [HttpPut("{id}")]
        public async Task<Tenant> PutAsync(Guid id, [FromBody] Tenant tenant)
        {
            return await _tenantService.PutAsync(id, tenant);
        }

        // DELETE api/<TenantController>/5
        [HttpDelete("{id}")]
        public async Task<Tenant> DeleteAsync(Guid id)
        {
            return await _tenantService.DeleteAsync(id);  
        }
    }
}
