using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Hdn.Core.Architecture.Application.TodoItem.Commands.CreateTodoItem;
using Hdn.Core.Architecture.Application.TodoItem.Handlers;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Hdn.Core.Architecture.Application.Tests.TodoItem.Handlers;

[Collection("Testing TodoItemCommand")]
public class CreateTodoItemCommandHandlerTest
{

    public CreateTodoItemCommandHandlerTest()
    {

    }

    [Fact(DisplayName ="Objeto do tipo TodoItemEntity valido irá Executar metodo TodoItemCreate e deverá retornar um Id valido")]
    public async Task should_return_success_ToDoItemHandler_create()
    {
        //Arrange
        CreateTodoItemCommand request = new CreateTodoItemCommand { ListId = Guid.Parse("9cd821f-cf33-4a17-9730-25d96f182af3"), Title = "teste"};
        Mock<ITodoItemRepository> todoItemRepository = new Mock<ITodoItemRepository>();

        var entityToCreate = new TodoItemEntity
        {
            ListId = Guid.Parse("9cd821f-cf33-4a17-9730-25d96f182af3"),
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
}


