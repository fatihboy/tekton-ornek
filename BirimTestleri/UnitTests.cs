using AutoFixture.Xunit2;
using Enterprisecoding.TektonOrnek.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Enterprisecoding.TektonOrnek.BirimTestleri
{
    public class UnitTests
    {
        [Theory, AutoMoqData]
        public void Index_Should_Success([Frozen]Mock<ILogger<HomeController>> loggerMock)
        {
            var homeController = new HomeController(loggerMock.Object);

            Action action = () =>
            {
                var sonuc = homeController.Index();
                sonuc.Should().BeOfType<ViewResult>();
            };
            action.Should().NotThrow<Exception>();
        }

        [Theory, AutoMoqData]
        public void Privacy_Should_Success([Frozen]Mock<ILogger<HomeController>> loggerMock)
        {
            var homeController = new HomeController(loggerMock.Object);

            Action action = () =>
            {
                var sonuc = homeController.Privacy();
                sonuc.Should().BeOfType<ViewResult>();
            };
            action.Should().NotThrow<Exception>();
        }
    }
}
