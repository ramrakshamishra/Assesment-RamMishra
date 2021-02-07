using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;

namespace Assessment_RaceTrack.Data
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseAlways<RaceTrackContext>
    {
        protected override void Seed(RaceTrackContext context)
        {
            var vehicles = new List<Vehicle>()
            {
                //Prepaire vehicle data for migration
                new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 1St vehicle on race track",
                    Type=VehicleType.Car,
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                    OnTrack=true
                },
                 new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 2nd vehicle on race track",
                    HandBreak = true,
                      Type=VehicleType.Car,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
                  new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 3rd vehicle on race track",
                      Type=VehicleType.Car,
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
                   new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 4th vehicle on race track",
                      Type=VehicleType.Car,
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
                    new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 5th vehicle on race track",
                      Type=VehicleType.Car,
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
            };
            vehicles.ForEach(vehicle => context.Vehicles.Add(vehicle));

            base.Seed(context);
            // context.SaveChanges();
        }
    }
}
