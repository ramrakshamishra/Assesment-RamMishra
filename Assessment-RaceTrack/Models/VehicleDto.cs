using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assessment_RaceTrack.Models
{
    public class VehicleDto:Vehicle
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public string ResponseMessage { get; set; }
    }
}