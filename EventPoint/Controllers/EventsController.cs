using System;
using System.Linq;
using System.Web.Mvc;
using EventPoint.DataLayer;
using EventPoint.Models;
using EventPoint.ViewModels;
using Microsoft.AspNet.Identity;

namespace EventPoint.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context=new ApplicationDbContext();
        }
        //// GET: Event
        public ActionResult Index()
        {
            return View();
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