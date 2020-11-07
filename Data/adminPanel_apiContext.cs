using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using adminPanel_api.Model;

namespace adminPanel_api.Data
{
    public class adminPanel_apiContext : DbContext
    {
        public adminPanel_apiContext (DbContextOptions<adminPanel_apiContext> options)
            : base(options)
        {
        }

        public DbSet<adminPanel_api.Model.AppConfigurate> AppConfigurate { get; set; }
    }
}
