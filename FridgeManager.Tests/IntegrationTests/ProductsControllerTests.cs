using FluentAssertions;
using FridgeManager.API.Controllers;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FridgeManager.Tests.IntegrationTests
{
    public class ProductsControllerTests
    {
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
        public void GetAll_SendRequest_ReturnModelById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var Product = GetProductList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.ProductRepository.GetById(id, false))
                .Returns(Product);

            var controller = new ProductsController(repositoryManager.Object, null, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultModel = result.Value as Product;

            Assert.Equal(Product.Id, resultModel.Id);
            Assert.Equal(Product.Name, resultModel.Name);
            Assert.Equal(Product.DefaultQuantity, resultModel.DefaultQuantity);
        }
    }
}
