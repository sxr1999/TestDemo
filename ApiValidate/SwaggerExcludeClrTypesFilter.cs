using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiValidate
{
    public class SwaggerExcludeClrTypesFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Format == "date-time" &&
                schema.Example is OpenApiDate date)
                schema.Example = new OpenApiString(date.Value.ToString("yyyy-MM-dd"));
        }
    }
}
