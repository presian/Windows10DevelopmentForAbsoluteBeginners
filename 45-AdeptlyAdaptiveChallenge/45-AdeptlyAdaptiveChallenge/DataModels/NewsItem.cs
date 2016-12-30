// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsItem.cs" company="PresianDanailov">
//   
// </copyright>
// <summary>
//   The news item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace _45_AdeptlyAdaptiveChallenge.DataModels
{
    using System;

    using _45_AdeptlyAdaptiveChallenge.Enumerations;

    /// <summary>
    /// The news item.
    /// </summary>
    public class NewsItem
    {
        /// <summary>
        /// The id.
        /// </summary>
        private int id;

        /// <summary>
        /// The category.
        /// </summary>
        private Categories category;

        /// <summary>
        /// The headline.
        /// </summary>
        private string headline;

        /// <summary>
        /// The subhead.
        /// </summary>
        private string subhead;

        /// <summary>
        /// The date line.
        /// </summary>
        private string dateLine;

        /// <summary>
        /// The image.
        /// </summary>
        private string image;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public Categories Category
        {
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
            }
        }

        /// <summary>
        /// Gets or sets the headline.
        /// </summary>
        public string Headline
        {
            get
            {
                return this.headline;
            }

            set
            {
                this.headline = value;
            }
        }

        /// <summary>
        /// Gets or sets the subhead.
        /// </summary>
        public string Subhead
        {
            get
            {
                return this.subhead;
            }

            set
            {
                this.subhead = value;
            }
        }

        /// <summary>
        /// Gets or sets the date line.
        /// </summary>
        public string DateLine
        {
            get
            {
                return this.dateLine;
            }

            set
            {
                this.dateLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }
    }
}