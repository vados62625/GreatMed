using System.ComponentModel.DataAnnotations;

namespace MotoHelp.Models
{
    public class MHCategory
    {
        //public MHDetailCategory(string name) {
        //    Name = name;
        //    Url = Name.Replace(' ', '-').Replace('/', '-');
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Путь к странице")]
        public string? Url { get; set; }
        public ICollection<MHDetail>? Details { get; set; }
    }
}
