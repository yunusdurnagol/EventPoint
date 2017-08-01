using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventPoint.Models
{
    public class Attendance
    {
        public Event Event { get; set; }
        public ApplicationUser Attendee  { get; set; }
   
        public int EventId { get; set; }
     
        public string AttendeeId { get; set; }
    }
}