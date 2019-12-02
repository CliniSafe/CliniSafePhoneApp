using CliniSafePhoneApp.Portable.Models;
using CliniSafePhoneApp.Portable.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToQuestionsCommand : ICommand, INotifyPropertyChanged
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }


        public FindDrugsViewModel FindDrugsViewModel { get; set; }

        public NavigateToQuestionsCommand(FindDrugsViewModel findDrugsViewModel)
        {
            FindDrugsViewModel = findDrugsViewModel;
        }


        private GenericDrugsFound selectedDrug;

        public GenericDrugsFound SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                selectedDrug = value;
                OnPropertyChanged("SelectedDrug");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            var selectedDrug = (GenericDrugsFound)parameter;

            if (selectedDrug == null)
                return false;

            if (string.IsNullOrEmpty(selectedDrug.DrugName) || selectedDrug.Drug_ID != 0)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            var selectedDrug = (GenericDrugsFound)parameter;
            FindDrugsViewModel.NavigateToQuestions(selectedDrug);
        }
    }
}

