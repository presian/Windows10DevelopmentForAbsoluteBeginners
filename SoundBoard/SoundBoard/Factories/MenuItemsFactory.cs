// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItemsFaactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The menu items faactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
                        ItemImage = AssetsHelper.MakeImagePath("SoundBoardAssets/Icons/animals.png"),
                        ItemText = "Animals"
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeImagePath("SoundBoardAssets/Icons/cartoon.png"),
                        ItemText = "Cartoons"
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeImagePath("SoundBoardAssets/Icons/taunt.png"),
                        ItemText = "Taunts"
                    },
                new MenuItem()
                    {
                        ItemImage = AssetsHelper.MakeImagePath("SoundBoardAssets/Icons/warning.png"),
                        ItemText = "Warnings"
                    }
                };

            return items;
        }
    }
}