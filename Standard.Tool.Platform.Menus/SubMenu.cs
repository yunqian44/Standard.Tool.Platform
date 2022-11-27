﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Menus
{
    public record SubMenu
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsOpenInNewTab { get; set; }

        public int DisplayOrder { get; set; }
    }
}
