using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ResultsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define Private Member ResultsViewModel.
        /// </summary>
        private readonly ResultsViewModel ResultsVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ResultsPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ResultsViewModel.
            ResultsVM = new ResultsViewModel();

            // Set the Page Binding Context to the ResultsViewModel(ResultsVM)
            BindingContext = ResultsVM;
        }

        //private void AnotherNavigationButton_Clicked(object sender, System.EventArgs e)
        //{
        //    //NavigationPage navigationPage = new NavigationPage(new ProjectsPage("username", "password"));

        //    _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, null, null, null);
        //}

        //private void CloseNavigationButton_Clicked(object sender, System.EventArgs e)
        //{
        //    // Navigate to the Main page
        //    Application.Current.MainPage = new MainPage();
        //}
    }
}
