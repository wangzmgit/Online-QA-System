using OnlineQA;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace newOnlineQA.pages
{
    /// <summary>
    /// QA.xaml 的交互逻辑
    /// </summary>
    public partial class QA : Page
    {
        private QuestionList questionList = new QuestionList();
        private QuestionDetails questionDetails = new QuestionDetails();
        public QA()
        {            
            InitializeComponent();
            //NavigationService navigationService = NavigationService.GetNavigationService(this);
            //navigationService.Content = questionList;
            contentControl.Content = new Frame() { Content = questionList };
        }

        private void QuestionListClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Frame() { Content = questionList };
        }

        private void QuestionDetailsClick(object sender, RoutedEventArgs e)
        {
            if(GlobalData.SelectedQuestionId == -1)
            {
                MessageBox.Show("没有选择问题", "加载失败", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            contentControl.Content = new Frame() { Content = questionDetails };
        }
    }
}
