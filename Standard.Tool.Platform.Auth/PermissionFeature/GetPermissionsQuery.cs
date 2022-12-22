using MediatR;
using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;
using Standard.Tool.Platform.Common.Helper;


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
            TypeName =p.Type.GetDescription(),
            Status = p.Status,
            No = 0
        }, ct);
    }
}
