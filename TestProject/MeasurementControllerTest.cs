using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureAPI.Controllers;
using TemperatureAPI.Data;
using TemperatureAPI.Models;
using NSubstitute;
using TemperatureAPI.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace TestProject
{
    public class MeasurementControllerTest
    {
        
        private DbContextOptions<ApplicationContext> _options;
        private MeasurementsController _uut;
        private Measurement m1;
        private Measurement m2;
        private Measurement m3;
        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection).Options;

            var context = new ApplicationContext(_options);
            
                context.Database.EnsureCreated();
                context.Locations.AddRange(
                    new Location { Name = "Odense", Latitude = 2020, Longtitude = 2020 },
                    new Location { Name = "Aarhus", Latitude = 1010, Longtitude = 1010 });

                context.Measurements.AddRange(
                    m1=new Measurement { LocationName="Odense",Humidity=70,Time=DateTime.Now,Pressure=1019.9},
                    m2=new Measurement { LocationName = "Aarhus", Humidity = 70, Time = DateTime.Now, Pressure = 1019.9 },
                    m3=new Measurement { LocationName = "Aarhus", Humidity = 70, Time = new DateTime(2020, 5, 1), Pressure = 1019.9 },
                    new Measurement { LocationName = "Aarhus", Humidity = 70, Time = new DateTime(2020,2,1), Pressure = 1019.9 },
                    new Measurement { LocationName = "Odense", Humidity = 70, Time = new DateTime(2020, 2, 1), Pressure = 1019.9 }
                    );
                context.SaveChanges();
                var hub=Substitute.For<IHubContext<MeasurementHub, IMeasurment>>();
                _uut = new MeasurementsController(context,hub);

            

        }

        [Test]
        public async Task GetThreeLatest_ReturnsThreeLatest()
        {
            var model = await _uut.GetThreeLatest();
            var res = model.Value;
            var expected = new List<Measurement> { m1, m2, m3 };
                   
            
            foreach(var mes in res)
            {
                
                Assert.IsTrue(expected.Where(m => m.Time == mes.Time).Any());
                
            }
            
          
        }
    }
}
