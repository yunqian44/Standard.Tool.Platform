using Microsoft.EntityFrameworkCore;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data
{
    public class ToolsBlockOracleDbContext : DbContext
    {
        public ToolsBlockOracleDbContext()
        {
        }

        public ToolsBlockOracleDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<MaterialEntity> Material { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfiguration(new SubMenuConfiguration());

        }
    }

    public static class ToolsBlockOrcaleDbContextExtension
    {
        public static async Task ClearAllData(this ToolsBlockOracleDbContext context)
        {
            context.Material.RemoveRange();
            await context.SaveChangesAsync();
        }
    }
}
