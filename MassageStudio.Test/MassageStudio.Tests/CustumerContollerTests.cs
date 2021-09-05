using MassageStudio.API.Controllers;
using MassageStudio.API.InputModels;
using MassageStudio.Tests.FakeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MassageStudio.Tests
{
    public class CustumerContollerTests
    {
        private readonly CustumerController custumerController;

        private readonly ICustumerService custumerService;

        private readonly IReservationService reservationService;

        public CustumerContollerTests()
        {
            this.custumerService = new CustumerServiceFake();
            this.reservationService = new ReservationServiceFake();
            
            this.custumerController = 
                new CustumerController
                (
                  new Logger<CustumerController>(new LoggerFactory()),
                  custumerService,
                  reservationService
                );

            var objectValidator = new Mock<IObjectModelValidator>();
            objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(),
                                              It.IsAny<ValidationStateDictionary>(),
                                              It.IsAny<string>(),
                                              It.IsAny<Object>()));

            custumerController.ObjectValidator = objectValidator.Object;
        }

        [Fact]
        public async void GetCustomer_WhenCalled_ShouldRetunCustumerModel()
        {
            //Act
            var okResult = await this.custumerController.GetCustomer("1");

            //Assert
            Assert.IsType<Customer>(okResult);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldRetunAllCustumers()
        {
            //Act
            var okResult = this.custumerController.GetAll();

            //Assert
            _ = Assert.IsType<List<Customer>>(okResult);
        }

        [Fact]
        public async void Post_WhenCalled_ShouldRetunAllCustumers()
        {
            //Arrange 
            var model = new CreateCustumerInputModel() { FirstName = "Gosho3", LastName = "Peshev3", Phone = "0885477370" };

            //Act
            var okResult = await this.custumerController.Post(model);

            //Assert
            _ = Assert.IsType<OkObjectResult>(okResult);
        }

        //[Fact]
        //public async void PostWhitInvalidInput_WhenCalled_ShouldRetunAllCustumers()
        //{
        //    //Arrange 
        //    CreateCustumerInputModel model = new CreateCustumerInputModel();

        //    //Act
        //    var okResult = await this.custumerController.Post(model);

        //    //Assert
        //    _ = Assert.IsType<BadRequestObjectResult>(okResult);
        //}

        [Fact]
        public async void DeleteWithValidId_WhenCalled_ShouldRetunTrue()
        {
            //Arrange 
            CreateCustumerInputModel model = new CreateCustumerInputModel();

            //Act
            var okResult = await this.custumerController.Delete("1");

            //Assert
            Assert.True(okResult);
            Assert.Equal(1, custumerService.GetAll().Count);
        }

        [Fact]
        public async void DeleteWithInValidId_WhenCalled_ShouldRetunFalse()
        {
            //Arrange 
            CreateCustumerInputModel model = new CreateCustumerInputModel();

            //Act
            var okResult = await this.custumerController.Delete("65");

            //Assert
            Assert.False(okResult);
            Assert.Equal(2, custumerService.GetAll().Count);
        }

    }
}
