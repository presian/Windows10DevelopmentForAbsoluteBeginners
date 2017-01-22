using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using HeroExplorer.Models.Character;
using HeroExplorer.Models.Comic;
using Newtonsoft.Json;
using Character = HeroExplorer.Models.Character.Character;

namespace HeroExplorer.Facades
{
    public class Marvel
    {
        private const string PrivateKey = "8641691dc16c6bb2e92f599690b4df7255f22e93";
        private const string PublicKey = "5a3159f81f43becea42562b3b2894aae";
        private const string ImageNotAvailable = "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available";
        private const int MaxCharacters = 1500;
        private static CharacterDataWrapper characterDataWrapper = null;
        private static ComicDataWrapper comicDataWrapper = null;

        public static CharacterDataWrapper CharacterDataWrapper
        {
            get
            {
                return characterDataWrapper;
            }

            private set
            {
                characterDataWrapper = value;
            }
        }

        public static ComicDataWrapper ComicDataWrapper
        {
            get
            {
                return comicDataWrapper;
            }

            set
            {
                comicDataWrapper = value;
            }
        }

        public static async Task PupulateMarvelCharactersAsync(ObservableCollection<Character> characters)
        {
            try
            {
                CharacterDataWrapper = await GetCharacterDataWrapperAsync();
                foreach (var character in CharacterDataWrapper.Data.Results)
                {
                    if (character.Thumbnail != null
                        && !string.IsNullOrEmpty(character.Thumbnail.Path)
                        && character.Thumbnail.Path != ImageNotAvailable
                        && !string.IsNullOrEmpty(character.Description)
                        && characters.Count < 10
                        && character.Comics.Items.Count > 9)
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

        public static async Task PupulateMarvelComicsAsync(int characterId, ObservableCollection<Comic> comics)
        {
            try
            {
                ComicDataWrapper = await GetComicDataWrapperAsync(characterId);

                foreach (var comic in ComicDataWrapper.Data.Comics)
                {
                    if (comic.Thumbnail != null
                        && !string.IsNullOrEmpty(comic.Thumbnail.Path)
                        && comic.Thumbnail.Path != ImageNotAvailable)
                    {
                        comic.Thumbnail.Small = string.Format(
                            "{0}/portrait_medium.{1}",
                            comic.Thumbnail.Path,
                            comic.Thumbnail.Extension);

                        comic.Thumbnail.Large = string.Format(
                            "{0}/portrait_xlarge.{1}",
                            comic.Thumbnail.Path,
                            comic.Thumbnail.Extension);

                        comics.Add(comic);
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

            var url = $"https://gateway.marvel.com:443/v1/public/characters?limit={limit}&offset={offset}";

            var json = await CallMarvelApiAsync(url);
            var result = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);

            return result;
        }


        public static async Task<ComicDataWrapper> GetComicDataWrapperAsync(int characterId)
        {
            var limit = 10;

            var url = $"https://gateway.marvel.com:443/v1/public/characters/{characterId}/comics?limit={limit}";
            var json = await CallMarvelApiAsync(url);
           
            var result = JsonConvert.DeserializeObject<ComicDataWrapper>(json);

            return result;
        }

        private static async Task<string> CallMarvelApiAsync(string url)
        {
            var timeStamp = DateTime.Now.Ticks.ToString();
            var hash = CreateHash(timeStamp);
            var apiUrl = $"{url}&apikey={PublicKey}&ts={timeStamp}&hash={hash}";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            var json = await response.Content.ReadAsStringAsync();
            return json;
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