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
    public void Privacy_ReturnsViewResult()
    {
        // Act 
        var result = GetUnitUnderTest().Privacy();
        
        // Assert
        Assert.IsType<ViewResult>(result); // Sjekker at det er en ViewResult  
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
    public void AdminLogin_ValidPassword_RedirectsToAdminPage()
    {
        // Arrange 
        const string validPassword = "admin123";
        
        // Act 
        var result = GetUnitUnderTest().AdminLogin(validPassword);
        
        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result); 
        Assert.Equal("Index", redirectToActionResult.ActionName);
        Assert.Equal("AdminFeilmelding", redirectToActionResult.ControllerName);
    }

    [Fact]
    public void AdminLogin_InvalidPassword_ReturnsViewWithError()
    {
        // Arrange 
        const string invalidPassword = "wrongpassword";
        var controller = GetUnitUnderTest();
        
        // Act 
        var result = controller.AdminLogin(invalidPassword);
        
        // Assert 
        var viewResult = Assert.IsType<ViewResult>(result); // Sjekker at det er en ViewResult
        Assert.True(controller.ModelState.ContainsKey("")); // Sjekker at ModelState har feil 
    }

    private HomeController GetUnitUnderTest()
    {
        var logger = Substitute.For<ILogger<HomeController>>();
        var controller =  new HomeController(logger);
        controller.ControllerContext.HttpContext = new DefaultHttpContext();
        return controller;
    }
}