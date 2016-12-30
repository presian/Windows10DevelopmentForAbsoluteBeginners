// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataFactory.cs" company="PresianDanailov">
//   Fake DataFactory
// </copyright>
// <summary>
//   The data factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _45_AdeptlyAdaptiveChallenge.DataModels
{
    using System.Collections.Generic;
    using System.Linq;

    using _45_AdeptlyAdaptiveChallenge.Enumerations;

    /// <summary>
    /// The data factory.
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// The items.
        /// </summary>
        private readonly List<NewsItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactory"/> class.
        /// </summary>
        public DataFactory()
        {
            this.items = this.GetNewsItems();
        }

        /// <summary>
        /// The get items by category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<NewsItem> GetItemsByCategory(Categories category)
        {
            var itemsByCategory = this.items
                .Where(i => i.Category == category)
                .ToList();

            return itemsByCategory;
        }

        /// <summary>
        /// The get news items.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<NewsItem> GetNewsItems()
        {
            var currentItems = new List<NewsItem>
                            {
                                new NewsItem()
                                    {
                                        Id = 1,
                                        Category = Categories.Financial,
                                        Headline = "Lorem Ipsum",
                                        Subhead = "doro sit amet",
                                        DateLine = "Nunc tristique nec",
                                        Image = "Assets/MyAssets/Financial1.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 2,
                                        Category = Categories.Financial,
                                        Headline = "Etiam ac felis viverra",
                                        Subhead = "vulputate nisl ac, aliquet nisi",
                                        DateLine = "tortor porttitor, eu fermentum ante congue",
                                        Image = "Assets/MyAssets/Financial2.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 3,
                                        Category = Categories.Financial,
                                        Headline = "Integer sed turpis erat",
                                        Subhead = "Sed quis hendrerit lorem, quis interdum dolor",
                                        DateLine = "in viverra metus facilisis sed",
                                        Image = "Assets/MyAssets/Financial3.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 4,
                                        Category = Categories.Financial,
                                        Headline = "Proin sem neque",
                                        Subhead = "aliquet quis ipsum tincidunt",
                                        DateLine = "Integer eleifend",
                                        Image = "Assets/MyAssets/Financial4.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 5,
                                        Category = Categories.Financial,
                                        Headline = "Mauris bibendum non leo vitae tempor",
                                        Subhead = "In nisl tortor, eleifend sed ipsum eget",
                                        DateLine = "Curabitur dictum augue vitae elementum ultrices",
                                        Image = "Assets/MyAssets/Financial5.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 6,
                                        Category = Categories.Food,
                                        Headline = "Lorem ipsum",
                                        Subhead = "dolor sit amet",
                                        DateLine = "Nunc tristique nec",
                                        Image = "Assets/MyAssets/Food1.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 7,
                                        Category = Categories.Food,
                                        Headline = "Etiam ac felis viverra",
                                        Subhead = "vulputate nisl ac, aliquet nisi",
                                        DateLine = "tortor porttitor, eu fermentum ante congue",
                                        Image = "Assets/MyAssets/Food2.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 8,
                                        Category = Categories.Food,
                                        Headline = "Integer sed turpis erat",
                                        Subhead = "Sed quis hendrerit lorem, quis interdum dolor",
                                        DateLine = "in viverra metus facilisis sed",
                                        Image = "Assets/MyAssets/Food3.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 9,
                                        Category = Categories.Food,
                                        Headline = "Proin sem neque",
                                        Subhead = "aliquet quis ipsum tincidunt",
                                        DateLine = "Integer eleifend",
                                        Image = "Assets/MyAssets/Food4.png"
                                    },
                                new NewsItem()
                                    {
                                        Id = 10,
                                        Category = Categories.Food,
                                        Headline = "Mauris bibendum non leo vitae tempor",
                                        Subhead = "In nisl tortor, eleifend sed ipsum eget",
                                        DateLine = "Curabitur dictum augue vitae elementum ultrices",
                                        Image = "Assets/MyAssets/Food5.png"
                                    }
                            };

            return currentItems;
        }
    }
}