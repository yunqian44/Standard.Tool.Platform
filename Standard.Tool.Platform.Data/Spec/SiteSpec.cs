using Standard.Tool.Platform.Data.Entities.Project;
using Standard.Tool.Platform.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data.Spec
{
    public sealed class SiteSpec : BaseSpecification<SiteEntity>
    {
        public SiteSpec(string sitName) : base(t => t.SiteName == sitName)
        {

        }
    }
}
