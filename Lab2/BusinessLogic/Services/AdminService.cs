﻿using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Validation;
using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class AdminService
    {
        private readonly SupplyValidator _supplyValidator;
        private readonly SupplierValidator _supplierValidator;
        private readonly ProductValidator _productValidator;
        private readonly ManufacturerValidator _manufacturerValidator;
        private readonly IMapper _mapper;

        public AdminService(
            SupplyValidator supplyValidator,
            ProductValidator productValidator,
            SupplierValidator supplierValidator,
            ManufacturerValidator manufacturerValidator,
            IMapper mapper)
        {
            _supplyValidator = supplyValidator;
            _productValidator = productValidator;
            _supplierValidator = supplierValidator;
            _manufacturerValidator = manufacturerValidator;
            _mapper = mapper;
        }

        private void AddProduct(ProductDto dto)
        {
            Supply supply = _mapper.Map<Supply>(dto);

            _supplyValidator.Add(supply);

            Product product = _mapper.Map<Product>(dto);

            product.SupplyId = supply.Id;

            foreach(var field in dto.Characteristics)
            {
                //Field field = new Field() 
                //{
                //     //CharacteristicId = 
                //     ProductId = product.Id
                //}
            }

            _productValidator.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productValidator.GetById(id);
            _productValidator.Delete(id);
            
        }

        public void AddSupplier(SupplierDto supplierDto)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDto);
            _supplierValidator.Add(supplier);
        }

        public void AddManufaturer(ManufacturerDto manufacturerDto)
        {
            Manufacturer manufaturer = _mapper.Map<Manufacturer>(manufacturerDto);
            _manufacturerValidator.Add(manufaturer);
        }
    }
}
