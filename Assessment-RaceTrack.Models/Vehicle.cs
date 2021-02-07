using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment_RaceTrack.Models
{
   
    public class Vehicle
    {
        public Guid Id { get; set; }
        public VehicleType Type { get; set; }

        [Required]
        public string Name { get; set; }

        public bool HandBreak { get; set; }

        public bool TowStrap { get; set; }

        [Range(0, 5)]
        public int Lift { get; set; }

        public string Image { get; set; }
       
        public int? TireWear { get; set; }

        public bool IsActive { get; set; }

        public bool OnTrack { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
