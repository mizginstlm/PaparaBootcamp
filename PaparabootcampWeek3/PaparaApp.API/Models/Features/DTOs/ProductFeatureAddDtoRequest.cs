using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Features.DTOs
{
    public class ProductFeatureAddDtoRequest
    {

        public int Height { get; set; } = default!;
        public int Width { get; set; } = default!;
        public string Color { get; set; } = default!;
        public int ProductId { get; set; } = default!;

    }
}