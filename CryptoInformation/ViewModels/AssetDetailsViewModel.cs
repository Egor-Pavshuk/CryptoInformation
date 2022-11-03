using CryptoBll.Services;
using CryptoInformation.ViewModels.Base;
using CryptoInformation.ViewModels.Commands;
using CryptoInterface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CryptoInformation.ViewModels
{
    internal class AssetDetailsViewModel : ViewModelBase
    {
        private string _buttonContent = "More";
        private double _height = 40;
        private string _isDetailsVisible = "Hidden";
        private List<AssetMarket> _markets;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string IsDetailsVisible
        {
            get => _isDetailsVisible; set
            {
                Set(ref _isDetailsVisible, value);
            }
        }

        public List<AssetMarket> Markets
        {
            get => _markets; set
            {
                Set(ref _markets, value);
            }
        }
        public double Heigth
        {
            get => _height; set
            {
                Set(ref _height, value);
            }
        }
        public AssetDetailsViewModel()
        {
            _markets = new List<AssetMarket>();
            MoreDetailsCommandClick = new RelayCommand(OnMoreDetailsCommandClickExecuted, CanMoreDetailsCommandClickExecute);
        }
        public string ButtonContent
        {
            get => _buttonContent; set
            {
                Set(ref _buttonContent, value);
            }
        }

        #region Commands
        public ICommand MoreDetailsCommandClick
        {
            get;
        }

        private void OnMoreDetailsCommandClickExecuted(object assetId)
        {
            if (IsDetailsVisible == "Visible")
            {
                IsDetailsVisible = "Hidden";
                Heigth = 40;
                ButtonContent = "More";
                return;
            }
            Heigth = 200;
            IsDetailsVisible = "Visible";
            Markets = new CryptoServices().GetAssetsMarketsByAssetId((string)assetId).Result.Data.ToList();
            ButtonContent = "Less";
        }

        private bool CanMoreDetailsCommandClickExecute(object o)
        {
            return true;
        }
        #endregion
    }
}
