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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MassageStudio.Tests
{
    public class ReservationContollerTests
    {
        private readonly ReservationController reservationContoller;

        private readonly IReservationService reservationService;

        public ReservationContollerTests()
        {
            this.reservationService = new ReservationServiceFake();
            this.reservationContoller =
                new ReservationController
                (
                  reservationService,
                  new Logger<ReservationController>(new LoggerFactory())
                );

            var objectValidator = new Mock<IObjectModelValidator>();
            objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(),
                                              It.IsAny<ValidationStateDictionary>(),
                                              It.IsAny<string>(),
                                              It.IsAny<Object>()));

            reservationContoller.ObjectValidator = objectValidator.Object;
        }


        [Fact]
        public void GetAll_WhenCalled_ShouldRetunTypes()
        {
            //Act
            var types = this.reservationContoller.Get();

            //Assert
            _ = Assert.IsType<List<Reservations>>(types);
            Assert.Equal(2, types.Count());
        }

        [Fact]
        public async void DeleteWithValidId_WhenCalled_ShouldRetunTrue()
        {
            //Act
            var masseur = await this.reservationService.Delete("1");

            //Assert
            Assert.True(masseur);
        }

        [Fact]
        public async void DeleteWithInvalidId_WhenCalled_ShouldRetunFalse()
        {
            //Act
            var reservation = await this.reservationService.Delete("12");

            //Assert
            Assert.False(reservation);
        }

        [Fact]
        public async void PostWitValidData_WhenCalled_ShouldRetunOkRequest()
        {
            CreateReservationInputModel model = new CreateReservationInputModel() 
            { 
                CustomerId = "1", 
                MasseurId = "1", 
                TypeId = "1", 
                Date = DateTime.UtcNow.AddHours(1)};

            //Act
            var reservation = await this.reservationContoller.Post(model);

            //Assert
            Assert.IsType<OkObjectResult>(reservation);
        }

    }
}
