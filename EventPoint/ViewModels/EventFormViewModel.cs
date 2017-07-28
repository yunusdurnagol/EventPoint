using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using EventPoint.Models;

namespace EventPoint.ViewModels
{
    public class EventFormViewModel
    {
        public string Venue{ get; set; }
        public string Date { get; set; }
        public  string Time { get; set; }
        [DisplayName("Turler")]
        public int Genre { get; set; }
        
        public IEnumerable<Genre> Genres { get; set; }
    }
}