using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TemperatureAPI.Controllers;
using TemperatureAPI.Data;

namespace TestProject
{
    public class ManageUsersControllerTest
    {
        private DbContextOptions<ApplicationContext> _options;
        

        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection).Options;

            using (var context = new ApplicationContext(_options))
            {
                context.Database.EnsureCreated();
                context.Locations.AddRange();
                context.Measurements.AddRange();
                context.Users.Add(new User
                { FirstName = "Jens", LastName = "Ane", Email = "JensAne@localhost", PwHash = "MommasBoy"});
            }

        }

        [Test]
        public void GetUser()
        {
            //ManageUsersController manage = new ManageUsersController(context);
            //List<User> = manage.GetUser();
        }
    }
}