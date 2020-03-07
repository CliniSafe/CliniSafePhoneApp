using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class ProjectsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Declare private members
        /// </summary>
        private readonly INavigationService _navigationService;

        private AuthHeader authHeader;
        public AuthHeader AuthHeader
        {
            get { return authHeader; }
            set
            {
                authHeader = value;
                OnPropertyChanged("AuthHeader");
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;

                //Sets the AuthHeader values received from the Login Page.
                AuthHeader = new AuthHeader()
                {
                    Username = this.Username,
                    Password = this.Password,
                    CPAVersion = Constants.CPAVersion
                };
                OnPropertyChanged("Username");
            }
        }

        /// <summary>
        /// Navigate User to the LogOut Page.
        /// </summary>
        public async Task NavigateToLogOut()
        {
            var confirmLogOut = await App.Current.MainPage.DisplayAlert("Log Out", "Are you sure you want to log out?", "Log out", "Cancel");

            if (confirmLogOut)
                _ = RootPage.NavigateFromMenu((int)MenuItemType.LogOut, null, null, null);

            return;
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;

                //Sets the AuthHeader values received from the Login Page.
                AuthHeader = new AuthHeader()
                {
                    Username = this.Username,
                    Password = this.Password,
                    CPAVersion = Constants.CPAVersion
                };
                OnPropertyChanged("Password");
            }
        }

        private string cPAVersion;

        public string CPAVersion
        {
            get { return cPAVersion; }
            set
            {
                cPAVersion = value;

                //Sets the AuthHeader values received from the Login Page.
                AuthHeader = new AuthHeader()
                {
                    Username = this.Username,
                    Password = this.Password,
                    CPAVersion = Constants.CPAVersion
                };

                OnPropertyChanged("CPAVersion");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Declare a private member for NavigateForwardCommand.
        /// </summary>
        public NavigateForwardCommand NavigateForwardCommand { get; set; }


        /// <summary>
        /// Declare a private member for NavigateToLoginCommand.
        /// </summary>
        public NavigateToLoginCommand NavigateToLoginCommand { get; set; }



        public NavigateToProjectDetailCommand NavigateToProjectDetailCommand { get; set; }

        public NavigateToLogOutCommand NavigateToLogOutCommand { get; set; }

        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public ProjectsViewModel(string username, string password)
        {
            AuthHeader = new AuthHeader()
            {
                Username = username,
                Password = password,
                CPAVersion = Constants.CPAVersion
            };


            ProjectUserList = new List<ProjectUser>();


            NavigateToProjectDetailCommand = new NavigateToProjectDetailCommand(this);
            NavigateToLogOutCommand = new NavigateToLogOutCommand(this);

            _navigationService = new NavigationService();

            GetProjectForUserListAsync();
        }


        private List<ProjectUser> projectUserList;

        public List<ProjectUser> ProjectUserList
        {
            get { return projectUserList; }
            set
            {
                projectUserList = value;
                OnPropertyChanged("ProjectUserList");
            }
        }


        private ProjectUser selectedProjectUser;

        public ProjectUser SelectedProjectUser
        {
            get { return selectedProjectUser; }
            set
            {
                selectedProjectUser = value;
                OnPropertyChanged("SelectedProjectUser");
            }
        }


        /// <summary>
        /// Navigate to the project page
        /// </summary>
        /// <param name="projectUser"></param>
        public void NavigateToProjectDetails(ProjectUser projectUser)
        {
            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.ProjectDetails))
                RootPage.MenuPages.Remove((int)MenuItemType.ProjectDetails);

            _ = RootPage.NavigateFromMenu((int)MenuItemType.ProjectDetails, null, null, selectedProjectUser);
        }

        /// <summary>
        /// Logic returns Projects For User from Web Service Proxy Class.
        /// </summary>
        /// <returns></returns>
        public async void GetProjectForUserListAsync()
        {
            ProjectUserList = await ProjectUser.GetProjectsForUserListAysnc(AuthHeader);

            authHeader = AuthHeader.GetAuthHeader();

            if (authHeader.HasIssues)
            {
                if (authHeader.MaintenanceMode)
                    await Constants.DisplayPopUp("Error", authHeader.Message);
                else if (authHeader.CPAVersionExact)
                    if (authHeader.CPANeedsUpdating)
                        await Constants.DisplayPopUp("Error", authHeader.Message);
            }
            else
            {
                LeftMenuViewModel leftMenuViewModel = new LeftMenuViewModel
                {
                    Authenticated = authHeader.Authenticated
                };

                leftMenuViewModel.UpdateHomeMenuItems();


                _ = new MainViewModel
                {
                    Authenticated = authHeader.Authenticated
                };
            }
        }
    }
}
