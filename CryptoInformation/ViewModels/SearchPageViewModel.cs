using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CryptoInformation.ViewModels
{
    internal class SearchPageViewModel : ViewModelBase
    {
        private List<Asset> _assets;
        private List<Asset>? _similarAssets;
        private string _searchRequest = "";
        
        public string SearchRequest
        {
            get => _searchRequest;
            set
            {
                Set(ref _searchRequest, value);
                var result = _assets.Where(a => a.Id.Contains(_searchRequest));
                SimilarAssets = result.ToList();
            }
        }
        public List<Asset> SimilarAssets
        {
            get => _similarAssets;
            set
            {
                Set(ref _similarAssets, value);
            }
        }
        public SearchPageViewModel()
        {
            _assets = new List<Asset>();
            GetAssets().Wait();
            _similarAssets = null;
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
