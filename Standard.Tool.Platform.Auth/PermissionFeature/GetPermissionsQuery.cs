using MediatR;
using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;
using Standard.Tool.Platform.Common.Helper;
using System.Linq;

namespace Standard.Tool.Platform.Auth.PermissionFeature;

public record GetPermissionsQuery : IRequest<IList<Permission>>;

public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IList<Permission>>
{
    private readonly IRepository<PermissionEntity> _repo;

    public GetPermissionsQueryHandler(IRepository<PermissionEntity> repo) => _repo = repo;

    public async Task<IList<Permission>> Handle(GetPermissionsQuery request, CancellationToken ct)
    {
        return await _repo.SelectAsync(p => new Permission
        {
            Id = p.Id,
            CreateTimeUtc = p.CreateTimeUtc,
            Code=p.Code,
            Name=p.Name,
            Type=p.Type,
            TypeName =p.Type.GetDescription(),
            ParentId=p.ParentId,
            Status = p.Status,
            No = 0,
            Parent = new Permission(p.Parent),
            LastModifiedTimeUtc=p.LastModifiedTimeUtc,
            Childrens= p.Childrens.Select(sm => new Permission
            {
                Id=sm.Id,
                Code=sm.Code,
                Name=sm.Name,
                Type=sm.Type,
                TypeName=sm.Type.GetDescription(),
                ParentId=sm.ParentId,
                Status=sm.Status,
                CreateTimeUtc = sm.CreateTimeUtc,
                LastModifiedTimeUtc = sm.LastModifiedTimeUtc,
            }).ToList()
        }, ct);
    }
}
