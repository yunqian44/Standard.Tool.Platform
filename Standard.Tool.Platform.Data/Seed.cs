using Microsoft.Extensions.Logging;
using NPOI.POIFS.Properties;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            await dbContext.AccountPermission.AddRangeAsync(GetAccountPermissions());

            await dbContext.SaveChangesAsync();


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
            Id = Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
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
            Id = Guid.Parse("3BD10B0C-EFDC-40B0-A38E-E5DD8C2FAF98"),
            Code="X",
            Name="系统管理",
            ParentId=null,
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Module
        },
        new()
        {
            Id = Guid.Parse("4904BB93-7566-4DB5-A8C4-37195F6BB89A"),
            Code = "PermissionPage",
            Name = "权限信息页面",
            ParentId = Guid.Parse("3BD10B0C-EFDC-40B0-A38E-E5DD8C2FAF98"),
            Status ="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Page
        },
        new()
        {
            Id = Guid.Parse("1602971D-FF47-47AA-8922-C083DA92C783"),
            Code="Permission_Add",
            Name="新增",
            ParentId=Guid.Parse("4904BB93-7566-4DB5-A8C4-37195F6BB89A"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("21591D24-3CA1-4A0F-96AE-4066EAA2876A"),
            Code="Permission_Modify",
            Name="编辑",
            ParentId=Guid.Parse("4904BB93-7566-4DB5-A8C4-37195F6BB89A"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("E8999204-FD67-4FB2-8E1F-378D4A0AF9F0"),
            Code="Permission_Delete",
            Name="删除",
            ParentId=Guid.Parse("4904BB93-7566-4DB5-A8C4-37195F6BB89A"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D"),
            Code="AccountPage",
            Name="用户信息页面",
            ParentId = Guid.Parse("3BD10B0C-EFDC-40B0-A38E-E5DD8C2FAF98"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Page
        },
        new()
        {
            Id = Guid.Parse("F425A720-8FAD-406B-9A49-339C06AF4B42"),
            Code="Account_Add",
            Name="新增",
            ParentId=Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("BACE3D68-FD41-4B25-AD34-127317F56089"),
            Code="AccountPage_Modify",
            Name="编辑",
            ParentId=Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("2B262620-958D-4151-A287-D0A58FB5C87D"),
            Code="Account_Delete",
            Name="删除",
            ParentId=Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D"),
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("96CB6206-E33D-4FF9-98B1-422097E66F80"),
            Code="Account_Assign_Permission",
            ParentId=Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D"),
            Name="权限分配",
            Status="Enable",
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        },
        new()
        {
            Id = Guid.Parse("A00DA36E-8BCC-48AF-A56A-97888BB31028"),
            Code="Y",
            Name="项目级应用",
            Status="Enable",
            ParentId=null,
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Module
        },
        new()
        {
            Id = Guid.Parse("87E3A0A6-43D8-43DD-85A7-56CD2BF93716"),
            Code="MaterialPage",
            Name="物料导入导出",
            Status="Enable",
            ParentId=Guid.Parse("A00DA36E-8BCC-48AF-A56A-97888BB31028"),
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Page
        },
        new()
        {
            Id = Guid.Parse("BEF549AE-CF14-45D6-B436-F8FED891AFC2"),
            Code="Material_Import",
            Name="导入",
            Status="Enable",
            ParentId=Guid.Parse("87E3A0A6-43D8-43DD-85A7-56CD2BF93716"),
            CreateTimeUtc = DateTime.UtcNow,
            LastModifiedTimeUtc=DateTime.UtcNow,
            Type=PermissionType.Control
        }
    };
    }


    private static IEnumerable<AccountPermissionEntity> GetAccountPermissions()
    {
        return new List<AccountPermissionEntity>
    {
        new()
        {
           AccountId=Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
           PermissionId=Guid.Parse("3BD10B0C-EFDC-40B0-A38E-E5DD8C2FAF98")//系统管理
        },
        new()
        {
             AccountId=Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
           PermissionId=Guid.Parse("4904BB93-7566-4DB5-A8C4-37195F6BB89A")//权限信息页面
        },
        new()
        {
            AccountId=Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
           PermissionId=Guid.Parse("1602971D-FF47-47AA-8922-C083DA92C783")//权限信息页面-新增
        },
        new()
        {
             AccountId=Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
           PermissionId=Guid.Parse("21591D24-3CA1-4A0F-96AE-4066EAA2876A")//权限信息页面-编辑
        },
        new()
        {
            AccountId=Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
           PermissionId=Guid.Parse("E8999204-FD67-4FB2-8E1F-378D4A0AF9F0")//权限信息页面-删除
        },
        new()
        {
            AccountId = Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
            PermissionId = Guid.Parse("72AAFD9E-1A80-4A4D-BBE8-FBD593EFB29D")//用户信息页面
        },
        new()
        {
            AccountId = Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
            PermissionId = Guid.Parse("A00DA36E-8BCC-48AF-A56A-97888BB31028")//项目级应用
        },
        new()
        {
            AccountId = Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
            PermissionId = Guid.Parse("87E3A0A6-43D8-43DD-85A7-56CD2BF93716")//物料导入导出
        },
        new()
        {
            AccountId = Guid.Parse("65A50B1F-CB16-4D03-9081-9297BA4AC497"),
            PermissionId = Guid.Parse("BEF549AE-CF14-45D6-B436-F8FED891AFC2")//物料导入导出-导入
        }
    };
    }
}
