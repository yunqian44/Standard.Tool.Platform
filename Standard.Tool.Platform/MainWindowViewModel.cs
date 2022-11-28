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
            menuRegister.Add(new SubItem("客户", new MainWindow1()));
            menuRegister.Add(new SubItem("供应商"));
            menuRegister.Add(new SubItem("员工"));
            menuRegister.Add(new SubItem("产品"));
            var item1 = new ItemMenu("登记", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("服务"));
            menuSchedule.Add(new SubItem("会议"));
            var item2 = new ItemMenu("预约", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("客户"));
            menuReports.Add(new SubItem("供应商"));
            menuReports.Add(new SubItem("产品"));
            menuReports.Add(new SubItem("库存"));
            menuReports.Add(new SubItem("销售额"));
            var item3 = new ItemMenu("报告", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("固定资产"));
            menuExpenses.Add(new SubItem("流动资金"));
            var item4 = new ItemMenu("费用", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("现金流"));
            var item5 = new ItemMenu("财务", menuFinancial, PackIconKind.ScaleBalance);


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
