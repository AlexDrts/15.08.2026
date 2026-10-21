using System.ComponentModel.DataAnnotations;

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
        [Range(1888, 2030, ErrorMessage = "Рік має бути від 1888 до 2030")]
        [Display(Name = "Рік випуску")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Постер (URL)")]
        public string? PosterPath { get; set; }

        [Required(ErrorMessage = "Додайте опис")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Опис має містити від 10 до 2000 символів")]
        [Display(Name = "Опис")]
        public string? Description { get; set; }
    }
}
