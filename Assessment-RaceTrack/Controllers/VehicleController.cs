using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Models;
using Assessment_RaceTrack.Services;
using System;
using System.IO;
using System.Web.Mvc;

namespace Assessment_RaceTrack.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ITrackService _trackService;

        public VehicleController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDto vehicleDto)
        {
            //Vehicle Inspection
            if (!_trackService.VehicleInspection(vehicleDto))
            {
                ModelState.AddModelError(nameof(vehicleDto.ResponseMessage), "Vehilce inspection  failed.");
            }

            if (ModelState.IsValid)
            {

                //Process image file
                var image = vehicleDto.ImageFile;

                if (image?.ContentLength > 0)
                {
                    //To Get File Extension  
                    string fileExtension = Path.GetExtension(image.FileName);

                    //Add Current Date To Attached File Name  
                    string fileName = DateTime.Now.ToString("yyyyMMdd") + fileExtension;
                    string folderPath = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    image.SaveAs(folderPath);
                    vehicleDto.Image = fileName;
                }
                //Save record in db
                Response response = _trackService.AddVehiclesOnTrack(vehicleDto);
                if (response == Services.Response.Inserted)
                    ViewBag.Success = "Vehicle Added on track.";
                else
                    ModelState.AddModelError(nameof(vehicleDto.ResponseMessage), "Race track is already overloaded.");
            }

            return View();
        }

    }
}