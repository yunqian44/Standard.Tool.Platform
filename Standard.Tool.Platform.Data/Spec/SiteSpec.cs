using Standard.Tool.Platform.Data.Entities.Project;
using Standard.Tool.Platform.Data.Infrastructure;

namespace Standard.Tool.Platform.Data.Spec;

public sealed class SiteSpec : BaseSpecification<SiteEntity>
{
    public SiteSpec(string sitName) : base(t => t.SiteName == sitName)
    {

    }
}
