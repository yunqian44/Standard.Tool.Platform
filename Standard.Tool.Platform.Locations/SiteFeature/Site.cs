using SixLabors.Fonts.Tables.AdvancedTypographic;
using Standard.Tool.Platform.Data.Entities.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Locations.SiteFeature
{
    public class Site
    {
        public string Name { get; set; }

        public static readonly Expression<Func<SiteEntity, Site>> EntitySelector = t => new()
        {
            Name=t.SiteName
        };

        public static bool ValidateName(string tagDisplayName)
        {
            if (string.IsNullOrWhiteSpace(tagDisplayName)) return false;

            const string pattern = @"[\u4e00-\u9fa5]";
            return !Regex.IsMatch(tagDisplayName, pattern);
        }
    }
}
