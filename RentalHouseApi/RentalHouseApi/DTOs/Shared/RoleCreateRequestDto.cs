﻿namespace RentalHouseApi.DTOs
{
    public class RoleCreateRequestDto
    {
        public string UserId { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}