using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBdWpf.Model
{
    internal class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
    }
}
