using Microsoft.AspNetCore.Mvc;
using Moq;
using Nventory.Controllers;
using Nventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace NventoryTests
{
    public class ManageUserControllerTests
    {
        ManageUsersController _controller;
        public ManageUserControllerTests()
        {
            var repository = new Mock<IUsersRepository>();
            repository.Setup(x => x.GetUsersAsync()).ReturnsAsync(GetUsers);
            _controller = new ManageUsersController(repository.Object);
        }    
        

        [Fact]
        public async void Index()
        {
            var result = await _controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }


        private IEnumerable<UserModel> GetUsers()
        {
            return new List<UserModel>()
            {
                new UserModel()
                {
                    Name = "Alex",
                    Email = "alex@example.com",
                    IsAdmin = true
                },
                new UserModel()
                {
                    Name = "John",
                    Email = "john@example.com",
                    IsAdmin = false
                },
                new UserModel()
                {
                    Name = "Sam",
                    Email = "sam@example.com",
                    IsAdmin = false
                }
            };
        }
    }
}
