using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class MasterTransfomer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string SubStation { get; set; }
        [Required]
        public string SubStationName { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
