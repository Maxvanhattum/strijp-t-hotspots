using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Strijp_T_Hotspots.Configurations
{
    public class SwaggerFilter : IDocumentFilter
    {
        private readonly string _swaggerDocHost;


        public SwaggerFilter(string Url)

        {

            _swaggerDocHost = Url;

        }
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers.Add(new OpenApiServer { Url = _swaggerDocHost });
        }
    }
}
