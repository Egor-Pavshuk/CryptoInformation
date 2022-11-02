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
        private string _title;
        private Page _currentPage;
        private Dictionary<string, Page> _pages;

        public Page CurrentPage { get => _currentPage; set { Set(ref _currentPage, value); } }
        public string Title { get => _title; set { Set(ref _title, value); } }

        public MainWindowViewModel()
        {
            _title = "Crypto information";
            
            _pages = new Dictionary<string, Page>();
            _pages.Add("Converter", new ConverterPage());
            _pages.Add("Main", new MainPage());
            _pages.Add("Search", new Search());
            _pages.Add("MoreDetails", new MoreDetails());

            _currentPage = _pages["Main"];

            ConverterCommandClick = new RelayCommand(OnConverterCommandClickExecuted, CanConverterCommandClickExecute);
            SearchCommandClick = new RelayCommand(OnSearchCommandClickExecuted, CanSearchCommandClickExecute);
        }

        #region Commands 
        public ICommand ConverterCommandClick
        {
            get;
        }

        private void OnConverterCommandClickExecuted(object o)
        {
            Title = "Converter";
            CurrentPage = _pages["Converter"];
        }

        private bool CanConverterCommandClickExecute(object o)
        {
            return true;
        }

        public ICommand SearchCommandClick
        {
            get;
        }

        private void OnSearchCommandClickExecuted(object o)
        {
            Title = "Search";
            CurrentPage = _pages["Search"];
        }

        private bool CanSearchCommandClickExecute(object o)
        {
            return true;
        }
        #endregion

    }
}
