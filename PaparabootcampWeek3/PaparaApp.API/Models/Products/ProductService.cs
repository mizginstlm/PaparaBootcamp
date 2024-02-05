﻿using AutoMapper;
using PaparaApp.API.Exceptions;
using PaparaApp.API.Models.Products.DTOs;
using PaparaApp.API.Models.Shared;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Products;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly ProductHelper _productHelper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository, ProductHelper productHelper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _productHelper = productHelper;
    }

    public void Update(ProductUpdateDtoRequest request)
    {
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price
        };

        _productRepository.Update(product);
    }

    public void Delete(int id)
    {
        _productHelper.CalculateTax(200);
        _productRepository.Delete(id);
    }

    public ResponseDto<List<ProductDto>> GetAll()
    {
        var products = _productRepository.GetAll();

        var productDtos = _mapper.Map<List<ProductDto>>(products);

        return ResponseDto<List<ProductDto>>.Success(productDtos);
    }

    public ResponseDto<int> Add(ProductAddDtoRequest request)
    {
        var id = new Random().Next(1, 1000);


        var product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price!.Value
        };

        _productRepository.Add(product);
        return ResponseDto<int>.Success(id);
    }

    public ProductDto GetById(int id)
    {
        var product = _productRepository.GetById(id);

        return _mapper.Map<ProductDto>(product);
    }
}