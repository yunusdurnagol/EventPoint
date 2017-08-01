using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EventPoint.Models;

namespace EventPoint.DataLayer
{
    public class ApplicationUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {

 

            HasMany(u => u.Followers)
                .WithRequired(f => f.Followee).
                WillCascadeOnDelete(false);

                HasMany(u => u.Followees)
                .WithRequired(f => f.Follower).
                WillCascadeOnDelete(false);
        }
    }
}