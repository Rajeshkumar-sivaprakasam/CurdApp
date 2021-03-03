using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QsTech.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("UserConnection")
            {

            }

        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}