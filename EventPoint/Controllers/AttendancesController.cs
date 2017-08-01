using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventPoint.DataLayer;
using EventPoint.Dtos;
using EventPoint.Models;
using Microsoft.AspNet.Identity;

namespace EventPoint.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context=new ApplicationDbContext();
           
        }
       
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.EventId == dto.EventId))
                return BadRequest("The attendance already exist");
            var attendance = new Attendance
            {
                EventId= dto.EventId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
