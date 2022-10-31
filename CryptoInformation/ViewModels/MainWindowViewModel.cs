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

namespace CryptoInformation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase //todo DI
    {
        /// <summary>
        /// Window title
        /// </summary>
        private readonly string _title;
        //private List<Asset> _assets;        
        private Page _currentPage;

        public Page CurrentPage { get => _currentPage; }
        public string Title { get => _title; }

        public MainWindowViewModel()
         {
            _title = "Crypto information";
            //_assets = new List<Asset>();
            //GetAssets().Wait();

            _currentPage = new MainPage();
        }
        //public List<Asset> Assets { get => _assets; }

        //private async Task GetAssets()
        //{
        //    CryptoServices cryptoServices = new();
        //    var result = await cryptoServices.GetAssets().ConfigureAwait(false);
        //    if (result != null)
        //    {
        //        _assets = result.Data.Take(10).ToList();
        //    }
        //}

        public ICommand ConverterCommand_Click
        {
            get
            {
                return new CryptoCommand((o) => _currentPage = new ConverterPage());
            }
        }

        //private void ChangePage()
    }
}
