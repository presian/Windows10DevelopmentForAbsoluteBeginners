// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sound.cs" company="PresianDanilov">
//   Null
// </copyright>
// <summary>
//   The sound.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoundBoard.Models
{
    using System;

    using SoundBoard.Enumerations;
    using SoundBoard.UtilityClasses;

    /// <summary>
    /// The sound.
    /// </summary>
    public class Sound
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sound"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        public Sound(string name, SoundCategories category)
        {
            this.Name = name;
            this.Category = category;
            this.AudioFile = AssetsHelper.MakeAssetsPath(string.Format("Audio/{0}/{1}.wav", this.Category.ToString(), this.Name));
            this.ImageFile = AssetsHelper.MakeAssetsPath(string.Format("Images/{0}/{1}.png",  this.Category.ToString(), this.Name));
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public SoundCategories Category { get; set; }

        /// <summary>
        /// Gets the audio file.
        /// </summary>
        public string AudioFile { get; }

        /// <summary>
        /// Gets the image file.
        /// </summary>
        public string ImageFile { get; }
    }
}