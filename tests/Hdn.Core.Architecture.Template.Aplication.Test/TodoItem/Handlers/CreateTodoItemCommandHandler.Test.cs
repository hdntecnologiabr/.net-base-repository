using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Hdn.Core.Architecture.Application.TodoItem.Commands.CreateTodoItem;
using Hdn.Core.Architecture.Application.TodoItem.Handlers;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Moq;
using Xunit;

namespace Hdn.Core.Architecture.Application.Tests.TodoItem.Handlers;

[Collection("Testing TodoItemCommand")]
public class CreateTodoItemCommandHandlerTest
{

    public CreateTodoItemCommandHandlerTest()
    {

    }

    [Fact(DisplayName = "Objeto do tipo TodoItemEntity valido irá Executar metodo TodoItemCreateHandle e deverá retornar um Id valido")]
    public async Task Should_Return_Success_ToDoItemHandler_Create()
    {
        //Arrange
        CreateTodoItemCommand request = new CreateTodoItemCommand { ListId = Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"), Title = "teste" };
        Mock<ITodoItemRepository> todoItemRepository = new Mock<ITodoItemRepository>();

        var entityToCreate = new TodoItemEntity
        {
            ListId = Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"),
            Title = "teste",
            Id = Guid.Parse("fe87aa6d-4ec8-4224-af21-59d8acffdf60")
        };

        var cancelationToken = new CancellationToken();

        todoItemRepository.Setup(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entityToCreate);

        CreateTodoItemCommandHandler commandHandler = new CreateTodoItemCommandHandler(todoItemRepository.Object);

        //Act
        var entityResponse = await commandHandler.Handle(request, cancelationToken);

        //Assert
        entityToCreate.Title.Should().Be(request.Title);
        entityToCreate.ListId.Should().Be(request.ListId);
        entityToCreate.Id.Should().Be(entityResponse);
        todoItemRepository.Verify(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName ="Objeto do tipo TodoItemEntity invalido irá executar metodo TodoItemCreateHandle e deverá retornar exception")]
    public async Task Should_Fail_ToDoItemHandler_Create()
    {
        //Arrange
        CreateTodoItemCommand request = new CreateTodoItemCommand { 
            ListId = Guid.Empty,
            Title = "Teste"
        };

        Mock<ITodoItemRepository> todoItemRepository = new Mock<ITodoItemRepository>();

        var entityToCreate = new TodoItemEntity
        {
            ListId = Guid.Parse("fe87aa6d-4ec8-4224-af21-59d8acffdf60"),
            Title = "testeFail",
        };

        var cancelationToken = new CancellationToken();

        todoItemRepository.Setup(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entityToCreate);

        CreateTodoItemCommandHandler commandHandler = new CreateTodoItemCommandHandler(todoItemRepository.Object);

        //Act
        var entityResponse = await commandHandler.Handle(request, cancelationToken);

        //Assert
        entityResponse.Should().BeEmpty();
        entityToCreate.ListId.Should().NotBe(request.ListId);
        entityToCreate.Title.Should().NotBe(request.Title);
    }
}


