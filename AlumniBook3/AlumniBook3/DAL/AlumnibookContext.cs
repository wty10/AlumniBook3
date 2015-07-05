using AlumniBook3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlumniBook3.DAL
{
    public class AlumnibookContext : DbContext
    {
        public AlumnibookContext()
            : base("AlumnibookContext")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

    }
}