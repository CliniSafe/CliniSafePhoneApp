﻿using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class QuestionsPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        /// <summary>
        /// Define QuestionViewModel.
        /// </summary>
        private readonly QuestionViewModel QuestionVM;


        /// <summary>
        /// Initialise properties in constructor.
        /// </summary>
        public QuestionsPage()
        {
            InitializeComponent();

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;

            // Initialise QuestionViewModel.
            QuestionVM = new QuestionViewModel();

            // Set the Page Binding Context to the QuestionViewModel(QuestionVM)
            BindingContext = QuestionVM;
        }

        private void NextNavigationButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate to the Review page
            _ = RootPage.NavigateFromMenu((int)MenuItemType.Review);
        }
    }
}
