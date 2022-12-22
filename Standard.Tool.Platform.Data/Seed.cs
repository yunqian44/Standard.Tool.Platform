using Microsoft.Extensions.Logging;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data;

public class Seed
{
    public static async Task SeedAsync(ToolsBlockDbContext dbContext, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;

        try
        {
            await dbContext.Account.AddRangeAsync(GetAccounts());

            await dbContext.Permission.AddRangeAsync(GetPermissions());

            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(e.Message);
            await SeedAsync(dbContext, logger, retryForAvailability);
            throw;
        }
    }

    private static IEnumerable<AccountEntity> GetAccounts()
    {
        return new List<AccountEntity>
    {
        new()
        {
            Id = Guid.NewGuid(),
            UserName = "超级管理员",
            LoginName= "admin",
            PasswordHash = "JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=",
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow
        }
    };
    }

    private static IEnumerable<PermissionEntity> GetPermissions()
    {
        return new List<PermissionEntity>
    {
        new()
        {
            Id = Guid.NewGuid(),
            Code="PermissionPage",
            Name="权限信息页面",
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Page
        }
    };
    }
}
