using AutoMapper;
using MyFirstMVCWebApp.Dtos;
using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}