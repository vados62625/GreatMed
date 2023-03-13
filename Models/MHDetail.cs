using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHelp.Models
{
    public class MHDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Титульная картинка")]
        //[ForeignKey("TitleId")]
        public virtual ImageUri? TitlePictire { get; set; }
        [Display(Name = "Дополнительные картинки")]
        //[ForeignKey("ImageUriId")]
        public virtual List<ImageUri>? AdditionalPictures { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Цена")]
        public ulong Price { get; set; }
        [Display(Name = "Категория")]
        public MHCategory? MHCategory { get; set; }
        [Display(Name = "Активность")]
        public bool IsActive { get; set; }
        [Display(Name = "В наличии")]
        public long? InStock { get; set; }
        [Display(Name = "Категория")]
        public int MHCategoryId { get; set; }
    }
}
