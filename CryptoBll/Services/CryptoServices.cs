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

        public async Task<List<Asset>?> SearchById(string id)
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
                            var result = assets.Assets.Where(a => a.Id.Contains(id.ToLower()));
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

    }
}
