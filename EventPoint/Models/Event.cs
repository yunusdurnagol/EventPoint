﻿using System;

namespace EventPoint.Models
{
    public class Event
    {
        public int Id { get; set; }         
        public ApplicationUser Artist{ get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
    }
}