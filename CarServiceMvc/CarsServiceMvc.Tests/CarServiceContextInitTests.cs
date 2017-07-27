using System;
using System.IO;
using CarServiceMvc.DAL;
using CarServiceMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarsServiceMvc.Tests
{
    [TestClass]
    public class CarServiceContextInitTests
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<CarServiceContext> _options;

        public CarServiceContextInitTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<CarServiceContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }
        [TestMethod]
        public void InitializeDatabaseWithDataTest()
        {
            using (var context = new CarServiceContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var car1 = new Car()
                {
                    Producer = "Volkswagen",
                    Model = "Golf IV",
                    ProductionDate = new DateTime(2009, 01, 01),
                    IsOnWarranty = false
                };

                var car2 = new Car()
                {
                    Producer = "Peugeot",
                    Model = "206",
                    ProductionDate = new DateTime(2000, 01, 01),
                    IsOnWarranty = false
                };

                context.Cars.AddRange(car1, car2);
                context.SaveChanges();
            }
        }
    }
}
