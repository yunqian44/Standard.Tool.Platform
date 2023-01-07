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

        #region Account
        public AuthCore.AccountFeature.Account Account {get; set;}
        #endregion

        #endregion

        #region 方法

        #region 01，SelectModule
        void SelectModuleExecute(string permissionId)
        {
            Task.Run(async
                () =>
            {
                var dataList = await _mediator.Send(new ListPermissionsSegmentQuery(Guid.Parse(permissionId)));
                PermissionList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(dataList);


                if (PermissionList == null) return;
                if (Account.Permissions is { Length: > 0 })
                {
                    foreach (var permission in Account.Permissions)
                    {
                        //Page Levels
                        if (PermissionList.Any(u => u.Id == permission.Id))
                            PermissionList.ToList().ForEach(a => { a.IsSelected = true; });

                        //Control Levels
                        PermissionList.ToList().ForEach(a =>
                        {
                            if (a.Childrens is not null && a.Childrens.Count > 0)
                            {
                                if (a.Childrens.Any(u => u.Id == permission.Id))
                                    a.Childrens.ForEach(b => { b.IsSelected = true; });
                            }
                        });
                    }
                }
            });
        }

        bool CanSelectModuleExecute(string permissionId)
        {
            return true;
        }

        public ICommand SelectModule
        {
            get { return new RelayCommand<string>(SelectModuleExecute, CanSelectModuleExecute); }
        }
        #endregion

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
                PermissionList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(dataList.Where(u => u.ParentId != null && u.Type == PermissionType.Page));
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

        #region 03，Closed
        public void CloseExecute()
        {
            ProviderFactory.ServiceProvider?.GetRequiredService<AssignUserPermissionPage>().Close();
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

        #region 04，AccountPermission
        public void QueryAccountById(string userId)
        {
            Task.Run(async
                () =>
            {
                Account = await _mediator.Send(new GetAccountByIdQuery(Guid.Parse(userId)));
                var permissionList = await _mediator.Send(new GetPermissionsQuery());

                ModuleList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(permissionList.Where(u => u.ParentId == null));
                PermissionList = new ObservableCollection<AuthCore.PermissionFeature.Permission>(permissionList.Where(u => u.ParentId != null && u.Type == PermissionType.Page));

                if (PermissionList == null) return;
                if (Account.Permissions is { Length: > 0 })
                {
                    foreach (var permission in Account.Permissions)
                    {
                        //Page Levels
                        if (PermissionList.Any(u => u.Id == permission.Id))
                            PermissionList.ToList().ForEach(a => { a.IsSelected = true; });

                        //Control Levels
                        PermissionList.ToList().ForEach(a =>
                        {
                            if (a.Childrens is not null && a.Childrens.Count > 0)
                            {
                                if (a.Childrens.Any(u => u.Id == permission.Id))
                                    a.Childrens.ForEach(b => { b.IsSelected = true; });
                            }
                        });


                    }
                }

            });
        }
        #endregion

        #endregion
    }
}
