using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.PostgreSql.Infrastructure
{
    public class PostgreSqlDbContextRepository<T> : DbContextRepository<T> where T : class
    {
        public PostgreSqlDbContextRepository(PostgreSqlToolsBlockDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
