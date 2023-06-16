using Azure.Core;
using Bogus.DataSets;
using Castle.Core.Resource;
using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApi.Application.Commands;
using WebApi.Application.Handlers;
using WebApi.Application.Models;
using WebApi.Infrastructure.Errors;
using WebApi.Services;
using WebApi.Tests.Mock;
using Xunit;

namespace WebApi.Tests
{
    public class ProductTest
    {
        private readonly MediatorMock _mediator;
        private readonly ErrorHandlerMock _errorHandlerMock;
        private readonly ProductServiceMock _productService;
        private readonly RepositoryProductMock _repositoryProduct;

        

        public ProductTest()
        {
            _productService = new();
            _mediator = new();
            _errorHandlerMock = new();
            _repositoryProduct = new();
        }

        #region Success
        [Fact]
        public async Task Create_Product_Return_Success()
        {
            //Arrange
            CreateProductCommand command = new ("Batata Frita");

            CreateProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
     

            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Product_Return_Success()
        {
            //Arrange
            DeleteProductCommand command = new (150);

            DeleteProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);


            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Update_Product_Return_Success()
        {
            //Arrange
            EditProductCommand command = new ("Batata Frita", 10);

            EditProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.EditAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);


            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.EditAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task  Get_All_Product_Is_Success()
        {
            //Arrange
            Product productOne = new ("Batata");
            Product productTwo = new ("Melão");
            List<Product> productAll = new List<Product>() { productOne, productTwo };

            _repositoryProduct.GetAllMock(productAll);

            ProductService service = new (_repositoryProduct.Object);

            //Act
            List<Product> productsResponse = await service.GetAllProductAsync();

            productsResponse.Should().BeEquivalentTo(productAll);
        }

        #endregion

        #region Exception
        [Fact]
        public async Task CreateProduct_Return_InvalidOperationException()
        {
            //Arrange
            CreateProductCommand command = new ("Batata Frita");
            CreateProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, false);

            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task EditProduct_Return_InvalidOperationException()
        {
            //Arrange
            EditProductCommand command = new ("Batata Frita", 10);
            EditProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, false);

            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.EditAsync(It.IsAny<Product>()), Times.Never);
        }


        [Fact]
        public async Task DeleteProduct_Return_InvalidOperationException()
        {
            //Arrange
            DeleteProductCommand command = new (10);
            DeleteProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, false);

            //Act
            await handler.Handle(command, default);

            // Assert
            _repositoryProduct.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task Get_All_Product_Is_Fail()
        {
            //Arrange
            Product productOne = new ("Batata");
            Product productTwo = new ("Melão");
            List<Product> productAll = new List<Product>() { productOne, productTwo };

            _repositoryProduct.GetAllMock();

            ProductService service = new (_repositoryProduct.Object);

            //Act
            Func<Task> action = async () => await service.GetAllProductAsync();

            // Assert
            await action.Should().ThrowExactlyAsync<System.Exception>().WithMessage("Error buscar a lista de Product");

        }

        #endregion

        #region ErrorValidate


        [Fact]
        public async Task Create_Product_Return_ErrorValidate()
        {
            //Arrange
            CreateProductCommand command = new("Batata Frita");

            CreateProductCommandHandler handler = new(_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.AddAsync(It.IsAny<Product>())).Throws<TimeoutException>();
            _errorHandlerMock.Setup(x => x.Add(ErrorValidate.FailCreateProduct));


            //Act
            await handler.Handle(command, default);

            // Assert
            _errorHandlerMock.Verify(x => x.Add(It.IsAny<ErrorValidate>()), Times.Once);
            _repositoryProduct.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Edit_Product_Return_ErrorValidate()
        {
            //Arrange
            EditProductCommand command = new("Batata Frita", 10);

            EditProductCommandHandler handler = new(_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.EditAsync(It.IsAny<Product>())).Throws<TimeoutException>();
            _errorHandlerMock.Setup(x => x.Add(ErrorValidate.FailEditProduct));


            //Act
            await handler.Handle(command, default);

            // Assert
            _errorHandlerMock.Verify(x => x.Add(It.IsAny<ErrorValidate>()), Times.Once);
            _repositoryProduct.Verify(x => x.EditAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Product_Return_ErrorValidate()
        {
            //Arrange
            DeleteProductCommand command = new (10);

            DeleteProductCommandHandler handler = new (_mediator.Object, _errorHandlerMock.Object, _repositoryProduct.Object);
            _errorHandlerMock.MockValidateCommand(command, true);
            _repositoryProduct.Setup(x => x.DeleteAsync(It.IsAny<int>())).Throws<TimeoutException>();
            _errorHandlerMock.Setup(x => x.Add(ErrorValidate.FailDeleteProduct));


            //Act
            await handler.Handle(command, default);

            // Assert
            _errorHandlerMock.Verify(x => x.Add(It.IsAny<ErrorValidate>()), Times.Once);
            _repositoryProduct.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
        #endregion

    }
}
