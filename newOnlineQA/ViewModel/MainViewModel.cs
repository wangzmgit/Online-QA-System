using GalaSoft.MvvmLight;
using newOnlineQA.Models;
using System.Collections.ObjectModel;

namespace newOnlineQA.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            menuModels.Add(new MenuModel() { IconFont = "\xe609", Title = "首页" });
            menuModels.Add(new MenuModel() { IconFont = "\xe6ad", Title = "问答" });
            menuModels.Add(new MenuModel() { IconFont = "\xe7f9", Title = "分类" });
            menuModels.Add(new MenuModel() { IconFont = "\xe641", Title = "个人中心" });
        }

        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }
        }
    }
}
