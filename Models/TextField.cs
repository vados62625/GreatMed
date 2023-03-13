using System.ComponentModel.DataAnnotations;

namespace MotoHelp.Models
{
    public class TextField
    {
        public TextField() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public string Title { get; set; } = "Информационная страница";

        [Display(Name = "Cодержание страницы")]
        public string Text { get; set; } = "Содержание заполняется администратором";

        [Display(Name = "Краткое описание")]
        public string? Subtitle { get; set; }

        [Display(Name = "Титульная картинка")]
        public ImageUri? TitlePictire { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string? MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string? MetaDescription { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
