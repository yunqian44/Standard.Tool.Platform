using Microsoft.EntityFrameworkCore;
using Standard.Tool.Platform.Data;
using System;
using System.Reflection.Emit;

namespace Standard.Tool.Platform.PostgreSql
{
    public class PostgreSqlBlogDbContext : ToolsBlockDbContext
    {
        public PostgreSqlBlogDbContext()
        {
        }

        public PostgreSqlBlogDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
