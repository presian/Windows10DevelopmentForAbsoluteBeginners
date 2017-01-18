using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using HeroExplorer.Models;

namespace HeroExplorer.Facades
{
    public class Marvel
    {
        private const string PrivateKey = "8641691dc16c6bb2e92f599690b4df7255f22e93";
        private const string PublicKey = "5a3159f81f43becea42562b3b2894aae";
        private const int MaxCharacters = 1500;

        public static async Task<CharacterDataWrapper> GetCharacterList()
        {
            var limit = 10;

            var random = new Random();
            var offset = random.Next(MaxCharacters);
            var timeStamp = DateTime.Now.Ticks.ToString();
            var hash = CreateHash(timeStamp);

            var pattern =
                "https://gateway.marvel.com:443/v1/public/characters?limit={0}&offset={1}&apikey={2}&ts={3}&hash={4}";
            var apiUrl = string.Format(pattern, limit, offset, PublicKey, timeStamp, hash);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            var json = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof (CharacterDataWrapper));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var result = (CharacterDataWrapper) serializer.ReadObject(ms);

            return result;

        }

        private static string CreateHash(string timeStamp)
        {
            var toBeHashed = timeStamp + PrivateKey + PublicKey;

            return ComputeMd5(toBeHashed);
        }

        private static string ComputeMd5(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);

            return res;
        }
    }
}