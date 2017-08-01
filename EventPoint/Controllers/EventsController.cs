using System.Data.Entity;
using EventPoint.DataLayer;
using EventPoint.Models;
using EventPoint.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace EventPoint.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context=new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userid = User.Identity.GetUserId();
            var events = _context.Attendances.
                Where(a => a.AttendeeId == userid).
                Select(a => a.Event).Include(a=>a.Artist).Include(a => a.Genre).ToList();

            var viewModel = new EventViewsModel
            {
                Events = events,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Events I'm Attending"
                
                };


            return View("Events",viewModel);
        }
        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new EventFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel eventViewModel)
        {
            if (!ModelState.IsValid)
            {
                eventViewModel.Genres = _context.Genres.ToList();
                return View("Create", eventViewModel);
            }
            var gigEvent=new Event
            {
               ArtistId = User.Identity.GetUserId(),
               DateTime = eventViewModel.GetDateTime(),
               GenreId = eventViewModel.Genre,
               Venue = eventViewModel.Venue
            };
            _context.Events.Add(gigEvent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}