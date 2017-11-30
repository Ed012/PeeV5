using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class PeeV5Context : DbContext
    {
        //setear entidades:
        public DbSet<Place> Places { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Course> Courses { get; set; }

        public PeeV5Context() : base("name=PeeV5Context")
        {
        }

       
    }
}
