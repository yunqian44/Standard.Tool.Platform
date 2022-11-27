using Microsoft.EntityFrameworkCore;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data
{
    public class ToolsBlockDbContext:DbContext
    {
        public ToolsBlockDbContext()
        {
        }

        public ToolsBlockDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<MenuEntity> Menu { get; set; }
        public virtual DbSet<SubMenuEntity> SubMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new SubMenuConfiguration());
          
        }
    }
}
