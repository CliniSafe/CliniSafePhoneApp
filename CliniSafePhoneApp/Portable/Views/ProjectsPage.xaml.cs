using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class ProjectsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define ProjectsViewModel.
        /// </summary>
        private ProjectsViewModel ProjectsVM;

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ProjectsPage(string username, string password)
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise ProjectsViewModel.
            ProjectsVM = new ProjectsViewModel(username, password);

            // Set the Page Binding Context to the ProjectsViewModel(ProjectsVM)
            BindingContext = ProjectsVM;
        }
    }
}
