using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using HeroExplorer.Models;
using Newtonsoft.Json;

namespace HeroExplorer.Facades
{
    public class Marvel
    {
        private const string PrivateKey = "8641691dc16c6bb2e92f599690b4df7255f22e93";
        private const string PublicKey = "5a3159f81f43becea42562b3b2894aae";
        private const string ImageNotAvailable = "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available";
        private const int MaxCharacters = 1500;
        private static CharacterDataWrapper dataWrapper = null;

        public static CharacterDataWrapper DataWrapper
        {
            get
            {
                return dataWrapper;
            }

            private set
            {
                dataWrapper = value;
            }
        }

        public static async Task PupulateMarvelCharactersAsync(ObservableCollection<Character> characters)
        {
            try
            {
                DataWrapper = await GetCharacterDataWrapperAsync();
                foreach (var character in DataWrapper.Data.Results)
                {
                    if (character.Thumbnail != null
                        && !string.IsNullOrEmpty(character.Thumbnail.Path)
                        && character.Thumbnail.Path != ImageNotAvailable
                        && !string.IsNullOrEmpty(character.Description)
                        && characters.Count < 10)
                    {
                        character.Thumbnail.Small = string.Format(
                            "{0}/standard_small.{1}",
                            character.Thumbnail.Path,
                            character.Thumbnail.Extension);

                        character.Thumbnail.Large = string.Format(
                            "{0}/portrait_xlarge.{1}",
                            character.Thumbnail.Path,
                            character.Thumbnail.Extension);

                        characters.Add(character);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public static async Task<CharacterDataWrapper> GetCharacterDataWrapperAsync()
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
            var result = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);

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