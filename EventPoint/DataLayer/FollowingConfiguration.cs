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
    public class FollowingConfiguration:EntityTypeConfiguration<Takipci>
    {
        public FollowingConfiguration()
        {

            HasKey(u => new { u.FolloweeId,u.FollowerId});

            Property(a => a.FolloweeId).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Following", 1) { IsUnique = true }));
            Property(a => a.FollowerId).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Following", 2) { IsUnique = true }));
        }
    }
}