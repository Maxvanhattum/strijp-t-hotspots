using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace Strijp_T_Hotspots.Configurations
{
    public class Config : IValidatable
    {
        public DockerProduction DockerProduction { get; set; }
        public DatabaseConnection DatabaseConnection { get; set; }
        public JWT Jwt { get; set; }

        public void Validate()
        {
            Validator.ValidateObject(DockerProduction, new ValidationContext(DockerProduction), true);
            Validator.ValidateObject(DatabaseConnection, new ValidationContext(DatabaseConnection), true);
            Validator.ValidateObject(Jwt, new ValidationContext(Jwt), true);
        }

    }

    public class DockerProduction
    {
        public string NoSSL { get; set; }
        public string ConfigureCors { get; set; }
        public string CorsUrl { get; set; }
        public string SwaggerPrefix { get; set; }
    }

    public class DatabaseConnection
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
    }

    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
