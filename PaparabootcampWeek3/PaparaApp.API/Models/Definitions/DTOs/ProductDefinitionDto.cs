using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Definitions.DTOs
{
    public class ProductDefinitionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockCount { get; set; }
    }
}