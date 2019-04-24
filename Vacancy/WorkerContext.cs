using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy
{
    class WorkerContext : DbContext
    {
        public WorkerContext() :
            base("DefaultConnection")
        { }

        public DbSet<Worker> Workers { get; set; }
    }
}
