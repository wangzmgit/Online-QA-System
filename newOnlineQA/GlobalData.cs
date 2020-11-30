using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newOnlineQA
{
    /// <summary>
    /// 主要存放一些全局数据
    /// </summary>
    public class GlobalData
    {
        //用户Id
        public static int Uid = -1;
        //选中问题的id
        public static int SelectedQuestionId = -1;
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;   

        //用户名
        private static string userName = "未登录";
        public static string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                //调用通知
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }

        //头像
        private static string avatar = "https://images0506.oss-cn-beijing.aliyuncs.com/avatar/default.jpg";
        public static string Avatar
        {
            get
            {
                return avatar;
            }
            set
            {
                avatar = value;
                //调用通知
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(Avatar)));
            }
        }

    }
}
