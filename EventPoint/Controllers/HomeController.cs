using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EventPoint.DataLayer;

namespace EventPoint.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context=new ApplicationDbContext();
            
        }
        public ActionResult Index()
        {
            var upComingEvents=_context.Events.
                Include(g=>g.Artist).
                Where(g => g.DateTime > DateTime.Now);
            return View(upComingEvents);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}