using Castle.Core.Configuration;
using MediatR;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.X509;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using Standard.Tool.Platform.Common.Helper;
using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Data.Import;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Auth.PermissionFeature;

public record UpdateAccountPermissionCommand(Guid Id, EditAccountPermissionRequest Payload) : IRequest<ImportResult>;
public class UpdateAccountPermissionCommandHandler : IRequestHandler<UpdateAccountPermissionCommand, ImportResult>
{
    //private readonly IRepository<AccountPermissionEntity> _repo;

    private readonly IRepository<AccountEntity> _repo;

    public UpdateAccountPermissionCommandHandler(IRepository<AccountEntity> repo) => _repo = repo;
    //{
    //    _accountRepo = accountRepo;
    //    _repo = repo;
    //}

    public async Task<ImportResult> Handle(UpdateAccountPermissionCommand request, CancellationToken ct)
    {
        var insertResult = new ImportResult();

        var (guid, accountPermissionEditModel) = request;
        var account = await _repo.GetAsync(guid, ct);
        if (null == account)
        {
            throw new InvalidOperationException($"Account {guid} is not found.");
        }

        account.AccountPermissions.Clear();
        if (accountPermissionEditModel.SelectedPermissionIds.Any())
        {
            foreach (var cid in accountPermissionEditModel.SelectedPermissionIds)
            {
                account.AccountPermissions.Add(new()
                {
                    AccountId = account.Id,
                    PermissionId = cid
                });
            }
        }

        insertResult.Succeeded = await _repo.UpdateAsync(account, ct) == 1 ? true : false;
        insertResult.Message = insertResult.Succeeded ? string.Empty : "";
        return await Task.FromResult(insertResult);
    }
}
