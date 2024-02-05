
using PaparaApp.API.Models.Features.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Features
{
    public interface IProductFeatureService
    {
        ResponseDto<ProductFeatureDto> GetProductFeatureById(int id);
        ResponseDto<int> Save(ProductFeatureAddDtoRequest request);
    }
}