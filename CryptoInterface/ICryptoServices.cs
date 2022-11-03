using CryptoInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInterface
{
    public interface ICryptoServices
    {
        Task<AssetsData?> GetAssets();
        Task<List<Asset>?> SearchByAssetId(string assetId);
        double ConvertAssets(Asset fromAsset, Asset toAsset, double count);
        Task<AssetsMarketData?> GetAssetsMarketsByAssetId(string assetId);
    }
}