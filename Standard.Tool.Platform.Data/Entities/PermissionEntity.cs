using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Standard.Tool.Platform.Data.Entities
{
    public class PermissionEntity
    {
        public PermissionEntity()
        {
            AccountPermissions = new HashSet<AccountPermissionEntity>();
        }

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
        /// 权限类型
        /// </summary>
        public PermissionType Type { get; set; }

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

        public virtual ICollection<AccountPermissionEntity> AccountPermissions { get; set; }
    }

    public enum PermissionType
    {
        [Description("系统")]
        System = 10,

        [Description("模块")]
        Module = 0,

        [Description("页面")]
        Page = 1
    }

    internal class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(64);
            builder.Property(e => e.Code).HasMaxLength(256);
        }
    }
}
