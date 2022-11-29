using Standard.Tool.Platform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Standard.Tool.Platform.MainWindow;

namespace Standard.Tool.Platform.UserControls
{
    /// <summary>
    /// UserControlMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
            var types = assembly.ExportedTypes;
            var screenName = ((SubItem)((ListView)sender).SelectedItem).ScreenName;

            string fullName = "";
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.Name.Equals(screenName))
                {
                    fullName = type.FullName;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(fullName))
            {
                var screen = assembly.CreateInstance(fullName); //通过制定类完全限定名，动态获取对象实例

                _context.SwitchScreen(screen);
            }
        }
    }
}
