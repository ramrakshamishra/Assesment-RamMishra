using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Assessment_RaceTrack.Services
{
    public enum Response
    { None, Inserted, Deleted, Overloaded, InspectionFail }
    public class TrackService : ITrackService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly int totalAllowedVehicleOnTrack = 0;
        public TrackService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            totalAllowedVehicleOnTrack = vehicleRepository.totalAllowedVehicleOnTrack==0? Convert.ToInt32(ConfigurationManager.AppSettings["TotalAllowedVehicleOnTrack"]): vehicleRepository.totalAllowedVehicleOnTrack;
        }
        public IEnumerable<Vehicle> GetVehiclesOnTrack()
        {
            return _vehicleRepository.GetVehiclesOnTrack(totalAllowedVehicleOnTrack);
        }

        public Response AddVehiclesOnTrack(VehicleDto vehicleDto)
        {
            try
            {
                //Check for track overload
                bool checkTrackOverload = _vehicleRepository.Get().Count() >= totalAllowedVehicleOnTrack ? true : false;

                //Vehicle inspection
                if (!VehicleInspection(vehicleDto))
                    return Response.InspectionFail;

                //Process for saving in database
                var vehicleDetails = new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = vehicleDto.Name,
                    Type = vehicleDto.Type,
                    HandBreak = vehicleDto.HandBreak,
                    TireWear = vehicleDto.TireWear,
                    Lift = vehicleDto.Lift,
                    IsActive = true,
                    Image = vehicleDto.Image,
                    CreatedDate = DateTime.Now,
                    OnTrack = true
                };
                //In case of track overloaded
                if (checkTrackOverload)
                    return Response.Overloaded;
                var result = _vehicleRepository.Insert(vehicleDetails);
                return (result != null) ? Response.Inserted : Response.None;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Response RemoveVehiclesFromTrack(Guid vehicleId)
        {
            try
            {
                _vehicleRepository.Delete(vehicleId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Response.Deleted;
        }
        public bool VehicleInspection(VehicleDto vehicleDto)
        {
            //TowStrap should be true for both truck and car
            if (vehicleDto.TowStrap == true)
            {
                if (vehicleDto.Type == VehicleType.Car)
                    return (vehicleDto.TireWear < 85);
                if (vehicleDto.Type == VehicleType.Truck)
                    return (vehicleDto.Lift <= 5);
            }
            return false;

        }
    }
}