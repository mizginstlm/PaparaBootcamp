using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PaparaApp.API.Models.Definitions.DTOs;
using PaparaApp.API.Models.Features.DTOs;
using PaparaApp.API.Models.Shared;
using PaparaApp.API.Models.UnitOfWorks;

namespace PaparaApp.API.Models.Features
{
    public class ProductFeatureService(
    IProductFeatureRepository productFeatureRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IProductFeatureService
    {
        public ResponseDto<ProductFeatureDto> GetProductFeatureById(int id)
        {
            var productFeature = productFeatureRepository.GetById(id);
            var data = mapper.Map<ProductFeatureDto>(productFeature);
            return ResponseDto<ProductFeatureDto>.Success(data);
        }

        public ResponseDto<int> Save(ProductFeatureAddDtoRequest request)
        {
            var productFeature = new ProductFeature
            {
                Height = request.Height,
                Width = request.Width,
                Color = request.Color,
                ProductId = request.ProductId

            };
            productFeatureRepository.Save(productFeature);
            unitOfWork.Commit();

            return ResponseDto<int>.Success(productFeature.Id);
        }
    }
}