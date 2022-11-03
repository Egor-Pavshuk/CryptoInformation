using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInformation.ViewModels.Commands;
using CryptoInterface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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
                    PriceUsd = asset.PriceUsd,

                });
            }


            //MoreDetailsCommandClick = new RelayCommand(OnMoreDetailsCommandClickExecuted, CanMoreDetailsCommandClickExecute);
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

        //public ICommand MoreDetailsCommandClick
        //{
        //    get;
        //}

        //private void OnMoreDetailsCommandClickExecuted(object assetId)
        //{
        //    var asset = AssetDetailsViewModels.Find(a => a.Id == assetId);
        //    asset.IsDetailsVisible = true;
        //    var markets = _cryptoServices.GetAssetsMarketsByAssetId((string)assetId).Result.Data;
        //    asset.Markets = markets.ToList();

        //}

        //private bool CanMoreDetailsCommandClickExecute(object o)
        //{
        //    return true;
        //}


    }
}

