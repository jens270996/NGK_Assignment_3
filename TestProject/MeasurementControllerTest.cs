using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureAPI.Data;
using TemperatureAPI.Models;

namespace TestProject
{
    public class MeasurementControllerTest
    {
        private DbContextOptions<ApplicationContext> _options;
        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection).Options;
           
            using(var context=new ApplicationContext(_options))
            {
                context.Database.EnsureCreated();
                context.Locations.AddRange(
                    new Location { Name = "Odense", Latitude = 2020, Longtitude = 2020 },
                    new Location { Name = "Aarhus", Latitude = 1010, Longtitude = 1010 });

                context.Measurements.AddRange();
            }

        }
    }
}
