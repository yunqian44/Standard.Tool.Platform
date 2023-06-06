using Microsoft.EntityFrameworkCore;
using Standard.Tool.Platform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Oracle
{
    public class OracleToolsBlockDbContext : ToolsBlockOracleDbContext
    {
        public OracleToolsBlockDbContext()
        {
        }

        public OracleToolsBlockDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
