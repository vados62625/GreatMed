using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHelp.Models
{
    public class ImageUri
    {
        [Key]
        [ForeignKey("MHDetailTitle")]
        public int Id { get; set; }
        public string Uri { get; set; } = null!;
        //public int MHDetailId { get; set; }
        public int? AdditionalMHDetailId { get; set; }
        public int? TitleMHDetailId { get; set; }
        //[ForeignKey("TitleId")]
        [ForeignKey("AdditionalMHDetailId")]
        [InverseProperty("AdditionalPictures")]
        public virtual MHDetail? AdditionalMHDetail { get; set; }
        //[ForeignKey("AdditionalId")]
        [ForeignKey("TitleMHDetailId")]
        [InverseProperty("TitlePictire")]
        public virtual MHDetail TitleMHDetail { get; set; }
    }
}
