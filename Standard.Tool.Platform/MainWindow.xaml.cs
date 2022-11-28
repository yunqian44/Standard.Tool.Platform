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
        private MainWindowViewModel _mainWindowViewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel(this.WindowMain);
            DataContext = _mainWindowViewModel;
        }

        internal void SwitchScreen(object sender)
        {
            _mainWindowViewModel.SwitchScreen(sender);
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

        private void WindowMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
