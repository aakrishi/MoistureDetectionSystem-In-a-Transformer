using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moisture_Detection_Website.Data;
using Moisture_Detection_Website.Models;
using System.Diagnostics;

namespace Moisture_Detection_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var transformers = _context.MasterTransfomers.ToList();
            var silicageldetails = _context.SilicaGelDetails.ToList();

            IndexPageViewModel i = new IndexPageViewModel();
            i.TotalTransformers = transformers?.FindAll(x=>x.Status == true).Count()??0;
            i.CriticalTransformers = silicageldetails?.FindAll(x=>x.IsCritical == true && x.Status == true).Select(x=>x.TransformerId).Distinct().Count()??0;
            //i.Regions = transformers?.FindAll(x => x.Status == true).Select(x=>x.Region).Distinct().ToList();
            i.Regions = transformers?.Select(u => new SelectListItem { Text = $"{u.Region}-{u.SubStation}-{u.ID}", Value = u.ID.ToString() }).Distinct().ToList();

            i.SilicaGelDetails = null;


            return View(i);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string Transformer)
        {
            var transformers = _context.MasterTransfomers.ToList();
            var silicageldetails = _context.SilicaGelDetails.ToList();

            IndexPageViewModel i = new IndexPageViewModel();
            i.TotalTransformers = transformers?.FindAll(x => x.Status == true).Count() ?? 0;
            i.CriticalTransformers = silicageldetails?.FindAll(x => x.IsCritical == true && x.Status == true).Select(x => x.TransformerId).Distinct().Count() ?? 0;
            //i.Regions = transformers?.FindAll(x => x.Status == true).Select(x=>x.Region).Distinct().ToList();
            i.Regions = transformers?.Select(u => new SelectListItem { Text = $"{u.Region}-{u.SubStation}-{u.ID}", Value = u.ID.ToString() }).Distinct().ToList();
            

            i.SilicaGelDetails = silicageldetails?.FindAll(x=>x.TransformerId == Convert.ToInt32(Transformer) && x.Status == true).OrderByDescending(x=>x.CreatedOn).ToList();

            return View(i);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
