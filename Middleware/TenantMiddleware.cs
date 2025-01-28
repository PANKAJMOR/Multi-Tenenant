namespace Multi_Tenenant.Middleware
{
	public class TenantMiddleware
	{
		private readonly RequestDelegate _next;

		public TenantMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			var tenantId = context.Request.Headers["TenantId"].FirstOrDefault();
			if (string.IsNullOrEmpty(tenantId))
			{
				context.Response.StatusCode = StatusCodes.Status400BadRequest;
				await context.Response.WriteAsync("TenantId header is missing.");
				return;
			}
			context.Items["TenantId"] = tenantId;
			await _next(context);
		}
	}



}
