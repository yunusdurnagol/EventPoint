using EventPoint.DataLayer;
using EventPoint.Dtos;
using EventPoint.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace EventPoint.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Takipcis.Any(a => a.FolloweeId == userId && a.FolloweeId == dto.FolloweeId))
                return BadRequest("Takipci already exists");
            var following = new Takipci
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Takipcis.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}