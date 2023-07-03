using MediatR;
using Org.BouncyCastle.Asn1.X509;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using Standard.Tool.Platform.Common.Helper;
using Standard.Tool.Platform.Data.Entities.Project;
using Standard.Tool.Platform.Data.Import;
using Standard.Tool.Platform.Data.Infrastructure;
using Standard.Tool.Platform.Locations.SiteFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Locations;

public record CreateLocationDataCommand(EditLocationRequest Payload) : IRequest<ImportResult>;

public class CreateDataCommandHandler : IRequestHandler<CreateLocationDataCommand, ImportResult>
{
    private readonly IRepository<LocationEntity> _locationRepo;

    private readonly IRepository<SiteEntity> _siteRepo;

    public CreateDataCommandHandler(IRepository<LocationEntity> locationRepo, IRepository<SiteEntity> siteRepo)
    {
        _locationRepo = locationRepo;
        _siteRepo = siteRepo;
    }

    public async Task<ImportResult> Handle(CreateLocationDataCommand request, CancellationToken ct)
    {
        var insertResult = new ImportResult();
        if (request.Payload.LocationDataList.Any())
        {
            var dtData = TransHelper<Location, LocationEntity>.TransAutoCopyList(request.Payload.LocationDataList.ToList());


            // add sites
            var sites = 
                request.Payload.LocationDataList.Select(u=>u.Site).ToArray();

            if (sites is { Length: > 0 })
            {
                foreach (var item in sites)
                {
                    if (!Site.ValidateName(item)) continue;

                    var tag = await _siteRepo.GetAsync(q => q.SiteName == item) ?? await CreateSite(item);
                }
            }


            insertResult.Succeeded = await _locationRepo.AddRangeAsync(dtData.ToList()) > 0 ? true : false;
            insertResult.Message = insertResult.Succeeded ? string.Empty : "";
        }

        return await Task.FromResult(insertResult);
    }

    private async Task<SiteEntity> CreateSite(string siteName)
    {
        var newSite = new SiteEntity
        {
            SiteName = siteName
        };

        var tag = await _siteRepo.AddAsync(newSite);
        return tag;
    }
}
