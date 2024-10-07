using Kartverk.Mvc.Controllers.Home;
using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Kartverk.Mvc.Tests.Controllers;

public class HomeControllerUnitTests
{

    [Fact]
    public void Index_ReturnsViewResult_WithHomeViewModel()
    {
        // Act
        var result = GetUnitUnderTest().Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<HomeViewModel>(viewResult.Model);
        Assert.Equal("Det tar en time", model.Message);
    }

    [Fact]
    public void ReceiveData_Post_ReturnsViewResult_WithUpdatedMessage()
    {
        // Arrange
        var model = new HomeViewModel { NewMessage = "New message" };

        // Act
        var result = GetUnitUnderTest().Index(model);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var updatedModel = Assert.IsType<HomeViewModel>(viewResult.Model);
        Assert.Equal("New message", updatedModel.Message);
        Assert.Null(updatedModel.NewMessage);
    }

    [Fact]
    public void Privacy_ReturnsViewResult()
    {
        // Act
        var result = GetUnitUnderTest().Privacy();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Error_ReturnsViewResult_WithErrorViewModel()
    {
        // Act
        var result = GetUnitUnderTest().Error();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
        Assert.NotNull(model.RequestId);
    }

    private HomeController GetUnitUnderTest()
    {
        var logger = Substitute.For<ILogger<HomeController>>();
        var controller =  new HomeController(logger);
        controller.ControllerContext.HttpContext = new DefaultHttpContext();
        return controller;
    }
}

