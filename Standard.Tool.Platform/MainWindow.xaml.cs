using MaterialDesignThemes.Wpf;
using Standard.Tool.Platform.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Standard.Tool.Platform
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("客户",new MainWindow1()));
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

          
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((Page)sender);

            if (screen != null)
            {
                StackPanelMain.Content = screen;
            }
        }

        public class ItemMenu
        {
            public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon)
            {
                Header = header;
                SubItems = subItems;
                Icon = icon;
            }

            public string Header { get; private set; }
            public PackIconKind Icon { get; private set; }
            public List<SubItem> SubItems { get; private set; }
            public UserControl Screen { get; private set; }
        }

        public class SubItem
        {
            public SubItem(string name, Page screen = null)
            {
                Name = name;
                Screen = screen;
            }

            public string Name { get; private set; }
            public Page Screen { get; private set; }
        }
    }
}
