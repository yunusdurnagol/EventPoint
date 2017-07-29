using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using EventPoint.Models;

namespace EventPoint.ViewModels
{
    public class EventFormViewModel
    {   [Required]
        public string Venue{ get; set; }
        [Required]
        [FutureDate] 
        public string Date { get; set; }
        [Required]
        [ValidTime]
       
        public  string Time { get; set; }

        public DateTime GetDateTime()
        {
             return DateTime.Parse(string.Format("{0} {1}",Date,Time)); 
        }
        [Required]
        [DisplayName("Turler")]
        public byte Genre { get; set; }
        
        public IEnumerable<Genre> Genres { get; set; }
    }
}