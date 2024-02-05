using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Features.DTOs
{
    public class ProductFeatureDto
    {
        public int Id { get; set; }
        public int Height { get; set; } = default!;
        public int Width { get; set; } = default!;
        public string Color { get; set; } = default!;

    }
}