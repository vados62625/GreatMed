using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MotoHelp.Models
{
    public class RequestedCall
    {
        public RequestedCall() {
            DateTime = DateTime.Now;
            IsProcessed = false;
        }
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsProcessed { get; set; }
    }
}
