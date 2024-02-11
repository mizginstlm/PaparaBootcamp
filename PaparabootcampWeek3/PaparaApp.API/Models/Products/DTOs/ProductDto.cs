﻿namespace PaparaApp.API.Models.Products.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public string Description { get; set; } = default!;
}

