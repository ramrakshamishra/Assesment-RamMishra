using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Data;
using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment_RaceTrack.Core.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public IUnitOfWork unitOfWork { get; }
        public int totalAllowedVehicleOnTrack { get ; set ; }

        public VehicleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public  IEnumerable<Vehicle> GetVehiclesOnTrack(int count=0)
        {
            List<Vehicle> vehiles = new List<Vehicle>();
            try
            {
                return Get().Where(x => x.OnTrack).Take(count);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
