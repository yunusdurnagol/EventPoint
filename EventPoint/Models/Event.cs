using System;
using System.Collections.Generic;

namespace EventPoint.Models
{
    public class Event
    {
        public int Id { get; set; }         
        public ApplicationUser Artist{ get; set; }
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}