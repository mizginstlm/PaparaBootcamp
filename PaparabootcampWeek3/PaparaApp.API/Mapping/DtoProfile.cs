using AutoMapper;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.Definitions.DTOs;
using PaparaApp.API.Models.Features;
using PaparaApp.API.Models.Features.DTOs;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Mapping;

public class DtoProfile : Profile
{
    public DtoProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<ProductDefinition, ProductDefinitionDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();

    }
}