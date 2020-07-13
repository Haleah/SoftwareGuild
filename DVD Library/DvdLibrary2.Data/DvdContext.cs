using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary2.Data
{
    public class DvdContext : DbContext
    {
        public DbSet<Dvd> Dvds { get; set; }
        public DvdContext() : base(Settings.GetConnectionString())
        {
        }
    }
}
