using OnlineQA;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newOnlineQA.pages
{
    /// <summary>
    /// QuestionList.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionList : Page
    {
        public QuestionList()
        {
            InitializeComponent();
            GetQuestionList();
        }

        /// <summary>
        /// 获取问题列表
        /// </summary>
        void GetQuestionList()
        {
            string sql = "select qid,title,contents from question";  
            DataTable dataTable = SqlHelper.GetDataTable(sql);
            listBox.ItemsSource = dataTable.DefaultView;
        }

        private void ListBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            //获取问题ID（qid）
            DataRowView dataRowView = listBox.SelectedItem as DataRowView;
            string selectedText = dataRowView["qid"].ToString();
            //设置选中的问题id
            GlobalData.SelectedQuestionId = int.Parse(selectedText);

        }
    }
}
