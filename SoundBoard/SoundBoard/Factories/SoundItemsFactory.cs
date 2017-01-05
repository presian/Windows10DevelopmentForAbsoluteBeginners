// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoundItemsFactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The sound items factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using SoundBoard.DataTemplates;

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
        public static List<Sound> AllSounds = GetSoundItems();
        /// <summary>
        /// The get sounds.
        /// </summary>
        public static void GetSounds(ObservableCollection<Sound> sounds)
        {
            if (sounds == null)
            {
                throw new ArgumentNullException(nameof(sounds));
            }

            sounds.Clear();
            AllSounds.ForEach(sounds.Add);
        }

        /// <summary>
        /// The get sounds.
        /// </summary>
        /// <param name="sounds"></param>
        /// <param name="category">
        /// The category.
        /// </param>
        public static void GetSounds(ObservableCollection<Sound> sounds, SoundCategories category)
        {
            sounds.Clear();
            var currentSounds = AllSounds
                .Where(e => e.Category == category)
                .ToList();
            currentSounds.ForEach(sounds.Add);
        }

        /// <summary>
        /// The get sound items.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        private static List<Sound> GetSoundItems()
        {
            var sounds = new List<Sound>()
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