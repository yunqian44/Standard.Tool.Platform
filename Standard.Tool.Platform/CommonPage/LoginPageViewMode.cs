using Standard.Tool.Platform.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Standard.Tool.Platform.CommonPage
{
    public class LoginPageViewMode:ObservableObject
    {

        #region 属性

        #region 用户名
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }
        #endregion

        #region 密码
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        #endregion 
        #endregion

        public LoginPageViewMode()
        {
            
        }


        #region 方法

        #region 登录操作
        public void SignInExecute()
        {
            if ("admin".Equals(UserName) && "1111".Equals(Password))
            {
                //MainWindow mainPage = new MainWindow();
                //mainPage.ShowDialog();

            }
        }

        public bool CanSignInExecute()
        {
            return !string.IsNullOrWhiteSpace(UserName)
                &&!string.IsNullOrWhiteSpace(Password);
        }

        public ICommand SignIn
        {
            get { return new RelayCommand(SignInExecute, CanSignInExecute); }
        }
        #endregion 
        #endregion
    }
}
