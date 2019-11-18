using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.Views
{
    [DesignTimeVisible(false)]
    public partial class LeftMenuPage : ContentPage
    {
        /// <summary>
        /// Define LeftMenuViewModel.
        /// </summary>
        private LeftMenuViewModel LeftMenuVM;



        //MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        //List<HomeMenuItem> menuItems;




        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public LeftMenuPage()
        {
            InitializeComponent();



            //Initialise LeftMenuViewModel.
            LeftMenuVM = new LeftMenuViewModel();

            ListViewMenu.ItemsSource = LeftMenuVM.HomeMenuItems.Count > 0 ? LeftMenuVM.HomeMenuItems : null;

            //if (ListViewMenu.ItemsSource != null)
            //{
            //    if (ListViewMenu.SelectedItem == null)
            //        ListViewMenu.SelectedItem = LeftMenuVM.HomeMenuItems[0];
            //}

            // Set the Page Binding Context to the LeftMenuViewModel(LeftMenuVM)
            BindingContext = LeftMenuVM;

            //MenuNavigation();
        }



        /// <summary>
        /// Menu Navigation
        /// </summary>
        private void MenuNavigation()
        {
            //ListViewMenu.ItemsSource = LeftMenuVM.menuItems; //menuItems;
            //ListViewMenu.SelectedItem = LeftMenuVM.menuItems[0];

            ListViewMenu.ItemsSource = LeftMenuVM.HomeMenuItems;
            ListViewMenu.SelectedItem = LeftMenuVM.HomeMenuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await LeftMenuVM.RootPage.NavigateFromMenu(id);
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LeftMenuVM.UpdateHomeMenuItems(null);

            ListViewMenu.ItemsSource = LeftMenuVM.HomeMenuItems;
        }
    }
}
