using FridgeManager.API.Controllers;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FridgeManager.Domain.DTO.FridgeModel;
using AutoMapper;
using System.Net;

namespace FridgeManager.Tests.IntegrationTests
{
    public class FridgeModelsControllerTests
    {
        private IEnumerable<FridgeModel> GetFridgeModelList()
        {
            return new List<FridgeModel>
            {
                new FridgeModel
                {
                    Id = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8"),
                    Name = "R2D2",
                    Year = 2011
                },
                new FridgeModel
                {
                    Id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303"),
                    Name = "KJ-118",
                    Year = 2015
                }
            };
        }

        [Fact]
        public void GetAll_SendRequest_ReturnEmptyList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            repositoryManager.Setup(r => r.FridgeModelRepository.GetAll(false))
                .Returns(new List<FridgeModel>());

            var controller = new FridgeModelsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<FridgeModel>;
            models.Should().HaveCount(0);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnCompletedList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var fakeModelsList = GetFridgeModelList();

            repositoryManager.Setup(r => r.FridgeModelRepository.GetAll(false))
                .Returns(fakeModelsList);

            var controller = new FridgeModelsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<FridgeModel>;
            models.Should().HaveSameCount(fakeModelsList);
            models.Should().BeEquivalentTo(fakeModelsList);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnModelById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var fridgeModel = GetFridgeModelList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.FridgeModelRepository.GetById(id, false))
                .Returns(fridgeModel);

            var controller = new FridgeModelsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultModel = result.Value as FridgeModel;

            Assert.Equal(fridgeModel.Id, resultModel.Id);
            Assert.Equal(fridgeModel.Name, resultModel.Name);
            Assert.Equal(fridgeModel.Year, resultModel.Year);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnNotFoundException()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = Guid.NewGuid();
            var fridgeModel = GetFridgeModelList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.FridgeModelRepository.GetById(It.IsAny<Guid>(), false))
                .Returns(fridgeModel);

            var controller = new FridgeModelsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultModel = result.Value as FridgeModel;

            Assert.Equal(fridgeModel.Id, resultModel.Id);
            Assert.Equal(fridgeModel.Name, resultModel.Name);
            Assert.Equal(fridgeModel.Year, resultModel.Year);
        }
    }
}
