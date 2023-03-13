using System.ComponentModel.DataAnnotations;

namespace MotoHelp.Models
{
    public class MHService
    {
        public MHService() {
            Name = "Новая услуга";
            Price = 0;
            Description= "Описание";
            IsActive = true;
        }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Текст для предпросмотра")]
        public string? PreviewText { get; set; }
        [Display(Name = "Цена")]
        public ushort Price { get; set; }
        [Display(Name = "Активность")]
        public bool IsActive { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Путь к картинке")]
        public virtual ImageUri? TitlePictire { get; set; }
    }
}
