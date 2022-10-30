using CryptoInterface.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBll.Services
{
    internal class CryptoServices
    {
        public async Task<AssetsData?> GetAssets()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://api.coincap.io/v2/assets"))
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(json))
                        {
                            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<AssetsData>(json);
                            return result;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }

        public async Task<List<Asset>?> SearchByAssetId(string assetId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync("https://api.coincap.io/v2/assets"))
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(json))
                        {
                            var assets = Newtonsoft.Json.JsonConvert.DeserializeObject<AssetsData>(json);
                            var result = assets.Data.Where(a => a.Id.Contains(assetId.ToLower()));
                            if (result != null)
                            {
                                return (List<Asset>?)result;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public double ConvertAssets(Asset fromAsset, Asset toAsset, double count)
        {
            var result = Convert.ToDouble(fromAsset.PriceUsd.Replace('.', ',')) / (double)Convert.ToDouble(toAsset.PriceUsd.Replace('.', ',')) * count;
            return result;
        }

        public async Task GetAssetsMarketsByAssetId(string assetId)
        {
            try
            {

                using (HttpClient client1 = new HttpClient())
                {
                    using (HttpResponseMessage response = await client1.GetAsync($"https://api.coincap.io/v2/assets/" + assetId + "/markets"))
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(json))
                        {
                            var assets = Newtonsoft.Json.JsonConvert.DeserializeObject<AssetsMarketData>(json);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}


