using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Standard.Tool.Platform.Auth.PermissionFeature;

public enum PermissionsSortBy
{
    Recent,
    Featured
}

public sealed class PermissionPagingSpec : BaseSpecification<PermissionEntity>
{
    public PermissionPagingSpec(int pageSize, int pageIndex, Guid? categoryId = null, PermissionsSortBy postsSortBy = PermissionsSortBy.Recent)
        : base(p => !p.Status.Equals("禁用"))
    {
        var startRow = (pageIndex - 1) * pageSize;

        //switch (postsSortBy)
        //{
        //    case PermissionsSortBy.Recent:
        //        ApplyOrderByDescending(p => p.CreateTimeUtc);
        //        break;
        //    case PermissionsSortBy.Featured:
        //        ApplyOrderByDescending(p => p.Type);
        //        break;
        //}
        ApplyPaging(startRow, pageSize);
    }
}
