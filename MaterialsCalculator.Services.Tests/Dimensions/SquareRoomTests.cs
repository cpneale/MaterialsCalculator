using System;
using MaterialsCalculator.Core.Dimensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;

namespace MaterialsCalculator.Services.Tests.Dimensions
{
    [TestClass]
    public class GivenASquareRoom
    {
        private SquareRoom _squareRoom;

        [TestInitialize]
        public void Setup()
        {
            _squareRoom = new SquareRoom();
        }

        [TestMethod]
        public void WhenICallCalculateArea_ThenItDoesNotThrow()
        {
            _squareRoom.Invoking(r => r.CalculateArea())
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateArea_ThenItReturnsTheCorrectArea()
        {
            double h = 2.0, w = 4.0, l = 5.0;

            _squareRoom.Height = h;
            _squareRoom.Length = l;
            _squareRoom.Width = w;

            var expectedArea = 
                ((h * l) * 2) +
                ((h * w) * 2) +
                (w * l);

            var area = _squareRoom.CalculateArea();

            area.Should().Be(expectedArea);
        }

        [TestMethod]
        public void WhenICallCalculateAreaWithFloatingPointNumbers_ThenItReturnsTheCorrectArea()
        {
            double h = 2.1, w = 4.5, l = 5.6;

            _squareRoom.Height = h;
            _squareRoom.Length = l;
            _squareRoom.Width = w;

            var expectedArea =
                ((h * l) * 2) +
                ((h * w) * 2) +
                (w * l);

            var area = _squareRoom.CalculateArea();

            area.Should().Be(expectedArea);
        }

        [TestMethod]
        public void WhenICallCalculateVolume_ThenItDoesNotThrow()
        {
            _squareRoom.Invoking(r => r.CalculateVolume())
                .Should().NotThrow();
        }

        [TestMethod]
        public void WhenICallCalculateVolume_ThenItReturnsTheCorrectVolume()
        {
            double h = 2.0, w = 4.0, l = 5.0;

            _squareRoom.Height = h;
            _squareRoom.Length = l;
            _squareRoom.Width = w;

            var expectedVolume = (h * l * w);

            var area = _squareRoom.CalculateVolume();

            area.Should().Be(expectedVolume);
        }

        [TestMethod]
        public void WhenICallCalculateVolumeWithFloatingPointNumbers_ThenItReturnsTheCorrectVolume()
        {
            double h = 2.1, w = 4.5, l = 5.6;

            _squareRoom.Height = h;
            _squareRoom.Length = l;
            _squareRoom.Width = w;

            var expectedVolume = (h * l * w);

            var volume = _squareRoom.CalculateVolume();

            volume.Should().Be(expectedVolume);
        }

    }
}
