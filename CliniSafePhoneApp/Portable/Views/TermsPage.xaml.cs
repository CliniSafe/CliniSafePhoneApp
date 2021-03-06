﻿using CliniSafePhoneApp.Portable.Service;
using CliniSafePhoneApp.Portable.ViewModels;
using Xamarin.Forms;


namespace CliniSafePhoneApp.Portable.Views
{
    public partial class TermsPage : ContentPage
    {
        /// <summary>
        /// Define Private Member TermsViewModel.
        /// </summary>
        private readonly TermsViewModel TermsVM;

        public TermsPage()
        {
            InitializeComponent();

            //Initialise TermsViewModel.
            TermsVM = new TermsViewModel();

            // Set the Page Binding Context to the TermsViewModel(TermsVM)
            BindingContext = TermsVM;

            //Set the Image Source
            cliniSafeImage.Source = Constants.CliniSafeImage;
        }
    }
}
