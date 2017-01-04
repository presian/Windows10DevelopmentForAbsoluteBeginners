// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoundItemsFactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The sound items factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoundBoard.Factories
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using SoundBoard.Enumerations;
    using SoundBoard.Models;

    /// <summary>
    /// The sound items factory.
    /// </summary>
    public class SoundItemsFactory
    {
        /// <summary>
        /// The get sounds.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        public static ObservableCollection<Sound> GetSounds()
        {
            return GetSoundItems();
        }

        /// <summary>
        /// The get sounds.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        public static ObservableCollection<Sound> GetSounds(SoundCategories category)
        {
            return new ObservableCollection<Sound>(GetSoundItems().Where(e => e.Category == category));
        }

        /// <summary>
        /// The get sound items.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        private static ObservableCollection<Sound> GetSoundItems()
        {
            var sounds = new ObservableCollection<Sound>
                             {
                                 new Sound("Cow", SoundCategories.Animals),
                                 new Sound("Cat", SoundCategories.Animals),

                                 new Sound("Gun", SoundCategories.Cartoons),
                                 new Sound("Spring", SoundCategories.Cartoons),

                                 new Sound("Clock", SoundCategories.Taunts),
                                 new Sound("LOL", SoundCategories.Taunts),

                                 new Sound("Ship", SoundCategories.Warnings),
                                 new Sound("Siren", SoundCategories.Warnings),
                             };

            return sounds;
        }
    }
}