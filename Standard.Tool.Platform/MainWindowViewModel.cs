using Standard.Tool.Platform.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Standard.Tool.Platform
{
    public class MainWindowViewModel: ObservableObject
    {
        public MainWindowViewModel() 
        {

        }

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
    }
}
