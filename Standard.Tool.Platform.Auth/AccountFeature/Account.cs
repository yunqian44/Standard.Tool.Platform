﻿using Standard.Tool.Platform.Auth.PermissionFeature;
using Standard.Tool.Platform.Common.Helper;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Standard.Tool.Platform.Auth.AccountFeature;

public class Account
{
    private int _no;
    /// <summary>
    /// 序号
    /// </summary>
    public int No
    {
        get { return _no; }
        set
        {
            _no = ++value;
        }
    }

    /// <summary>
    /// 是否选中
    /// </summary>
    public int IsSelected { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 登录名
    /// </summary>
    public string LoginName { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    public Permission[] Permissions { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTime? LastLoginTimeUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTimeUtc { get; set; }

    public string Status { get; set; }

    public Account()
    {

    }

    public Account(AccountEntity entity)
    {
        if (null == entity) return;
        Id = entity.Id.ToString().Trim();
        CreateTimeUtc = entity.CreateTimeUtc;
        LastLoginTimeUtc = entity.LastLoginTimeUtc.GetValueOrDefault();
        UserName = entity.UserName.Trim();
        Status = entity.Status.Trim();
        Permissions = entity.AccountPermissions.Select(sm => new Permission
        {
            Id = sm.Permission.Id.ToString().Trim(),
            Name=sm.Permission.Name,
            Type= sm.Permission.Type,
            TypeName=sm.Permission.Type.GetDescription(),
            CreateTimeUtc= sm.Permission.CreateTimeUtc,
            Code = sm.Permission.Code,
            Status = sm.Permission.Status,
            LastModifiedTimeUtc = sm.Permission.LastModifiedTimeUtc,
        }).ToArray();
    }

    public static readonly Expression<Func<AccountEntity, Account>> EntitySelector = p => new()
    {
        Id = p.Id.ToString().Trim(),
        CreateTimeUtc = p.CreateTimeUtc,
        LastLoginTimeUtc = p.LastLoginTimeUtc.GetValueOrDefault(),
        UserName = p.UserName.Trim(),
        Status = p.Status.Trim(),
        Permissions = p.AccountPermissions.Select(sm => new Permission
        {
            Id = sm.Permission.Id.ToString().Trim(),
            Name=sm.Permission.Name,
            Type= sm.Permission.Type,
            TypeName=sm.Permission.Type.GetDescription(),
            CreateTimeUtc= sm.Permission.CreateTimeUtc,
            Code = sm.Permission.Code,
            Status = sm.Permission.Status,
            LastModifiedTimeUtc = sm.Permission.LastModifiedTimeUtc,
        }).ToArray()
    };
}

public class StatusValue
{
    public string? Name { get; set; }

    public string? Value { get; set; }
}
