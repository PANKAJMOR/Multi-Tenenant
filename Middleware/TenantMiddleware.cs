using Microsoft.EntityFrameworkCore;
using Multi_Tenenant.Models;

namespace Multi_Tenenant.Middleware
{
	public class TenantMiddleware
	{
		private readonly RequestDelegate _next;

		public TenantMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, MultiTenantDbContext dbContext)
		{
			// Bypass for Swagger
			if (context.Request.Path.StartsWithSegments("/swagger"))
			{
				await _next(context);
				return;
			}

			var tenantId = context.Request.Headers["TenantId"].FirstOrDefault();

			if (string.IsNullOrEmpty(tenantId))
			{
				context.Response.StatusCode = StatusCodes.Status400BadRequest;
				await context.Response.WriteAsync("TenantId header is missing.");
				return;
			}

			// ✅ Correct Validation: Check if TenantId exists in the database
			bool tenantExists = await dbContext.Tenants.AnyAsync(t => t.TenantId.ToString() == tenantId);
			if (!tenantExists)
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Invalid TenantId.");
				return;
			}

			// ✅ Store the valid TenantId in HttpContext for later use
			context.Items["TenantId"] = tenantId;
			await _next(context);
		}
	}
}
