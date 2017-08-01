using EventPoint.Models;
using System.Collections.Generic;

namespace EventPoint.ViewModels
{
    public class EventViewsModel
    {
        public IEnumerable<Event> Events { get; set; }
        public bool ShowActions{get;set;}
        public string Heading { get; set; }
    }
}