using System;
using AutoMapper;
using BERCA_TEST.Models;
using BERCA_TEST.Models.DTOs;

namespace BERCA_TEST
{
    public class MappingConfig
    {
        public static MapperConfiguration RegistrationMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<CustomerDTO, Customer>();
                config.CreateMap<Collection, CollectionDTO>();
                config.CreateMap<CollectionDTO, Collection>();
                config.CreateMap<Currency, CurrencyDTO>();
                config.CreateMap<CurrencyDTO, Currency>();
                config.CreateMap<Invoice, InvoiceDTO>();
                config.CreateMap<InvoiceDTO, Invoice>();
            });

            return mappingConfig;
        }

    }
}
