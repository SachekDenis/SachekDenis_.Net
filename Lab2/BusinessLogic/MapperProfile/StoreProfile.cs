﻿using AutoMapper;
using BusinessLogic.Dto;
using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.MapperProfile
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<ProductDto, Supply>();
            CreateMap<ProductDto, Product>();

            CreateMap<OrderDto,Order>();
            CreateMap<ManufacturerDto,Manufacturer>();
            CreateMap<SupplierDto,Supplier>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CharacteristicDto, Characteristic>();
            CreateMap<Supply, SupplyDto>();
        }
    }
}
