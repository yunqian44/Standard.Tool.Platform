using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Data.Entities.Project
{
    [SugarTable("XFP_SITES")]
    public class SiteEntity
    {
        [SugarColumn(IsPrimaryKey = true)] //设置主键
        public string SiteName { get; set; }
    }
}
