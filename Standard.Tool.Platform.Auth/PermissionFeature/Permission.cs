﻿using Standard.Tool.Platform.Common.Helper;
using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Security.Policy;
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
        public bool IsSelected { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 模块类型
        /// </summary>
        public PermissionType Type { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifiedTimeUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTimeUtc { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public Permission Parent { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<Permission> Childrens { get; set; }

        public Permission(PermissionEntity entity)
        {
            if (entity is null) return;
            if (entity.Parent is null) return;
            {
                Id = entity.Parent.Id.ToString().Trim();
                Code = entity.Parent.Code;
                ParentId = entity.Parent.ParentId;
                Status = entity.Parent.Status;
                Name = entity.Parent.Name;
                Type = entity.Parent.Type;
                TypeName = entity.Parent.Type.GetDescription();
                CreateTimeUtc = entity.Parent.CreateTimeUtc;
                LastModifiedTimeUtc = entity.Parent.LastModifiedTimeUtc;
            }
        }

        public Permission()
        {

        }
    }

}
