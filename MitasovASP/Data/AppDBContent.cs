using Microsoft.EntityFrameworkCore;
using MitasovASP.Data.Models;
using MitasovASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitasovASP.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        public DbSet<Brick> Brick { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}
