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

namespace CryptoInformation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Window title
        /// </summary>
        private readonly string _title;
        private List<Asset> _assets;
        public string Title { get => _title; }
        public MainWindowViewModel()
        {
            _title = "Crypto information";
            GetAssets().Wait();            
        }
        public List<Asset> Assets { get => _assets; }

        private async Task GetAssets()
        {
            CryptoServices cryptoServices = new CryptoServices();
            var result = await cryptoServices.GetAssets().ConfigureAwait(false);
            if (result != null)
            {
                _assets = result.Data.Take(10).ToList();
            }
        }
    }
}
