using AutoMapper;
using M5_NETCORE.CORE.DTOs;
using M5_NETCORE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace M5_NETCORE.INFRASTRUCTURE.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }

    }
}
