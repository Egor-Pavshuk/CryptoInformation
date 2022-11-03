using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInterface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInformation.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        private CryptoServices _cryptoServices;
        private List<Asset> _assets;
        private List<AssetDetailsViewModel> _assetDetailsViewModels;


        public List<AssetDetailsViewModel> AssetDetailsViewModels
        {
            get => _assetDetailsViewModels;
            set
            {
                Set(ref _assetDetailsViewModels, value);
            }
        }

        public MainPageViewModel()
        {
            _cryptoServices = new();
            _assets = new List<Asset>();
            _assetDetailsViewModels = new List<AssetDetailsViewModel>();

            GetAssets().Wait();
            foreach (var asset in _assets)
            {
                _assetDetailsViewModels.Add(new AssetDetailsViewModel
                {
                    Name = asset.Name,
                    Id = asset.Id,
                    VolumeUsd24Hr = asset.VolumeUsd24Hr,
                    ChangePercent24Hr = asset.ChangePercent24Hr,
                    Symbol = asset.Symbol,
                    PriceUsd = asset.PriceUsd
                });
            }

        }
        public List<Asset> Assets { get => _assets; }

        private async Task GetAssets()
        {
            var result = await _cryptoServices.GetAssets().ConfigureAwait(false);
            if (result != null)
            {
                _assets = result.Data.Take(10).ToList();
            }
        }

    }
}

