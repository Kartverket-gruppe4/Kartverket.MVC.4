using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System.Data;
using Kartverk.Mvc.Controllers.FeilMelding;
using Kartverk.Mvc.Services;
using Kartverk.Mvc.API_Models;

namespace Kartverk.Mvc.Tests.Controllers
{
    public class FeilmeldingControllerTests
    {
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly FeilmeldingService _feilmeldingService;
        private readonly Mock<IKommuneInfoService> _mockKommuneInfoService;
        private readonly Mock<ILogger<FeilmeldingController>> _mockLogger;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly FeilmeldingController _controller;

        public FeilmeldingControllerTests()
        {
            // Mock IDbConnection
            _mockDbConnection = new Mock<IDbConnection>();

            // Mock tjenester
            _mockKommuneInfoService = new Mock<IKommuneInfoService>();
            _mockLogger = new Mock<ILogger<FeilmeldingController>>();

            // Opprett en instans av FeilmeldingService med mocket IDbConnection
            _feilmeldingService = new FeilmeldingService(_mockDbConnection.Object);

            // Mock UserManager
            var userStore = new Mock<IUserStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStore.Object, null, null, null, null, null, null, null, null
            );

            // Initialiser controller
            _controller = new FeilmeldingController(
                null, // DbContext ikke nødvendig for denne testen
                _mockKommuneInfoService.Object,
                _mockLogger.Object,
                _feilmeldingService,
                _mockUserManager.Object
            );
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task GetKommuneInfo_ValidCoordinates_ReturnsKommuneInfo()
        {
            // Arrange
            double nord = 60.0;
            double ost = 10.0;
            var kommuneInfo = new KommuneInfo
            {
                Kommunenummer = "0301",
                Kommunenavn = "Oslo"
            };

            _mockKommuneInfoService.Setup(k => k.GetKommuneInfoAsync(nord, ost))
                .ReturnsAsync(kommuneInfo);

            // Act
            var result = await _controller.GetKommuneInfo(nord, ost);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedKommuneInfo = Assert.IsType<KommuneInfo>(okResult.Value);
            Assert.Equal("0301", returnedKommuneInfo.Kommunenummer);
            Assert.Equal("Oslo", returnedKommuneInfo.Kommunenavn);
        }

    }
}