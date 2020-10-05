using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = WeatherAnalysis.WeatherUtilities;
using WeatherAnalysis;
using FluentAssertions;

    
namespace WeatherTest

 {

    [TestClass]
    public class JudgeWeatherByEarthHistory_Should
    {
        [TestMethod]
        [DataRow(-300)]

        public void JudgeWeatherByEarthHistoryThrowException_WhentempCelsiusLessThanMinus273(double pTemperature)
        {
            //Arrange
            Weather Weather1 = new Weather();

            // Act and Assert
            Assert.ThrowsException<TooColdException.ColderThanAbsoluteZeroException>(() => SUT.JudgeWeatherByEarthHistory(Weather1, pTemperature));
        }
        [TestMethod]
        [DataRow(-100, "Colder than Earth")]
        [DataRow(-273, "Colder than Earth")]
        

        public void JudgeWeatherByEarthHistory_ShouldReturnColderThanEarth_WhenTempCelsiusIsGreaterandEqualToMinus273AndLessThanMinus89(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();

            // Act
            string result = SUT.JudgeWeatherByEarthHistory(Weather1, pTemperature);

            //Assert

            //Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);

        }
        [TestMethod]
        [DataRow(44, "Meh")]
        [DataRow(-89, "Meh")]
        [DataRow(56, "Meh")]

        public void JudgeWeatherByEarthHistory_ShouldReturnMeh_WhenTempCelsiusIsGreaterThanEqualToMinus89AndLessAndEqualTo56(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();


            // Act
            string result = SUT.JudgeWeatherByEarthHistory(Weather1, pTemperature);

            //Assert
            // Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);


        }
        [TestMethod]
        [DataRow(100, "Hotter than Earth")]

        public void JudgeWeatherByEarthHistory_ShouldReturnHotterthanEarth_WhenTempCelsiusIsGreaterThan56(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();

            //Act
            string result = SUT.JudgeWeatherByEarthHistory(Weather1, pTemperature);

            //Assert
            //Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);


        }

    }
    [TestClass]
    public class JudgeWeatherByWaterState_Should
    { 


        [TestMethod]
        [DataRow(-300)]

        public void JudgeWeatherByWaterStateThrowException_WhentempCelsiusLessThanMinus273(double pTemperature)
        {
            //Arrange
            Weather Weather1 = new Weather();

            //Act and Assert
            Assert.ThrowsException<TooColdException.ColderThanAbsoluteZeroException>(() => SUT.JudgeWeatherByWaterState(Weather1, pTemperature));
        }
        [TestMethod]
        [DataRow(-4, "Freezing")]
        [DataRow(0, "Freezing")]

        public void JudgeWeatherByWaterState_ShouldReturnFreezing_WhentempCelciusIsLessAndEqualTo0(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();

            //Act
            string result = SUT.JudgeWeatherByWaterState(Weather1, pTemperature);

            //Assert
            //Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);

        }
        [TestMethod]
        [DataRow(101, "Boiling")]
       

        public void JudgeWeatherByWaterState_ShouldReturnBoiling_WhentempCelciusIsGreaterThan99(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();

            //Act
            string result = SUT.JudgeWeatherByWaterState(Weather1, pTemperature);

            //Assert
            // Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);
           

        }
        [TestMethod]
        [DataRow(95, "Wet")]
        [DataRow(99, "Wet")]

        public void JudgeWeatherByWaterState_ShouldReturnWet_WhentempCelciusIsGreaterThan0AndLessAndEqualTo99(double pTemperature, string expectedResult)
        {
            //Arrange
            Weather Weather1 = new Weather();

            //Act
            string result = SUT.JudgeWeatherByWaterState(Weather1, pTemperature);

            //Assert
            //Assert.AreEqual(expectedResult, result);
            expectedResult.Should().Be(result);
       

        }

        
    }
}
