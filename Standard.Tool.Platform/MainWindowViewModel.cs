using MaterialDesignThemes.Wpf;
using Standard.Tool.Platform.MVVM;
using Standard.Tool.Platform.Common;
using Standard.Tool.Platform.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Standard.Tool.Platform.MainWindow;

namespace Standard.Tool.Platform
{
    public class MainWindowViewModel: ObservableObject
    {
        public MainWindowViewModel() 
        {

        }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("标准脚本导入", new MainWindow1()));
            menuRegister.Add(new SubItem("标准脚本导出"));
            menuRegister.Add(new SubItem("标准设备导入"));
            menuRegister.Add(new SubItem("标准设备导出"));
            menuRegister.Add(new SubItem("标准PI导入"));
            menuRegister.Add(new SubItem("标准PI导出"));
            menuRegister.Add(new SubItem("数据库对象导入"));
            menuRegister.Add(new SubItem("数据库对象导出"));
            menuRegister.Add(new SubItem("XFP参数导入"));
            menuRegister.Add(new SubItem("XFP参数导出"));
            var item1 = new ItemMenu("标准库导入导出", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("用户批量导入"));
            menuSchedule.Add(new SubItem("客制化权限导入"));
            menuSchedule.Add(new SubItem("物料主数据导入"));
            menuSchedule.Add(new SubItem("物料清单倒入"));
            menuSchedule.Add(new SubItem("位置导入"));
            menuSchedule.Add(new SubItem("设备数据导入"));
            menuSchedule.Add(new SubItem("参数管理功能"));
            menuSchedule.Add(new SubItem("打印机配置信息迁移"));
            menuSchedule.Add(new SubItem("称配信息迁移"));
            var item2 = new ItemMenu("项目级应用功能", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("西塘日志在线查看"));
            menuReports.Add(new SubItem("数据源配置"));
            menuReports.Add(new SubItem("翻译修改"));
            menuReports.Add(new SubItem("个人信息设置"));
            var item3 = new ItemMenu("其他功能", menuReports, PackIconKind.Mother);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("用户管理"));
            var item4 = new ItemMenu("工具管理", menuExpenses, PackIconKind.Tools);



            mainWindow.Menu.Children.Add(new UserControlMenuItem(item1, mainWindow));
            mainWindow.Menu.Children.Add(new UserControlMenuItem(item2, mainWindow));
            mainWindow.Menu.Children.Add(new UserControlMenuItem(item3, mainWindow));
            mainWindow.Menu.Children.Add(new UserControlMenuItem(item4, mainWindow));
            mainWindow.Menu.Children.Add(new UserControlMenuItem(item4, mainWindow));
        }

        #region Property

        #region Page Name
        private string _pageName;
        public string PageName
        {
            get { return _pageName; }
            set
            {
                _pageName = value;
                RaisePropertyChanged("PageName");
            }
        }
        #endregion

        #region Page Version
        private string _pageVersion;
        public string PageVersion
        {
            get { return _pageVersion; }
            set
            {
                _pageVersion = value;
                RaisePropertyChanged("PageVersion");
            }
        }
        #endregion

        #region Current Page
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                if (value != null)
                {
                    PageName = value.Title;
                    string strVer = "";
                    foreach (Attribute attr in value.GetType().GetCustomAttributes(true))
                    {
                        if (attr is UIModuleMatadataAttribute)
                        {
                            if (attr != null)
                            {
                                strVer = (attr as UIModuleMatadataAttribute).Version;
                                break;
                            }
                        }
                    }
                    PageVersion = strVer;
                }
                else
                {
                    PageName = "";
                    PageVersion = "";
                }
                RaisePropertyChanged("CurrentPage");
            }
        }
        #endregion
        #endregion

        #region Method

        #region 01，Navigation Page
        internal void SwitchScreen(object sender)
        {
            var screen = ((Page)sender);

            if (screen != null)
            {
                CurrentPage = screen;
            }
        }
        #endregion

        #region 02，SignOut
        void SignOutExecute(MainWindow window)
        {
            window.Close();
        }

        bool CanSignOutExecute(MainWindow window)
        {
            return true;
        }

        public ICommand SignOut
        {
            get { return new RelayCommand<MainWindow>(SignOutExecute, CanSignOutExecute); }
        }
        #endregion 

        #endregion
    }
}
