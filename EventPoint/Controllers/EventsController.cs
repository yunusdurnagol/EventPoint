using System.Linq;
using System.Web.Mvc;
using EventPoint.DataLayer;
using EventPoint.ViewModels;

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


        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(EventFormViewModel eventFormView)
        {
            var eventForm = eventFormView;
            return View("Index");
        }
    }
}