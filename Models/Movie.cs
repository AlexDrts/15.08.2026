using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mvc.Validation;

namespace mvc
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть назву")]
        [StringLength(150, ErrorMessage = "Максимум 150 символів")]
        [Display(Name = "Назва")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Вкажіть режисера")]
        [StringLength(100, ErrorMessage = "Максимум 100 символів")]
        [Display(Name = "Режисер")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Вкажіть жанр")]
        [StringLength(100, ErrorMessage = "Максимум 100 символів")]
        [Display(Name = "Жанр")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Вкажіть рік випуску")]
        [Range(1888, 2100, ErrorMessage = "Рік має бути не раніше 1888")]
        [NotFutureYear(ErrorMessage = "Рік випуску не може бути більшим за поточний")]
        [Display(Name = "Рік випуску")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Постер (URL)")]
        public string? PosterPath { get; set; }

        [NotMapped]
        [Display(Name = "Постер (файл з пристрою)")]
        [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp", ".gif", ErrorMessage = "Дозволені лише зображення: jpg, jpeg, png, webp, gif")]
        public IFormFile? PosterFile { get; set; }

        [Required(ErrorMessage = "Додайте опис")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Опис має містити від 10 до 2000 символів")]
        [Display(Name = "Опис")]
        public string? Description { get; set; }
    }
}
