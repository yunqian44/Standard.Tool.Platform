using MediatR;
using Org.BouncyCastle.Asn1.X509;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using Standard.Tool.Platform.Data.Entities.Project;
using Standard.Tool.Platform.Data.Infrastructure;
using Standard.Tool.Platform.Data.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Locations.SiteFeature
{
    public record CreateSiteCommand(string Name) : IRequest<Site>;

    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, Site>
    {
        private readonly IRepository<SiteEntity> _repo;

        public CreateSiteCommandHandler(IRepository<SiteEntity> repo) => _repo = repo;

        public async Task<Site> Handle(CreateSiteCommand request, CancellationToken ct)
        {
            if (!Site.ValidateName(request.Name)) return null;


            if (await _repo.AnyAsync(t => t.SiteName == request.Name, ct))
            {
                return await _repo.FirstOrDefaultAsync(new SiteSpec(request.Name), Site.EntitySelector);
            }

            var newSite = new SiteEntity
            {
                SiteName = request.Name
            };

            var site = await _repo.AddAsync(newSite, ct);

            return new()
            {
                Name = site.SiteName
            };
        }
    }
}
