using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInterface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInformation.ViewModels
{
    internal class SearchPageViewModel : ViewModelBase
    {
        private List<Asset> _assets;
        private List<AssetDetailsViewModel>? _similarAssets;
        private string _searchRequest = "";
        private List<AssetDetailsViewModel> _assetDetailsViewModels;

        public string SearchRequest
        {
            get => _searchRequest;
            set
            {
                Set(ref _searchRequest, value);
                var result = _assetDetailsViewModels.Where(a => a.Id.Contains(_searchRequest));
                SimilarAssets = result.ToList();
            }
        }
        public List<AssetDetailsViewModel> SimilarAssets
        {
            get => _similarAssets;
            set
            {
                Set(ref _similarAssets, value);
            }
        }
        public List<AssetDetailsViewModel> AssetDetailsViewModels
        {
            get => _assetDetailsViewModels;
            set
            {
                Set(ref _assetDetailsViewModels, value);
            }
        }

        public SearchPageViewModel()
        {
            _assets = new List<Asset>();
            GetAssets().Wait();
            _similarAssets = null;
            _assetDetailsViewModels = new List<AssetDetailsViewModel>(_assets.Count);

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
        private async Task GetAssets()
        {
            CryptoServices cryptoServices = new();
            var result = await cryptoServices.GetAssets().ConfigureAwait(false);
            if (result != null)
            {
                _assets = result.Data.ToList();
            }
        }

    }
}
