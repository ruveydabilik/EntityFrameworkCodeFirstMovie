using EntityFrameworkCodeFirstMovie.DAL.Entities;
using System.Configuration;
using System.Data.Entity;

namespace EntityFrameworkCodeFirstMovie.DAL.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base(GetConnectionString())
        {
        }

        private static string GetConnectionString()
        {
            // connection.config dosyasını yükle
            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "connection.config"
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            // "MovieContext" adındaki connection string'i al
            var connectionString = config.ConnectionStrings.ConnectionStrings["MovieContext"].ConnectionString;

            return connectionString;
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
