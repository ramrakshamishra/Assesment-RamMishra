using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessment_RaceTrack.Services
{
    public interface ITrackService
    {
        IEnumerable<Vehicle> GetVehiclesOnTrack();
        Response AddVehiclesOnTrack(VehicleDto vehicle);
        Response RemoveVehiclesFromTrack(Guid vehicleId);
        bool VehicleInspection(VehicleDto vehicleDto);
    }
}