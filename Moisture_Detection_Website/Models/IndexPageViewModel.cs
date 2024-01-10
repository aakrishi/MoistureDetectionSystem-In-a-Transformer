using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moisture_Detection_Website.Models
{
    public class IndexPageViewModel
    {
        public int TotalTransformers { get; set; }
        public int CriticalTransformers { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
        
        public List<SilicaGel> SilicaGelDetails { get; set; }
        
        public string Transformer { get; set; }
    }
}
