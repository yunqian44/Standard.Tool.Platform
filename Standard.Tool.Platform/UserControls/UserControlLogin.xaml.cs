﻿using Standard.Tool.Platform.CommonPage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Standard.Tool.Platform.UserControls;

/// <summary>
/// LoginView.xaml 的交互逻辑
/// </summary>
public partial class UserControlLogin : UserControl
{
    public UserControlLogin()
    {
        InitializeComponent();
        this.DataContext = new LoginPageViewMode();
    }

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void txtPassword_MouseUp(object sender, MouseButtonEventArgs e)
    {

    }
}
