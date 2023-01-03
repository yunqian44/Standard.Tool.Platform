using MediatR;
using Standard.Tool.Platform.Auth.AccountFeature;
using Standard.Tool.Platform.Auth.PermissionFeature;
using Standard.Tool.Platform.CommonPage;
using Standard.Tool.Platform.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PermissionCore = Standard.Tool.Platform.Auth.PermissionFeature;

namespace Standard.Tool.Platform.Pages.Permission
{
    public class PermissionPageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public PermissionPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
            RefreshExecute();
            SearchExecute();
        }


        #region Property

        #region PermissionCode
        private string _permissionCode;
        public string PermissionCode
        {
            get { return _permissionCode; }
            set
            {
                _permissionCode = value;
                RaisePropertyChanged(nameof(PermissionCode));
            }
        }
        #endregion

        #region PermissionName
        private string _permissionName;
        public string PermissionName
        {
            get { return _permissionName; }
            set
            {
                _permissionName = value;
                RaisePropertyChanged(nameof(PermissionName));
            }
        }
        #endregion

        #region Status
        private StatusValue _status;
        public StatusValue Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private ObservableCollection<StatusValue> _statusList;
        public ObservableCollection<StatusValue> StatusList
        {
            get { return _statusList; }
            set
            {
                _statusList = value;
                RaisePropertyChanged(nameof(StatusList));
            }
        }
        #endregion

        #region PermissionList
        private ObservableCollection<PermissionCore.Permission> _permissionList;

        public ObservableCollection<PermissionCore.Permission> PermissionList
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



        #region Method

        #region 01，Refresh
        void RefreshExecute()
        {
            PermissionName = string.Empty;
            PermissionCode = string.Empty;

            var statusData = new List<StatusValue>();
            statusData.Add(new StatusValue() { Name = "==请选择==", Value = "" });
            statusData.Add(new StatusValue() { Name = "启用", Value = "Enable" });
            statusData.Add(new StatusValue() { Name = "禁用", Value = "Disable" });

            StatusList = new ObservableCollection<StatusValue>(statusData);

            Status = StatusList?.FirstOrDefault();
        }

        bool CanRefreshExecute()
        {
            return true;
        }

        public ICommand Refresh
        {
            get { return new RelayCommand(RefreshExecute, CanRefreshExecute); }
        }
        #endregion


        #region 02，Search
        void SearchExecute()
        {
            IList<PermissionCore.Permission> dataList = null;
            Task.Run(async
                () =>
            {

                dataList = await _mediator.Send(new GetPermissionsQuery());

                if (dataList != null)
                    PermissionList = new ObservableCollection<PermissionCore.Permission>(dataList);
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


        #endregion
    }
}
