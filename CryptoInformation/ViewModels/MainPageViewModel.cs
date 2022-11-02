using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInformation.ViewModels.Commands;
using CryptoInformation.Views.Pages;
using CryptoInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoInformation.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private bool _isDetailsVisible = false;
        private List<Asset> _assets;
        public bool IsDetailsVisible { get => _isDetailsVisible; set
            {
                Set(ref _isDetailsVisible, value);
            } }
        public MainPageViewModel()
        {
            _assets = new List<Asset>();
            GetAssets().Wait();
            MoreDetailsCommandClick = new RelayCommand(OnMoreDetailsCommandClickExecuted, CanMoreDetailsCommandClickExecute);
        }
        public List<Asset> Assets { get => _assets; }

        private async Task GetAssets()
        {
            CryptoServices cryptoServices = new();
            var result = await cryptoServices.GetAssets().ConfigureAwait(false);
            if (result != null)
            {
                _assets = result.Data.Take(10).ToList();
            }
        }

        public ICommand MoreDetailsCommandClick
        {
            get;
        }

        private void OnMoreDetailsCommandClickExecuted(object o)
        {
            IsDetailsVisible = true;
        }

        private bool CanMoreDetailsCommandClickExecute(object o)
        {
            return true;
        }


    }
}

