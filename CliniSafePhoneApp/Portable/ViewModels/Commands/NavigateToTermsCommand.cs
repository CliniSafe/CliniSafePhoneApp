﻿using System;
using System.Windows.Input;

namespace CliniSafePhoneApp.Portable.ViewModels.Commands
{
    public class NavigateToTermsCommand : ICommand
    {
        public ErrorViewModel _errorViewModel { get; set; }

        public NavigateToTermsCommand(ErrorViewModel ErrorViewModel)
        {
            _errorViewModel = ErrorViewModel;
        }

    public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_errorViewModel != null)
                _errorViewModel.NavigateForwardToTerms();
        }
    }
}
