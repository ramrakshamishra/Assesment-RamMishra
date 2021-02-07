using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_RaceTrack;
using Assessment_RaceTrack.Controllers;
using Moq;
using Assessment_RaceTrack.Data;
using Assessment_RaceTrack.Services;
using Assessment_RaceTrack.Models;
using System.Data.Entity;
using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Core.Repository.Common;
using System.Linq.Expressions;

namespace Assessment_RaceTrack.Tests
{
    [TestClass]
    public class TrackServiceTest
    {
        #region Global Declaration

        private ITrackService trackService;
        private IList<VehicleDto> mockdata;
        private Mock<IVehicleRepository> mockRepository;
        Guid mockedVehicleId;

        #endregion

        #region Test Setup

        private void Setup()
        {
            mockedVehicleId = Guid.NewGuid();
            mockdata = new List<VehicleDto>()
            {
                //Prepaire vehicle data for mock
                new VehicleDto()
                {
                    Id = mockedVehicleId,
                    Name = "V1",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                    OnTrack=true
                },
                 new VehicleDto ()
                {
                    Id = Guid.NewGuid(),
                    Name = "V2",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
            };
            //Mock repository
            mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup(x => x.GetVehiclesOnTrack(5)).Returns(() => mockdata);
            mockRepository.Setup(x => x.totalAllowedVehicleOnTrack).Returns(() => 5);
            trackService = new TrackService(mockRepository.Object);
        }
        #endregion

        #region Add vehicles on track test cases
        [TestMethod]
        public void Should_Add_Vehicle_OnTrack()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Insert(It.IsAny<Vehicle>())).Returns(() => mockdata[0]);
          
            var mockVehicleDto = mockdata[0];

            //Act
            var actualResult = trackService.AddVehiclesOnTrack(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.Inserted, actualResult);
        }
       
        #endregion

        #region Vehicle inspection test cases
        [TestMethod]
        public void ShouldNot_Add_Vehicle_OnTrackWhenTowsStrapIsFasle()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Insert(It.IsAny<Vehicle>())).Returns(() => mockdata[0]);

            var mockVehicleDto = mockdata[0];
            mockVehicleDto.TowStrap = false;

            //Act
            var actualResult = trackService.AddVehiclesOnTrack(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }
        [TestMethod]
        public void ShouldNot_Add_Truck_OnTrackWhenLiftMoreThanExpectedInches()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Insert(It.IsAny<Vehicle>())).Returns(() => mockdata[0]);

            var mockVehicleDto = mockdata[0];
            mockVehicleDto.Type = VehicleType.Truck;
            mockVehicleDto.Lift = 6;

            //Act
            var actualResult = trackService.AddVehiclesOnTrack(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }
        [TestMethod]
        public void ShouldNot_Add_Car_OnTrackWhenTireWearMoreThanExpectedPercentages()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Insert(It.IsAny<Vehicle>())).Returns(() => mockdata[0]);

            var mockVehicleDto = mockdata[0];
            mockVehicleDto.Type = VehicleType.Car;
            mockVehicleDto.TireWear = 86;

            //Act
            var actualResult = trackService.AddVehiclesOnTrack(mockVehicleDto);

            //Assert
            Assert.AreEqual(Response.InspectionFail, actualResult);
        }

        #endregion

        [TestMethod]
        public void Should_Remove_Vehicle_FromTrack()
        {
            // Arrange
            Setup();

            //Act
            var actualResult = trackService.RemoveVehiclesFromTrack(mockedVehicleId);

            //Assert
            Assert.AreEqual(Response.Deleted, actualResult);
        }

        [TestMethod]
        public void Should_Get_VehiclesOnTrack()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.GetVehiclesOnTrack(It.IsAny<int>())).Returns(() => mockdata);

            //Act
            var actualResult = trackService.GetVehiclesOnTrack();

            //Assert
            Assert.IsTrue(actualResult.Count() > 0);
        }
    }
}
