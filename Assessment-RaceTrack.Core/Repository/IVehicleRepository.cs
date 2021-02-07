using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Models;
using System.Collections.Generic;

namespace Assessment_RaceTrack.Core.Repository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IUnitOfWork unitOfWork { get; }
        int totalAllowedVehicleOnTrack { get; set; }
        IEnumerable<Vehicle> GetVehiclesOnTrack(int count=0);
    }

}
