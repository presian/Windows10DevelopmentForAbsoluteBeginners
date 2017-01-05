// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItemsFaactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The menu items faactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SoundBoard.Enumerations;

namespace SoundBoard.Factories
{
    using System.Collections.Generic;

    using SoundBoard.Models;
    using SoundBoard.UtilityClasses;

    /// <summary>
    /// The menu items factory.
    /// </summary>
    public class MenuItemsFactory
    {
        /// <summary>
        /// The make menu items.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<MenuItem> MakeMenuItems()
        {
            var items = new List<MenuItem>()
                {
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeAssetsPath("Icons/animals.png"),
                        ItemText = "Animals",
                        Category = SoundCategories.Animals
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeAssetsPath("Icons/cartoon.png"),
                        ItemText = "Cartoons",
                        Category = SoundCategories.Cartoons
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeAssetsPath("Icons/taunt.png"),
                        ItemText = "Taunts",
                        Category = SoundCategories.Taunts
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeAssetsPath("Icons/warning.png"),
                        ItemText = "Warnings",
                        Category = SoundCategories.Warnings
                    }
                };

            return items;
        }
    }
}