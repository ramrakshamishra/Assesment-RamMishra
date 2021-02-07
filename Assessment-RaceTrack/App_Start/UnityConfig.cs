using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Services;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Assessment_RaceTrack.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register unit of work
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ITrackService, TrackService>();
            container.RegisterType<IVehicleRepository, VehicleRepository>();

        }
    }
}