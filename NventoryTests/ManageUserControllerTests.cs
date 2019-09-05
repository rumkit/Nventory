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
            var model = Assert.IsAssignableFrom<IEnumerable<UserViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }


        private IEnumerable<UserViewModel> GetUsers()
        {
            return new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Name = "Alex",
                    Email = "alex@example.com",
                    IsAdmin = true
                },
                new UserViewModel()
                {
                    Name = "John",
                    Email = "john@example.com",
                    IsAdmin = false
                },
                new UserViewModel()
                {
                    Name = "Sam",
                    Email = "sam@example.com",
                    IsAdmin = false
                }
            };
        }
    }
}
