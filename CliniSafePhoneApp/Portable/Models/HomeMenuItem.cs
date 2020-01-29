using System.ComponentModel;

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
        QuestionsForCountry,
        QuestionsForResearchSite,
        ResearchSites,
        Results,
        Review,
        SelectedDrugs
    }


    public class HomeMenuItem : INotifyPropertyChanged
    {
        private MenuItemType id;

        public MenuItemType Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
