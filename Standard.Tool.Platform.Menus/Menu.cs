using Standard.Tool.Platform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace Standard.Tool.Platform.Menus
{
    public class Menu
    {
        public Menu() 
        {
            SubMenus = new();
            Icon = "icon-file-text2";
        }

        public Menu(MenuEntity entity)
        {
            if (entity is null) return;

            Id = entity.Id;
            Title = entity.Title.Trim();
            DisplayOrder = entity.DisplayOrder;
            Icon = entity.Icon?.Trim();
            //Url = entity.Url?.Trim();
            IsOpenInNewTab = entity.IsOpenInNewTab;
            SubMenus = entity.SubMenus.Select(sm => new SubMenu
            {
                Id = sm.Id,
                Title = sm.Title,
                Url = sm.Url,
                IsOpenInNewTab = sm.IsOpenInNewTab
            }).ToList();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public bool IsOpenInNewTab { get; set; }

        public int DisplayOrder { get; set; }

        public List<SubMenu> SubMenus { get; set; }

    }
}
