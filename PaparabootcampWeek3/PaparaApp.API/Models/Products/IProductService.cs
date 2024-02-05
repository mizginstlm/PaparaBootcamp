﻿using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Products.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Products;

public interface IProductService
{
    ResponseDto<List<ProductDto>> GetAll();

    ProductDto GetById(int id);
    void Delete(int id);
    ResponseDto<int> Add(ProductAddDtoRequest request);

    void Update(ProductUpdateDtoRequest request);

}