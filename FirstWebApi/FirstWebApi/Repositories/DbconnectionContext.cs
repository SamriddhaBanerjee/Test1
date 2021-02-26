using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FirstWebApi.Repositories
{
    
        public class DbconnectionContext : System.Data.Entity.DbContext

    {

            public DbconnectionContext() : base("DefaultConnection")

            {

            }

            public System.Data.Entity.DbSet<Models.InformationView> Comment { get; set; }

        }

    }
