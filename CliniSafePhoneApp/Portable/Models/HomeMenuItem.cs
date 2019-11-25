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
        LogOut,
        Project,
        Choice,
        Countries,
        Error,
        FindDrugsForCountry,
        FindDrugsForResearchSite,
        ProjectDetails,
        Questions,
        ResearchSites,
        Results,
        Review,
        SelectedDrugs
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
