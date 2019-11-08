using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class LeftMenuViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        private ObservableCollection<HomeMenuItem> homeMenuItem;

        public ObservableCollection<HomeMenuItem> HomeMenuItems
        {
            get {
                if (homeMenuItem == null)
                {
                    homeMenuItem = new ObservableCollection<HomeMenuItem>();
                }
                return homeMenuItem; }
            set
            {
                homeMenuItem = value;
                OnPropertyChanged("HomeMenuItems");
            }
        }



        


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LeftMenuViewModel()
        {

            HomeMenuItems = new ObservableCollection<HomeMenuItem>();

            //AddMenuItems(null);

            //HomeMenuItems = new ObservableCollection<HomeMenuItem> {

            //        new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
            //        new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
            //        new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
            //        new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
            //        new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" }
            //    };


            //MenuNavigation();
        }

        public void UpdateHomeMenuItems(bool? authenticated)
        {
            authenticated = authenticated == null ? false : authenticated;
            HomeMenuItems.Clear();
            HomeItemMenuServices homeItemMenuServices = new HomeItemMenuServices();

            //var newHomeMenuItems = authenticated == true ? homeItemMenuServices.GetAuthenticatedHomeMenuItems() : homeItemMenuServices.GetNotAuthentictedHomeMenuItems();

            var newHomeMenuItems = homeItemMenuServices.GetHomeMenuItems(authenticated);
            foreach (var newMenuItem in newHomeMenuItems)
            {
                HomeMenuItems.Add(newMenuItem);
            }
        }




        /// <summary>
        /// Sets the HomeMenuItem values for ListView.
        /// </summary>
        /// <returns></returns>
        //public ObservableCollection<HomeMenuItem> AddMenuItems(bool? authenticated)
        //{

        //    authenticated = (authenticated == null) ? false : (bool)authenticated;
        //    //HomeMenuItems.Clear();
        //    HomeMenuItems = new ObservableCollection<HomeMenuItem> {

        //            new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
        //            new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
        //            new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
        //            new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
        //            new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" },
        //           // new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" }

        //    (bool)authenticated == true ? new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" } : new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" }
        //        };

        //    return HomeMenuItems;
        //}





        private HomeMenuItem selectedHomeMenuItem;

        public HomeMenuItem SelectedHomeMenuItem
        {
            get { return selectedHomeMenuItem; }
            set
            {
                selectedHomeMenuItem = value;
                OnPropertyChanged("SelectedHomeMenuItem");
                if (selectedHomeMenuItem != null)
                    MenuNavigation();
            }
        }


        public async void MenuNavigation()
        {
            if (SelectedHomeMenuItem == null)
                return;

            var id = (int)(SelectedHomeMenuItem).Id;
            await RootPage.NavigateFromMenu(id);
        }

    }
}
