using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CPG.Portal.App.Helper
{
    public class AuthenticationAPI : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter
            {
                Name = "ApplicationId",
                In = "header",
                Type = "string",
                Required = false
            });

        }
    }
    class HeaderParameter : NonBodyParameter
    {
    }
}
