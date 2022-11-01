using CryptoInformation.ViewModels.Base;
using CryptoInterface;
using CryptoInterface.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CryptoBll.Services;
using CryptoInformation.ViewModels.Commands;
using System.Windows.Controls;
using CryptoInformation.Views.Pages;
using CryptoInformation.Views;
using System.Windows.Input;

namespace CryptoInformation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase //todo DI
    {
        /// <summary>
        /// Window title
        /// </summary>
        private readonly string _title;
        private Page _currentPage;

       // public ViewModelBase CurrentView { get => _currentView; }
        public Page CurrentPage { get => _currentPage; }
        public string Title { get => _title; }

        public MainWindowViewModel()
         {
            _title = "Crypto information";
            _currentPage = new MainPage();

            ConverterCommandClick = new RelayCommand(OnConverterCommandClickExecuted, CanConverterCommandClickExecute);
        }

        public ICommand ConverterCommandClick
        {
            get;
        }

        private void OnConverterCommandClickExecuted(object o) 
        {
            _currentPage = new ConverterPage();
        }

        private bool CanConverterCommandClickExecute(object o)
        {
            return true;
        }

        private void ChangePage()
        {
            _currentPage = new ConverterPage();
           // _currentView = new ConverterViewModel();
        }

    }
}
