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
    public class ProductsControllerTests
    {
        private static IMapper _mapper;

        public ProductsControllerTests()
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

        private IEnumerable<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8"),
                    Name = "Banana",
                    DefaultQuantity = 5
                },
                new Product
                {
                    Id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303"),
                    Name = "Apple",
                    DefaultQuantity = 7
                }
            };
        }

        [Fact]
        public void GetAll_SendRequest_ReturnEmptyList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            repositoryManager.Setup(r => r.ProductRepository.GetAll(false))
                .Returns(new List<Product>());

            var controller = new ProductsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<Product>;
            models.Should().HaveCount(0);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnCompletedList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var fakeModelsList = GetProductList();

            repositoryManager.Setup(r => r.ProductRepository.GetAll(false))
                .Returns(fakeModelsList);

            var controller = new ProductsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var models = result.Value as IEnumerable<Product>;
            models.Should().HaveSameCount(fakeModelsList);
            models.Should().BeEquivalentTo(fakeModelsList);
        }

        [Fact]
        public void Get_SendRequest_ReturnProductById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var product = GetProductList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.ProductRepository.GetById(id, false))
                .Returns(product);

            var controller = new ProductsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultModel = result.Value as Product;

            Assert.Equal(product.Id, resultModel.Id);
            Assert.Equal(product.Name, resultModel.Name);
            Assert.Equal(product.DefaultQuantity, resultModel.DefaultQuantity);
        }

        [Fact]
        public void Create_SendRequest_ReturnStatusCode201()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            Product product = new Product
            {
                Name = "Banana",
                DefaultQuantity = 5
            };

            ProductForCreationDto productForCreation = new ProductForCreationDto
            {
                Name = "Banana",
                DefaultQuantity = 5
            };

            repositoryManager.Setup(r => r.ProductRepository.Create(product));

            var controller = new ProductsController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.Create(productForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Delete_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8");
            var product = GetProductList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.ProductRepository.GetById(id, false))
                .Returns(product);
            repositoryManager.Setup(r => r.ProductRepository.Delete(product));

            var controller = new ProductsController(repositoryManager.Object, null, null);

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
            var product = GetProductList().ToList().Find(m => m.Id.Equals(id));
            var productForUpdate = new ProductForUpdateDto
            {
                Id = id,
                Name = "Cheese",
                DefaultQuantity = 1
            };

            repositoryManager.Setup(r => r.ProductRepository.GetById(id, true))
                .Returns(product);

            var controller = new ProductsController(repositoryManager.Object, null, _mapper);

            // Act
            var response = controller.Update(productForUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
