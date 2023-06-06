using Microsoft.EntityFrameworkCore;
using Standard.Tool.Platform.Data.Infrastructure;
using System;

namespace Standard.Tool.Platform.Oracle.Infrastructure
{
    public class OracleDbContextRepository<T> : OrcaleDbContextRepository<T> where T : class
    {
        public OracleDbContextRepository(OracleToolsBlockDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
