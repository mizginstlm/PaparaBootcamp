using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaparaApp.API.Models.Definitions.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Definitions
{
    public interface IProductDefinitionService
    {
        ResponseDto<ProductDefinitionDto> GetProductDefinitionById(int id);
        ResponseDto<int> Save(ProductDefinitionAddDtoRequest request);
    }
}