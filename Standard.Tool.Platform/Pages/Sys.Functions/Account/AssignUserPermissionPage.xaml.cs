using MediatR;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Standard.Tool.Platform.Pages.Account;

/// <summary>
/// AssignUserPermissionPage.xaml 的交互逻辑
/// </summary>
public partial class AssignUserPermissionPage : Window
{
    //IMediator _mediator;
    public AssignUserPermissionPage(IMediator mediator)
    {
        InitializeComponent();
        DataContext = new AssignUserPermissionPageViewModel(mediator);
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }
}
