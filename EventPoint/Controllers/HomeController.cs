using EventPoint.DataLayer;
using EventPoint.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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

            var upComingEvents = _context.Events.Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now).OrderBy(g=>g.DateTime);

            var viewModel = new EventViewsModel
            {
                Events=upComingEvents,
                ShowActions=User.Identity.IsAuthenticated,
                Heading = "All Upcoming Events"
            };
            return View("Events",viewModel);
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