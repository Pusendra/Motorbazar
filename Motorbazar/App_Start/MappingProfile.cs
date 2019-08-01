using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Motorbazar.Models;
using Motorbazar.Dtos;

namespace Motorbazar.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Vehicle, VehicleDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<VehicleType, VehicleTypeDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<VehicleDto, Vehicle>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}