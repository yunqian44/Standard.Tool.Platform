﻿using Standard.Tool.Platform.Data.Entities.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Materials
{
    public class Material
    {
        [Description("序号")]
        public int No { get; set; }


        [Description("是否选中")]
        public bool IsSelected { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [Description("物料编码")]
        public string CODEART { get; set; }

        [Description("物料名称")]
        public string? DESIGNPRINCIPALE { get; set; }

        [Description("描述")]
        public string? DESIGNLONGUE { get; internal set; }

        [Description("类型")]
        public int CLASSEARTICLE { get; set; }

        [Description("库存单位")]
        public string? UNITESTOCK { get; set; }

        //类型组
        public string? FAMILLE { get; set; }

        //配送工作中心 Y/N
        public string? PESABLECDP { get; set; }

        //配送秤量偏差
        public int? TOLERANCEPESEE { get; set; }
        //制造 Y/N
        public string? PESABLEATELIER { get; set; }
        //制造秤量偏差
        public int? TOLERANCEPESEEATELIER { get; set; }
        //批次混合 Y/N
        public string? MELANGELOT { get; set; }
        //供应商批次混合 Y/N
        public string? MELANGELOTFOURN { get; set; }
        //接收状态Q 检疫/ A 批准/ 条件批准 C/ 测试 E
        public string? STATUTENTREE { get; set; }

        //有效期, 由接口写入
        public int   DUREEVALIDITE { get; set; }
        //有效期单位 J代表天,M代表月由接口写入
        public string? UNITEVALIDITE { get; set; }

        //有效期警告
        public int? ALARMEAVPEREMP { get; set; }
        //DLU警告
        public int? ALARMEAVDLU { get; set; }
        //批次结束百分比
        public double? SEUILFINLOT { get; set; }

        //开启后重新计算有效期 Y/N
        public string? COMPUTE_PEREMPT_OPEN_CONT { get; set; }

        //开启有效期
        public int? PEREMPT_DELAY { get; set; }

        //开启有效期单位 D代表天,M代表月
        public string? PEREMPT_UNIT { get; set; }

        //默认抽样数
        public int? QTEPRELEVEE { get; set; }
        //默认抽数单位
        public string? UNITEPRELEVEE { get; set; }

        //起始位置
        public string? EMPLINIT { get; set; }

        //标准工作中心
        public string? POSTECHARGESTD { get; set; }

        //扩展字段
        public string? Alpha1 { get; set; }
        public double Number1 { get; set; }

        public string? Alpha2 { get; set; }
        public double Number2 { get; set; }

        public string? Alpha3 { get; set; }
        public double Number3 { get; set; }

        public string? Alpha4 { get; set; }
        public double Number4 { get; set; }

        public string? Alpha5 { get; set; }
        public double Number5 { get; set; }

        public string? Alpha6 { get; set; }
        public double Number6 { get; set; }

        public string? Alpha7 { get; set; }
        public double Number7 { get; set; }

        public string? Alpha8 { get; set; }
        public double Number8 { get; set; }


        public Material()
        {
        }
        public Material(MaterialEntity entity) 
        {
            if (entity is null) return;
        }   
    }
}
