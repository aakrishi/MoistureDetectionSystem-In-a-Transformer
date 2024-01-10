using System.ComponentModel.DataAnnotations;

namespace Moisture_Detection_Website.Models
{
    public class SilicaGelDto
    {
        public int TransformerId { get; set; }
        public double SilicaGelData { get; set; }
        public string ApiKey { get; set; }
    }
}
