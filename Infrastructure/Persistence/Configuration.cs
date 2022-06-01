using System.IO;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                //ConfigurationManager configurationManager = new ConfigurationManager();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                //configurationManager.AddJsonFile("appsettings.json");
                //return configurationManager.GetConnectionString("MicrosoftSqlServer");
                return "Server=sql.bsite.net\\MSSQL2016;Database=ecommerceproject_db2;User ID=ecommerceproject_db2;Password=Ecommerce.78645;Trusted_Connection=False;TrustServerCertificate=True";
            }
        }
    }
}
