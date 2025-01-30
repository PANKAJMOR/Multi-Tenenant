using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi_Tenenant.Models;

namespace Multi_Tenenant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly MultiTenantDbContext _context;

        public TenantsController(MultiTenantDbContext context)
        {
            _context = context;
        }



		[HttpGet]
		public async Task<ActionResult<IEnumerable<Tenant>>> GetTenants()
		{
			// ✅ Get TenantId from Middleware (HttpContext.Items)
			var tenantId = HttpContext.Items["TenantId"]?.ToString();
			if (string.IsNullOrEmpty(tenantId))
			{
				return BadRequest("TenantId header is missing.");
			}

			// ✅ Fetch only tenants that match the TenantId
			var tenant = await _context.Tenants
				.Where(t => t.TenantId.ToString() == tenantId)
				.ToListAsync();

			if (tenant == null || tenant.Count == 0)
			{
				return NotFound("No tenants found for this TenantId.");
			}

			return Ok(tenant);
		}


		// GET: api/Tenants/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Tenant>> GetTenant(int id)
		{
			var tenant = await _context.Tenants.FindAsync(id);

			if (tenant == null)
			{
				return NotFound();
			}

			return tenant;
		}

		// PUT: api/Tenants/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTenant(int id, Tenant tenant)
		{
			if (id != tenant.TenantId)
			{
				return BadRequest();
			}

			_context.Entry(tenant).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TenantExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Tenants
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Tenant>> PostTenant(Tenant tenant)
		{
			_context.Tenants.Add(tenant);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetTenant", new { id = tenant.TenantId }, tenant);
		}

		// DELETE: api/Tenants/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTenant(int id)
		{
			var tenant = await _context.Tenants.FindAsync(id);
			if (tenant == null)
			{
				return NotFound();
			}

			_context.Tenants.Remove(tenant);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TenantExists(int id)
		{
			return _context.Tenants.Any(e => e.TenantId == id);
		}
	}
}
