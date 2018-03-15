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
                config.CreateMap<DriveTracker.Entities.User, DriveTracker.Models.UserDto>();

                config.CreateMap<DriveTracker.Entities.Car, DriveTracker.Models.CarDto>();
                config.CreateMap<DriveTracker.Models.CarForCreationDto, DriveTracker.Entities.Car>();
                config.CreateMap<DriveTracker.Models.CarForUpdateDto, DriveTracker.Entities.Car>();
                config.CreateMap<DriveTracker.Entities.Car,DriveTracker.Models.CarForUpdateDto>();

                config.CreateMap<DriveTracker.Entities.Fuel, DriveTracker.Models.FuelDto>()
                .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>Enum.GetName(typeof(FuelType),src.Type)));
                
            });
        }
            
    }

}