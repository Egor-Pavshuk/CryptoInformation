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
    internal class ConverterPageViewModel : ViewModelBase
    {
        private List<Asset> _assets;
        private List<string> _assetNames;
        private string _assetConvertFrom;
        private string _assetConvertTo;
        private double _count;
        private double _conversionResult;
        private CryptoServices _cryptoServices;
        public double ConversionResult { get => _conversionResult; set { Set(ref _conversionResult, value); } }
        public List<string> AssetNames { get => _assetNames; }
        public double Count
        {
            get => _count;
            set
            {
                double.Parse(value.ToString().Replace('.', ','));
                Set(ref _count, value);
                ConversionResult = _cryptoServices.ConvertAssets(_assets.First(a => a.Symbol == _assetConvertFrom), _assets.First(a => a.Symbol == _assetConvertTo), _count);
            }
        }
        public string AssetConvertFrom
        {
            get => _assetConvertFrom;
            set
            {
                Set(ref _assetConvertFrom, value);
                ConversionResult = _cryptoServices.ConvertAssets(_assets.First(a => a.Symbol == _assetConvertFrom), _assets.First(a => a.Symbol == _assetConvertTo), _count);
            }
        }

        public string AssetConvertTo
        {
            get => _assetConvertTo;
            set
            {
                Set(ref _assetConvertTo, value);
                ConversionResult = _cryptoServices.ConvertAssets(_assets.First(a => a.Symbol == _assetConvertFrom), _assets.First(a => a.Symbol == _assetConvertTo), _count);
            }
        }

        public ConverterPageViewModel()
        {
            _assets = new List<Asset>();
            GetAssets().Wait();
            _assetNames = new List<string>(_assets.Count);
            foreach (Asset asset in _assets)
                _assetNames.Add(asset.Symbol);
            _cryptoServices = new();

            _assetConvertFrom = _assetNames.First();
            _assetConvertTo = _assetNames.First();

            ConvertCommand = new RelayCommand(OnConvertCommandExecuted, CanConvertCommandExecute);
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

        #region Commands 
        public ICommand ConvertCommand
        {
            get;
        }

        private void OnConvertCommandExecuted(object o)
        {
            ConversionResult = _cryptoServices.ConvertAssets(_assets.First(a => a.Symbol == _assetConvertFrom), _assets.First(a => a.Symbol == _assetConvertTo), _count);
        }

        private bool CanConvertCommandExecute(object o)
        {
            return true;
        }
        #endregion
    }
}
