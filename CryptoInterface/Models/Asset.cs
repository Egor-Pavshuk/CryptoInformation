using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInterface.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Supply { get; set; }
        public string axSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        private string _priceUsd;
        public string PriceUsd {
            get => _priceUsd; 
            set
            {
                var price = Convert.ToDouble(value.Replace('.', ','));
                _priceUsd = string.Format("{0:N3} $", price);
            }
        }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
    }
}
