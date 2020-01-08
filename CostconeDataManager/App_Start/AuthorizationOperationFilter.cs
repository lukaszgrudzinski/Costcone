using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace CostconeDataManager.App_Start
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "Access Token",
                required = false,
                type = "string"
            });
            if (operation.operationId == "Location_Get")  // controller and action name
            {
                operation.
                consumes = new List<string>
                    {
                        "application/json"
                    };
            }
        }
    }
}