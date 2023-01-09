

using System;
using AppoinmentSchelulingProject.Shared;
using Volo.Abp.AutoMapper;
using AppoinmentSchelulingProject.Customers;
using AutoMapper;

namespace AppoinmentSchelulingProject;

public class AppoinmentSchelulingProjectApplicationAutoMapperProfile : Profile
{
    public AppoinmentSchelulingProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Customer, CustomerDto>();

        
    }
}