﻿using AutoMapper;
using Mango.Services.ShppingCartAPI.Models;
using Mango.Services.ShppingCartAPI.Models.Dto;


namespace Mango.Services.ShppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfigs = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>();
                config.CreateMap<CartHeaderDto, CartHeader>();
                config.CreateMap<CartDetails, CartDetailsDto>();
                config.CreateMap<CartDetailsDto, CartDetails>();
            });
            return mappingConfigs;

        }
    }
}
