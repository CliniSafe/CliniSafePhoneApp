using CliniSafePhoneApp.Portable.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Views
{
    public partial class MenuPage : ContentPage
    {
        /// <summary>
        /// Define ErrorViewModel.
        /// </summary>
        //ErrorViewModel ErrorVM;

        LoginPage RootPage { get => Application.Current.MainPage as LoginPage; }
        List<HomeMenuItem> menuItems;


        public MenuPage()
        {
            InitializeComponent();

            //Check Internet Connectitivty
            //Constants.CheckConnectivity();

            //Initialise ErrorViewModel.
            //ErrorVM = new ErrorViewModel();

            // Set the Page Binding Context to the ErrorViewModel(ErrorVM)
            //BindingContext = ErrorVM;

            //Set the Image Source
            // cliniSafeImage.Source = "logo.png";

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id=MenuItemType.Login, Title="Login"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id=MenuItemType.Help, Title="Help"},
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Logout" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            MenuNavigation();
        }

        private void MenuNavigation()
        {
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}

