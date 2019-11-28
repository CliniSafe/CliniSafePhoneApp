using CliniSafePhoneApp.Portable.Models;
using System.Collections.ObjectModel;

namespace CliniSafePhoneApp.Portable.Service
{
    public class HomeItemMenuServices
    {
        /// <summary>
        /// Public property for HomeMenuItems
        /// </summary>
        public ObservableCollection<HomeMenuItem> HomeMenuItems { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public HomeItemMenuServices()
        {
            HomeMenuItems = new ObservableCollection<HomeMenuItem>();
        }

        /// <summary>
        /// Returns Home Menu Items.
        /// </summary>
        /// <param name="authenticated"></param>
        /// <returns></returns>
        public ObservableCollection<HomeMenuItem> GetHomeMenuItems(/*bool? authenticated*/)
        {
            return HomeMenuItems = new ObservableCollection<HomeMenuItem> {

                    new HomeMenuItem { Id = MenuItemType.About, Title = "About" },
                    new HomeMenuItem { Id = MenuItemType.Help, Title = "Help" },
                    new HomeMenuItem { Id = MenuItemType.Privacy, Title = "Privacy" },
                    new HomeMenuItem { Id = MenuItemType.Terms, Title = "Terms" },
                    new HomeMenuItem { Id = MenuItemType.TempTest, Title = "Temporary Test Page" }
                    //,
                    //new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" }

                    //(bool)authenticated == true ? new HomeMenuItem { Id = MenuItemType.LogOut, Title = "LogOut" } : new HomeMenuItem { Id = MenuItemType.LogIn, Title = "Login" }
            };
        }
    }
}
