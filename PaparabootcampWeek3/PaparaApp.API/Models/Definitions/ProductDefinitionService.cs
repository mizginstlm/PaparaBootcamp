using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PaparaApp.API.Models.Definitions.DTOs;
using PaparaApp.API.Models.Shared;
using PaparaApp.API.Models.UnitOfWorks;

namespace PaparaApp.API.Models.Definitions
{
    public class ProductDefinitionService(
    IProductDefinitionRepository productDefinitionRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IProductDefinitionService
    {
        public ResponseDto<ProductDefinitionDto> GetProductDefinitionById(int id)
        {
            var productDefinition = productDefinitionRepository.GetById(id);
            var data = mapper.Map<ProductDefinitionDto>(productDefinition);
            return ResponseDto<ProductDefinitionDto>.Success(data);
        }

        public ResponseDto<int> Save(ProductDefinitionAddDtoRequest request)
        {
            var productDefinition = new ProductDefinition
            {

                StockCount = request.StockCount,
                ProductId = request.ProductId,

            };
            productDefinitionRepository.Save(productDefinition);
            unitOfWork.Commit();

            return ResponseDto<int>.Success(productDefinition.Id);
        }
    }
}