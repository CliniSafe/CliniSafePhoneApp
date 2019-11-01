using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class LeftMenuViewModel : INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private ObservableCollection<HomeMenuItem> homeMenuItem;

        public ObservableCollection<HomeMenuItem> HomeMenuItems
        {
            get { return homeMenuItem; }
            set
            {
                homeMenuItem = value;
                OnPropertyChanged("HomeMenuItems");
            }
        }

        //public ObservableCollection<HomeMenuItem> MenuList { get; set; }
        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LeftMenuViewModel()
        {

            HomeMenuItems = new ObservableCollection<HomeMenuItem>();

            AddMenuItems(null);

            //HomeMenuItems = new ObservableCollection<HomeMenuItem> {

            //        new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
            //        new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
            //        new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
            //        new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
            //        new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" }
            //    };


            //MenuNavigation();
        }




        /// <summary>
        /// Sets the HomeMenuItem values for ListView.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<HomeMenuItem> AddMenuItems(bool? authenticated)
        {

            authenticated = (authenticated == null) ? false : (bool)authenticated;
            HomeMenuItems.Clear();
            HomeMenuItems = new ObservableCollection<HomeMenuItem> {

                    new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
                    new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
                    new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
                    new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
                    new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" },
                    (bool)authenticated == true ? new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" } : new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" }
                };


            if ((bool)authenticated)
            {
                HomeMenuItems.Remove(new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" });
                HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" });
            }

            //HomeMenuItems.Add(authenticated == true ? new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" } : new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" });

            //if ((bool)authenticated)
            //{
            //    if (HomeMenuItems.Count != 0)
            //    { HomeMenuItems.Clear(); }

            //    if (HomeMenuItems.Count == 0)
            //    {

            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.About, Title = "About" });
            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" });
            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" });
            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" });
            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" });
            //        HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" });

            //    }
            //}
            //else
            //{
            //    //HomeMenuItems = new ObservableCollection<HomeMenuItem> {
            //    //        new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
            //    //        new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
            //    //        new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
            //    //        new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
            //    //        new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" },
            //    //        new HomeMenuItem { Id = MenuItemType.LogIn, Title = "LogIn" }
            //    //    };


            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.About, Title = "About" });
            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" });
            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" });
            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" });
            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" });
            //    HomeMenuItems.Add(new HomeMenuItem { Id = MenuItemType.LogIn, Title = "LogIn" });
            //}

            //if (authenticated)
            //{
            //    HomeMenuItems = new List<HomeMenuItem> {

            //        new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
            //        new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
            //        new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
            //        new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
            //        new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" },
            //        new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" }
            //    };
            //}
            //else
            //{
            //    HomeMenuItems = new List<HomeMenuItem> {
            //        new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" },
            //        new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
            //        new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
            //        new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
            //        new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
            //        new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" }
            //    };
            //}

            return HomeMenuItems;
        }





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
