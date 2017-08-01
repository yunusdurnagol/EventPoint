using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EventPoint.Models;

namespace EventPoint.DataLayer
{
    public class AttendanceConfiguration:EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new {a.EventId, a.AttendeeId});
             
            Property(a=>a.EventId).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Attendance", 1) { IsUnique = true }));
            Property(a => a.AttendeeId).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Attendance", 2) { IsUnique = true }));
            HasRequired(a=>a.Event).WithMany(a=>a.Attendances).WillCascadeOnDelete(false);
        }
    }
}