using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UShop.Dto;
using UShop.Entities;

namespace UShop.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
                //.ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());




        }
    }
}