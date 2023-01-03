using MediatR;
using Standard.Tool.Platform.Auth.AccountFeature;
using Standard.Tool.Platform.CommonPage;
using Standard.Tool.Platform.Extension;
using Standard.Tool.Platform.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using AuthCore = Standard.Tool.Platform.Auth;
using Standard.Tool.Platform.Auth.PermissionFeature;
using Standard.Tool.Platform.Data.Entities;

namespace Standard.Tool.Platform.Pages.Account
{
    public class AssignUserPermissionPageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AssignUserPermissionPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
            SearchExecute();

            //IEnumerable<TypeValue> list = new List<TypeValue>()
            //{
            //    new() { Name = "用户信息列表", Value = "1",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "编辑", IsSelected=false},new PermissionValue { DisplayName = "新增", IsSelected = false } } },
            //    new() { Name = "权限信息列表", Value = "2" ,Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "新增", IsSelected = false } } },
            //    new() { Name = "角色信息列表", Value = "3",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "删除", IsSelected = false } }  },
            //     new() { Name = "马六", Value = "1",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test4", IsSelected = false } }  },
            //    new() { Name = "田七", Value = "2",Permissions=new List<PermissionValue>{ new PermissionValue {  DisplayName = "Test5", IsSelected = false } }  },
            //    new() { Name = "mama", Value = "3",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test6", IsSelected = false } }  },
            //    new() { Name = "mama", Value = "3",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test7", IsSelected = false } }  },
            //     new() { Name = "baba", Value = "1",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test8", IsSelected = false } }  },
            //    new() { Name = "nainai", Value = "2",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test9", IsSelected = false } }  },
            //    new() { Name = "yeye", Value = "3",Permissions=new List<PermissionValue>{ new PermissionValue { DisplayName = "Test10", IsSelected = false } }  }
            //};
            //ListName = new ObservableCollection<TypeValue>(list);
        }


        #region Property

        #region ModuleList
        private ObservableCollection<AuthCore.PermissionFeature.Permission> _moduleList;

        public ObservableCollection<AuthCore.PermissionFeature.Permission> ModuleList
        {
            get { return _moduleList; }
            set
            {
                _moduleList = value;
                RaisePropertyChanged(nameof(ModuleList));
            }
        }
        #endregion

        #region PermissionList
        private ObservableCollection<AuthCore.PermissionFeature.Permission> _permissionList;

        public ObservableCollection<AuthCore.PermissionFeature.Permission> PermissionList
        {
            get { return _permissionList; }
            set
            {
                _permissionList = value;
                RaisePropertyChanged(nameof(PermissionList));
            }
        }
        #endregion

        #endregion

        #region 方法

        #region 02，Search
        void SearchExecute()
        {
            IList<AuthCore.PermissionFeature.Permission> dataList = null;
            Task.Run(async
                () =>
            {
                dataList = await _mediator.Send(new GetPermissionsQuery());

                if (dataList == null) return;
                ModuleList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(dataList.Where(u => u.ParentId == null));
                PermissionList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(dataList.Where(u=>u.ParentId!=null&&u.Type==PermissionType.Page));
            });
        }

        bool CanSearchExecute()
        {
            return true;
        }

        public ICommand Search
        {
            get { return new RelayCommand(SearchExecute, CanSearchExecute); }
        }
        #endregion

        #region 03，关闭操作
        public void CloseExecute()
        {
            ProviderFactory.ServiceProvider.GetRequiredService<AssignUserPermissionPage>().Close();
        }

        public bool CanCloseExecute()
        {
            return true;
        }

        public ICommand Close
        {
            get { return new RelayCommand(CloseExecute, CanCloseExecute); }
        }
        #endregion 

        #endregion
    }

    public class TypeValue
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public List<PermissionValue> Permissions { get; set; }
    }

    public class PermissionValue
    {
        public bool IsSelected { get; set; }

        public string DisplayName { get; set; }
    }

}
