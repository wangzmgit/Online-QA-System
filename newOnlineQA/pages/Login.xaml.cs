using OnlineQA;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace newOnlineQA.pages
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void ButtonLoginClick(object sender, RoutedEventArgs e)
        {
            string userName = this.userNameBox.Text;
            string password = this.passwordBox.Password;
            if (userName.Trim() == "")
            {
                MessageBox.Show("用户名不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (password.Trim() == "")
            {
                MessageBox.Show("密码不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string sql = "select uid,name,avatar from users where email = @email and password = @password";
            SqlParameter[] paras =
            {
                 new SqlParameter("@email", userName),
                 new SqlParameter("@password", password)
            };
            SqlDataReader reader = SqlHelper.ExecutReader(sql, paras);
            if(reader.Read())
            {
                //修改信息变量
                GlobalData.Uid = int.Parse(reader[0].ToString());
                GlobalData.UserName = reader[1].ToString();
                string avatarUrl = reader[2].ToString();
                //如果不是默认头像
                if(avatarUrl != "default")
                {
                    GlobalData.Avatar = avatarUrl;
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
