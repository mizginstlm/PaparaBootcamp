using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaApp.API.DTOs
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Adınız 2 ile 10 karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Adınız boş olamaz!")]
        public string UserName { get; set; } = null!;

        [StringLength(10, MinimumLength = 2, ErrorMessage = "Adınız 2 ile 10 karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Adınız boş olamaz!")]
        public string UserSurname { get; set; } = null!;

        [Range(18, 64, ErrorMessage = "Yaşınız 18 ile 64 arasında olmalıdır.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public int UserAge { get; set; }
    }
}