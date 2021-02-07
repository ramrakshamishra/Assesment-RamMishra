using Assessment_RaceTrack.Services;

using System;
using System.Web.Mvc;

namespace Assessment_RaceTrack.Controllers
{
  
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;
        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }
        // GET: Track
        public ActionResult Index()
        {
            return View(_trackService.GetVehiclesOnTrack());
        }
        public PartialViewResult GetVehicle()
        {
            return PartialView("_Vehicles",_trackService.GetVehiclesOnTrack());
        }
        [HttpPost]
        public ActionResult RemoveVehicleFromTrack(Guid vehicleId)
        {
            _trackService.RemoveVehiclesFromTrack(vehicleId);
            return RedirectToAction("Index", "Track");
        }
    }
}