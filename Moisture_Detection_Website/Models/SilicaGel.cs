using System.ComponentModel.DataAnnotations;

namespace Moisture_Detection_Website.Models
{
    public class SilicaGel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TransformerId { get; set; }
        [Required]
        public int RValue { get; set; }
        [Required]
        public int GValue { get; set; }
        [Required]
        public int BValue { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public bool IsCritical { get; set; }
    }
}
