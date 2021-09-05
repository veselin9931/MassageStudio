using MassageStudio.Tests.FakeServices;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MassageStudio.Tests
{
    public class MassageTypeControllerTests
    {
        private readonly IMassageTypesService service;

        public MassageTypeControllerTests()
        {
            this.service = new MassageTypeServiceFake();
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldRetunTypes()
        {
            //Act
            var types = this.service.GetAll();

            //Assert
            _ = Assert.IsType<List<MassageType>>(types);
            Assert.Equal(3, types.Count);
        }

        [Fact]
        public async void GetById_WhenCalled_ShouldRetunModel()
        {
            //Act
            var types = await this.service.GetById("1");

            //Assert
            _ = Assert.IsType<MassageType>(types);
            Assert.Equal("1", types.Id);
        }

        [Fact]
        public void GetByName_WhenCalled_ShouldRetunModel()
        {
            //Act
            var types = this.service.GetByName("Relax");

            //Assert
            _ = Assert.IsType<MassageType>(types);
            Assert.Equal("1", types.Id);
        }

    }
}
