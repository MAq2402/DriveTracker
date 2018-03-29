using AutoMapper;
using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<DriveTracker.Entities.User, DriveTracker.Models.Users.UserDto>();

                config.CreateMap<DriveTracker.Entities.Car, DriveTracker.Models.Cars.CarDto>();
                //.ForMember(dest=>dest.FuelType,opt=>opt.MapFrom(src=>Enum.GetName(typeof(FuelType),src.FuelType)));
                config.CreateMap<DriveTracker.Models.Cars.CarForCreationDto, DriveTracker.Entities.Car>();
                config.CreateMap<DriveTracker.Models.Cars.CarForUpdateDto, DriveTracker.Entities.Car>();
                config.CreateMap<DriveTracker.Entities.Car,DriveTracker.Models.Cars.CarForUpdateDto>();

                config.CreateMap<DriveTracker.Entities.Journey, DriveTracker.Models.Journeys.JourneyDto>();
                config.CreateMap<DriveTracker.Models.Journeys.JourneyForCreationDto, DriveTracker.Entities.Journey>();
            
                config.CreateMap<DriveTracker.Entities.PassengerRoute, DriveTracker.Models.SingleUserJourneys.PassengerRouteDto>();
            });
        }
            
    }

}