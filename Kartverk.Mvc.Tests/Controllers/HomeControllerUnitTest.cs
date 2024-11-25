using Kartverk.Mvc.Controllers.Home;
using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Kartverk.Mvc.Tests.Controllers;

public class HomeControllerUnitTest
{
    [Fact]
    public void Index_ReturnsViewResult()
    {
        // Act
        var result = GetUnitUnderTest().Index();

        // Assert
        Assert.IsType<ViewResult>(result); // Sjekk at det er en ViewResult
    }

    [Fact]
    public void ReciveData_Post_ReturnsViewResult_WithUpdateMessage()
    {
        // Arrange 
        var model = new HomeViewModel {NewMessage = "New Message"};
        
        // Act 
        var result = GetUnitUnderTest().Index(model);
        
        // Assert 
        var viewResult = Assert.IsType<ViewResult>(result);
        var updatedModel = Assert.IsType<HomeViewModel>(viewResult.Model);
        Assert.Equal("New Message", updatedModel.Message);
        Assert.Null(updatedModel.NewMessage);
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
    
    [Fact]
    public void AdminDachboard_ReturnsViewResult_WhenUserIsAuthorized()
    {
        // Act 
        var result = GetUnitUnderTest().AdminDashboard();

        // Assert 
        Assert.IsType<ViewResult>(result); // Sjekker at det returneres en ViewResult 
    }

    private HomeController GetUnitUnderTest()
    {
        var logger = Substitute.For<ILogger<HomeController>>();
        var controller =  new HomeController(logger);
        controller.ControllerContext.HttpContext = new DefaultHttpContext();
        return controller;
    }
}