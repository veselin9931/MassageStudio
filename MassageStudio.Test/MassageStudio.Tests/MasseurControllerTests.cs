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
    public class MasseurControllerTests
    {
        private readonly MassaurController controller;

        private readonly IMasseurService service;

        private readonly IReservationService reservationService;

        public MasseurControllerTests()
        {
            this.service = new MasseurServiceFake();
            this.reservationService = new ReservationServiceFake();

            this.controller = new MassaurController
                (
                  new Logger<MassaurController>(new LoggerFactory()),
                  service,
                  reservationService
                );

            var objectValidator = new Mock<IObjectModelValidator>();
            objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(),
                                              It.IsAny<ValidationStateDictionary>(),
                                              It.IsAny<string>(),
                                              It.IsAny<Object>()));

            controller.ObjectValidator = objectValidator.Object;
        }

        [Fact]
        public async void GetMasseur_WhenCalled_ShouldRetunMsseurModel()
        {
            //Act
            var masseur = await this.controller.Get("1");

            //Assert
            Assert.IsType<Мasseur>(masseur);
            Assert.Equal("1", masseur.Id);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldRetunMsseurModelCollection()
        {
            //Act
            var masseur = this.controller.GetAll();

            //Assert
            Assert.IsType<List<Мasseur>>(masseur);
            Assert.Equal(1, masseur.Count);
        }

        [Fact]
        public async void DeleteWithValidId_WhenCalled_ShouldRetunAccepted()
        {
            //Act
            var masseur = await this.controller.Delete("1");

            //Assert
            Assert.IsType<AcceptedResult>(masseur);
        }

        [Fact]
        public async void DeleteWithInvalidId_WhenCalled_ShouldRetunNoContent()
        {
            //Act
            var masseur = await this.controller.Delete("12");

            //Assert
            Assert.IsType<NoContentResult>(masseur);
        }


        //[Fact]
        //public async void PostWitInvalidData_WhenCalled_ShouldRetunBadRequest()
        //{
        //    CreateMasseurInputModel model = new CreateMasseurInputModel() { FirstName = "", LastName = "1" };

        //    //Act
        //    var masseur = await this.controller.Post(model);

        //    //Assert
        //    Assert.IsType<BadRequestObjectResult>(masseur);
        //}

        [Fact]
        public async void PostWitValidData_WhenCalled_ShouldRetunOkRequest()
        {
            CreateMasseurInputModel model = new CreateMasseurInputModel() {  FirstName = "Tedo", LastName = "Tedov" };

            //Act
            var masseur = await this.controller.Post(model);

            //Assert
            Assert.IsType<OkObjectResult>(masseur);
        }
    }
}
