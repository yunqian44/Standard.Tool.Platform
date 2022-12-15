﻿using MediatR;
using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Auth
{
    public record GetAccountsQuery : IRequest<IList<Account>>;

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IList<Account>>
    {
        private readonly IRepository<AccountEntity> _repo;

        public GetAccountsQueryHandler(IRepository<AccountEntity> repo) => _repo = repo;

        public async Task<IList<Account>> Handle(GetAccountsQuery request, CancellationToken ct)
        {
            return await _repo.SelectAsync(p => new Account
            {
                Id = p.Id,
                CreateTimeUtc = p.CreateTimeUtc,
                LastLoginTimeUtc = p.LastLoginTimeUtc,
                UserName = p.UserName,
                Status = p.Status,
                No = 0
            }, ct);
        }
    }
}
