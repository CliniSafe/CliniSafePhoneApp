using CliniSafePhoneApp.Portable.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.LogIn, (NavigationPage)Detail);
        }


        public async Task NavigateFromMenu(int id, string username = null, string password = null, object objectParameter = null, ProjectUser projectUser = null, List<QuestionSelectedDrug> reviewQuestionSelectedDrugsList = null, List<GenericDrugsFound> reviewSelectedDrugsList = null)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Username = username;
                Password = password;
            }

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.LogIn:
                        MenuPages.Add(id, new NavigationPage(new LoginPage() { Title = MenuItemType.LogIn.ToString() }));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage() { Title = MenuItemType.About.ToString() }));
                        break;
                    case (int)MenuItemType.Help:
                        MenuPages.Add(id, new NavigationPage(new HelpPage() { Title = MenuItemType.Help.ToString() }));
                        break;
                    case (int)MenuItemType.Privacy:
                        MenuPages.Add(id, new NavigationPage(new PrivacyPage() { Title = MenuItemType.Privacy.ToString() }));
                        break;
                    case (int)MenuItemType.Terms:
                        MenuPages.Add(id, new NavigationPage(new TermsPage() { Title = MenuItemType.Terms.ToString() }));
                        break;
                    case (int)MenuItemType.TempTest:
                        MenuPages.Add(id, new NavigationPage(new TempTestPage() { Title = "Temporary Test Page" }));
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuPages.Add(id, new NavigationPage(new LogOutPage() { Title = MenuItemType.LogOut.ToString() }));
                        break;
                    case (int)MenuItemType.Project:
                        MenuPages.Add(id, new NavigationPage(new ProjectsPage(Username, Password) { Title = MenuItemType.Project.ToString() }));
                        break;
                    case (int)MenuItemType.ProjectDetails:
                        MenuPages.Add(id, new NavigationPage(new ProjectDetailsPage((ProjectUser)objectParameter) { Title = "Project Details" }));
                        break;
                    case (int)MenuItemType.Choice:
                        MenuPages.Add(id, new NavigationPage(new ChoicePage((ProjectUser)objectParameter) { Title = MenuItemType.Choice.ToString() }));
                        break;
                    case (int)MenuItemType.Countries:
                        MenuPages.Add(id, new NavigationPage(new CountriesPage((ProjectUser)objectParameter) { Title = MenuItemType.Countries.ToString() }));
                        break;
                    case (int)MenuItemType.ResearchSites:
                        MenuPages.Add(id, new NavigationPage(new ResearchSitesPage((ProjectUser)objectParameter) { Title = "Research Sites" }));
                        break;
                    case (int)MenuItemType.FindDrugsForCountry:
                        MenuPages.Add(id, new NavigationPage(new FindDrugsPage((CountriesForProjectForMonitorUser)objectParameter, projectUser) { Title = "Find Drugs" }));
                        break;
                    case (int)MenuItemType.FindDrugsForResearchSite:
                        MenuPages.Add(id, new NavigationPage(new FindDrugsPage((ResearchSitesForProjectForInvestigatorUser)objectParameter, projectUser) { Title = "Find Drugs" }));
                        break;
                    case (int)MenuItemType.SelectedDrugs:
                        MenuPages.Add(id, new NavigationPage(new SelectedDrugsPage() { Title = "Selected Drugs" }));
                        break;
                    case (int)MenuItemType.QuestionsForCountry:
                        MenuPages.Add(id, new NavigationPage(new QuestionsPage((CountriesForProjectForMonitorUser)objectParameter, projectUser, reviewSelectedDrugsList) { Title = "Questions" }));
                        break;
                    case (int)MenuItemType.QuestionsForResearchSite:
                        MenuPages.Add(id, new NavigationPage(new QuestionsPage((ResearchSitesForProjectForInvestigatorUser)objectParameter, projectUser, reviewSelectedDrugsList) { Title = "Questions" }));
                        break;
                    case (int)MenuItemType.ReviewResearchSite:
                        MenuPages.Add(id, new NavigationPage(new ReviewPage((ResearchSitesForProjectForInvestigatorUser)objectParameter, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList) { Title = "Review" }));
                        break;
                    case (int)MenuItemType.ReviewCountry:
                        MenuPages.Add(id, new NavigationPage(new ReviewPage((CountriesForProjectForMonitorUser)objectParameter, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList) { Title = "Review" }));
                        break;
                    case (int)MenuItemType.ResultsResearchSite:
                        MenuPages.Add(id, new NavigationPage(new ResultsPage((ResearchSitesForProjectForInvestigatorUser)objectParameter, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList) { Title = "Results" }));
                        break;
                    case (int)MenuItemType.ResultsCountry:
                        MenuPages.Add(id, new NavigationPage(new ResultsPage((CountriesForProjectForMonitorUser)objectParameter, projectUser, reviewQuestionSelectedDrugsList, reviewSelectedDrugsList) { Title = "Results" }));
                        break;
                    case (int)MenuItemType.Error:
                        MenuPages.Add(id, new NavigationPage(new ErrorPage((string)objectParameter) { Title = MenuItemType.Error.ToString() }));
                        break;
                }
            }


            await AddPages(id);

            //var newPage = MenuPages[id];

            //if (newPage != null && Detail != newPage)
            //{
            //    Detail = newPage;

            //    if (Device.RuntimePlatform == Device.Android)
            //        await Task.Delay(100);

            //    IsPresented = false;
            //}
        }

        public async Task AddPages(int id)
        {
            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
