﻿using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels.Commands;
using CliniSafePhoneApp.Portable.Views;
using System.Collections.Generic;
using System.ComponentModel;
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


        //private bool hasIssues;

        //public bool HasIssues
        //{
        //    get { return hasIssues; }
        //    set
        //    {
        //        hasIssues = value;
        //        OnPropertyChanged("HasIssues");
        //    }
        //}

        //private bool maintenanceMode;

        //public bool MaintenanceMode
        //{
        //    get { return maintenanceMode; }
        //    set
        //    {
        //        maintenanceMode = value;
        //        OnPropertyChanged("MaintenanceMode");
        //    }
        //}

        //private bool cPAVersionExact;

        //public bool CPAVersionExact
        //{
        //    get { return cPAVersionExact; }
        //    set
        //    {
        //        cPAVersionExact = value;
        //        OnPropertyChanged("CPAVersionExact");
        //    }
        //}

        //private bool cPANeedsUpdating;

        //public bool CPANeedsUpdating
        //{
        //    get { return cPANeedsUpdating; }
        //    set
        //    {
        //        cPANeedsUpdating = value;
        //        OnPropertyChanged("CPANeedsUpdating");
        //    }
        //}

        //private int messageCode;

        //public int MessageCode
        //{
        //    get { return messageCode; }
        //    set
        //    {
        //        messageCode = value;
        //        OnPropertyChanged("MessageCode");
        //    }
        //}

        //private string message;

        //public string Message
        //{
        //    get { return message; }
        //    set
        //    {
        //        message = value;
        //        OnPropertyChanged("Message");
        //    }
        //}


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

            //NavigateForwardCommand = new NavigateForwardCommand(this);
            //NavigateToLoginCommand = new NavigateToLoginCommand(this);


            ProjectUserList = new List<ProjectUser>();


            NavigateToProjectDetailCommand = new NavigateToProjectDetailCommand(this);
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
                //foreach (ProjectUser projectUser in ProjectUserList)
                //{

                //    new ProjectUser()
                //    {
                //        ProjectCode = projectUser.ProjectCode,
                //        ProjectTitleShortPhoneDisplay = projectUser.ProjectTitleShortPhoneDisplay
                //    };
                //}
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
                new ProjectUser()
                {
                    ProjectCode = SelectedProjectUser.ProjectCode,
                    ProjectTitleShort = SelectedProjectUser.ProjectTitleShort
                };
                OnPropertyChanged("SelectedProjectUser");
            }
        }




        //private string projectCode;

        //public string ProjectCode
        //{
        //    get { return projectCode; }
        //    set
        //    {
        //        projectCode = value;
        //        OnPropertyChanged("ProjectCode");
        //    }
        //}

        //private string projectTitleShort;

        //public string ProjectTitleShort
        //{
        //    get { return projectTitleShort; }
        //    set
        //    {
        //        projectTitleShort = value;
        //        //foreach (var projectUser in ProjectUserList)
        //        //{

        //        //    new ProjectUser()
        //        //    {
        //        //        ProjectCode = projectUser.ProjectCode,
        //        //        ProjectTitleShort = projectUser.ProjectTitleShort
        //        //    };
        //        //}
        //        OnPropertyChanged("ProjectTitleShort");
        //    }
        //}


        public void NavigateToProjectDetails(ProjectUser projectUser)
        {


            if (RootPage.MenuPages.ContainsKey((int)MenuItemType.ProjectDetails))
                RootPage.MenuPages.Remove((int)MenuItemType.ProjectDetails);

            // Navigate to the project page
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


            //LeftMenuViewModel leftMenuViewModel = new LeftMenuViewModel();
            //leftMenuViewModel.AddMenuItems(authHeader.Authenticated);








            //return ProjectUserList;
            if (ProjectUserList != null)
            {
                if (authHeader != null)
                {
                    LeftMenuViewModel leftMenuViewModel = new LeftMenuViewModel();
                    leftMenuViewModel.UpdateHomeMenuItems(authHeader.Authenticated);
                }

                selectedProjectUser = null;

                // Navigate to the project page

                //RootPage.MainVM.MenuPages.Add((int)MenuItemType.Project, new NavigationPage(new ProjectsPage(authHeader.Username, authHeader.Password) { Title = MenuItemType.Project.ToString() }));



                _ = RootPage.NavigateFromMenu((int)MenuItemType.Project);


                //MenuPages.Add(id, new NavigationPage(new ProjectsPage(username, password) { Title = MenuItemType.Project.ToString() }));

                //RootPage.MainVM.MainPage.AddPages((int)MenuItemType.Project);

            }

















            //leftMenuViewModel.HomeMenuItems.Add(_ = new HomeMenuItem(){ Id = MenuItemType.LogOut, Title = MenuItemType.LogOut.ToString() });



            ////return ProjectUserList;
            //if (ProjectUserList != null)

            //    // Navigate to the project page
            //    _ = RootPage.NavigateFromMenu((int)MenuItemType.Project, Username, Password);










            //_navigationService.NavigateToSecondPage(new ProjectsPage() { Title = "Projects" });

            //authHeader = AuthHeader.GetAuthHeader();

            //if (authHeader.HasIssues)
            //    if (authHeader.MaintenanceMode)
            //        await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
            //    else if (authHeader.CPAVersionExact)
            //        if (authHeader.CPANeedsUpdating)
            //            await App.Current.MainPage.DisplayAlert("Error", authHeader.Message, "OK");
        }



        //public async void CheckHandshake()
        //{
        //    if (HandshakeHeader == null)
        //        HandshakeHeader = new HandshakeHeader()
        //        {
        //            CPAVersion = Constants.CPAVersion
        //        };

        //    HandshakeResult = await HandshakeHeader.HandShakeAsync(HandshakeHeader);
        //    NavigateForward();
        //}


        /// <summary>
        /// Navigates back to the HandShake Page(HandShakePage).
        /// </summary>
        /// <returns></returns>
        //public void NavigateForward()
        //{
        //    if (ProjectForUserResult != null)
        //        if (ProjectForUserResult == "An unknown Error occurred during GetProjectsForUser. Please Contact CliniSafe For further details.")
        //            //return;  //Stay at the HandShakePage
        //            _navigationService.NavigateToSecondPage(new ProjectPage());
        //        else
        //            _navigationService.NavigateToSecondPage(new NavigationPage(new ErrorPage() { Title = "Error" }));
        //    else
        //        _navigationService.NavigateToSecondPage(new NavigationPage(new ErrorPage() { Title = "Error" }));
        //}

        /// <summary>
        /// Navigates back to the Login Page(LoginPage).
        /// </summary>
        /// <returns></returns>
        //public void NavigateForwardToLogin()
        //{
        //    //_navigationService.NavigateToSecondPage(new NavigationPage(new LoginPage()));

        //    _navigationService.NavigateToSecondPage(new MainPage());
        //}
    }
}
