using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EventPoint.Models;

namespace EventPoint.DataLayer
{
    public class EventConfiguration:EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
             
            Property(e => e.Venue).IsRequired().HasMaxLength(255);
            Property(e => e.ArtistId).IsRequired();
            Property(e => e.GenreId).IsRequired();      
        }
    }
}