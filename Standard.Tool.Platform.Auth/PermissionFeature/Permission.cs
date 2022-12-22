using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Auth.PermissionFeature
{
    public class Permission
    {
        private int _no;
        /// <summary>
        /// 序号
        /// </summary>
        public int No
        {
            get { return _no; }
            set
            {
                _no = ++value;
            }
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        public int IsSelected { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifiedTimeUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTimeUtc { get; set; }
    }
}
