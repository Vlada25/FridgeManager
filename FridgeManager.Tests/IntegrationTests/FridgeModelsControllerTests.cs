using AutoMapper;
using FluentAssertions;
using FridgeManager.API.Controllers;
using FridgeManager.Domain;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FridgeManager.Tests.IntegrationTests
{
    public class FridgeModelsControllerTests
    {
        private static IMapper _mapper;

        public FridgeModelsControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

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
        public void Get_SendRequest_ReturnModelById()
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
        public void Create_SendRequest_ReturnStatusCode201()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            FridgeModel fridgeModel = new FridgeModel
            {
                Name = "GG-123",
                Year = 2013
            };

            FridgeModelForCreationDto fridgeModelForCreation = new FridgeModelForCreationDto
            {
                Name = "GG-123",
                Year = 2013
            };

            repositoryManager.Setup(r => r.FridgeModelRepository.Create(fridgeModel));

            var controller = new FridgeModelsController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.Create(fridgeModelForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Delete_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var fridgeModel = GetFridgeModelList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.FridgeModelRepository.GetById(id, false))
                .Returns(fridgeModel);
            repositoryManager.Setup(r => r.FridgeModelRepository.Delete(fridgeModel));

            var controller = new FridgeModelsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Update_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var fridgeModel = GetFridgeModelList().ToList().Find(m => m.Id.Equals(id));
            var fridgeModelForUpdate = new FridgeModelForUpdateDto
            {
                Id = id,
                Name = "FF-000",
                Year = 2011
            };

            repositoryManager.Setup(r => r.FridgeModelRepository.GetById(id, true))
                .Returns(fridgeModel);

            var controller = new FridgeModelsController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.Update(fridgeModelForUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
