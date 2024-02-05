
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.Products.DTOs;
using PaparaApp.API.Models.Shared;
using PaparaApp.API.Models.UnitOfWorks;

namespace PaparaApp.API.Models.Products;

public class ProductServiceWithSqlServer(
    IProductRepository productRepository,
    IMapper mapper,
    IProductDefinitionRepository productDefinitionRepository,
    IUnitOfWork unitOfWork, IMemoryCache cache) : IProductService
{
    public ResponseDto<List<ProductDto>> GetAll()
    {

        // var productList = productRepository.GetAll();

        // var productListWithDto = mapper.Map<List<ProductDto>>(productList);

        // return ResponseDto<List<ProductDto>>.Success(productListWithDto);


        //Aside cache pattern
        // key-value
        if (cache.TryGetValue("products", out List<ProductDto>? productListWithCache))
        {
            return ResponseDto<List<ProductDto>>.Success(productListWithCache!);
        }


        var productList = productRepository.GetAll();

        var productListWithDto = mapper.Map<List<ProductDto>>(productList);


        cache.Set("products", productListWithDto, TimeSpan.FromMinutes(1));


        return ResponseDto<List<ProductDto>>.Success(productListWithDto);
    }

    public ProductDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<int> Add(ProductAddDtoRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction();
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price!.Value,
            Description = request.Description,
            CategoryId = request.CategoryId
        };

        productRepository.Add(product);
        unitOfWork.Commit();
        var productDefinition = new ProductDefinition
        {
            StockCount = 100,
            ProductId = product.Id
        };
        productDefinitionRepository.Save(productDefinition);


        unitOfWork.Commit();
        transaction.Commit();
        return ResponseDto<int>.Success(product.Id);
    }

    public void Update(ProductUpdateDtoRequest request)
    {
        throw new NotImplementedException();
    }
}