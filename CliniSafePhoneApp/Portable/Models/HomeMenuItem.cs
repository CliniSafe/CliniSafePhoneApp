namespace CliniSafePhoneApp.Portable.Models
{
    public enum MenuItemType
    {
        LogIn,
        About,
        Help,
        Privacy,
        Terms,
        TempTest,
        LogOut
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
