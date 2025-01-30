using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Multi_Tenenant.Middleware
{
	public class TenantHeaderOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			if (operation.Parameters == null)
				operation.Parameters = new List<OpenApiParameter>();

			operation.Parameters.Add(new OpenApiParameter
			{
				Name = "TenantId",
				In = ParameterLocation.Header,
				Required = true,
				Schema = new OpenApiSchema { Type = "string" }
			});
		}
	}
}
