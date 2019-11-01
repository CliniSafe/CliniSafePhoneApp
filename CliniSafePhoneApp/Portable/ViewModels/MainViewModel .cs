using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class MainViewModel
    {
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage MainPage { get; set; }

        public MainViewModel(MainPage mainPage)
        {
            //MainPage mainPage = new MainPage();


            MainPage = mainPage;

            MainPage.MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.LogIn, (NavigationPage)MainPage.Detail);
        }
    }
}
