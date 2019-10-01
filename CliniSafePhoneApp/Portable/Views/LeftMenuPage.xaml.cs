using CliniSafePhoneApp.Portable.Models;
using System.Collections.Generic;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class LeftMenuPage : ContentPage
    {
        /// <summary>
        /// Define LeftMenuViewModel.
        /// </summary>
        //LeftMenuViewModel LeftMenuVM;



        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public LeftMenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.LogIn, Title="Login"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"},
                new HomeMenuItem {Id = MenuItemType.Help, Title="Help"},
                new HomeMenuItem {Id = MenuItemType.Privacy, Title="Privacy" },
                new HomeMenuItem {Id = MenuItemType.Terms, Title="Terms" },
                new HomeMenuItem {Id = MenuItemType.TempTest, Title="Temporary Test Page" },
                new HomeMenuItem {Id = MenuItemType.LogOut, Title="LogOut" }
            };

            //ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.SelectedItem = menuItems[0];
            MenuNavigation();


            ////Initialise LeftMenuViewModel.
            //LeftMenuVM = new LeftMenuViewModel();

            //// Set the Page Binding Context to the LeftMenuViewModel(LeftMenuVM)
            //BindingContext = LeftMenuVM;
        }

        private void MenuNavigation()
        {
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
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
