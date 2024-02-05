using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Definitions.DTOs
{
    public class ProductDefinitionAddDtoRequest
    {

        [Required(ErrorMessage = "Boş geçilemez!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!")]
        public int StockCount { get; set; }
    }
}