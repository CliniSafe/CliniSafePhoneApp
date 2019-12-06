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
            get
            {
                if (homeMenuItem == null)
                {
                    homeMenuItem = new ObservableCollection<HomeMenuItem>();
                }
                return homeMenuItem;
            }
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

            UpdateHomeMenuItems();
        }

        public void UpdateHomeMenuItems()
        {
            HomeMenuItems.Clear();
            HomeItemMenuServices homeItemMenuServices = new HomeItemMenuServices();
            var newHomeMenuItems = homeItemMenuServices.GetHomeMenuItems();
            foreach (var newMenuItem in newHomeMenuItems)
            {
                HomeMenuItems.Add(newMenuItem);
            }
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

        private bool authenticated;
        public bool Authenticated
        {
            get { return authenticated; }
            set
            {
                authenticated = value;
                OnPropertyChanged("Authenticated");
            }
        }


        public async void MenuNavigation()
        {
            if (SelectedHomeMenuItem == null)
                return;

            var id = (int)(SelectedHomeMenuItem).Id;
            await RootPage.NavigateFromMenu(id, null, null, null);
        }

    }
}
