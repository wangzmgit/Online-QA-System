using newOnlineQA.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace newOnlineQA
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseDown += (sender, e) =>
            {
                //允许拖动
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };
            this.DataContext = new MainViewModel();
            //默认选择
            this.list.SelectedIndex = 0;
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnMaxClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }
        private void BtnMinClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnLoginClick(object sender, RoutedEventArgs e)
        {
            pages.Login login = new pages.Login();
            //如果用户id不为-1（说明已登录）禁用登录按钮，否则跳转登录页面
            if (GlobalData.Uid != -1)
            {
                //btnLogin.IsEnabled = false;
                this.list.SelectedIndex = 3;
            }
            else
            {
                ContentControl.Content = new Frame() { Content = login };
                btnRegister.Visibility = Visibility.Hidden;
            }
               
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            pages.Register register = new pages.Register();
            ContentControl.Content = new Frame() { Content = register };
            btnRegister.Visibility = Visibility.Hidden;
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pages.Home home = new pages.Home();
            pages.QA qAndA = new pages.QA();
            pages.Category category = new pages.Category();
            pages.User user = new pages.User();
            switch (this.list.SelectedIndex)
            {
                case 0:
                    ContentControl.Content = new Frame() { Content = home };
                    break;
                case 1:
                    ContentControl.Content = new Frame() { Content = qAndA };
                    break;
                case 2:
                    ContentControl.Content = new Frame() { Content = category };
                    break;
                case 3:
                    ContentControl.Content = new Frame() { Content = user };
                    break;
            }

        }
    }
}
