// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="PrsianDanailov">
// Null
// </copyright>
// <summary>
//   The menu item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SoundBoard.Enumerations;

namespace SoundBoard.Models
{
    /// <summary>
    /// The menu item.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the item image.
        /// </summary>
        public string ItemImage { get; set; }

        /// <summary>
        /// Gets or sets the item text.
        /// </summary>
        public string ItemText { get; set; }

        public SoundCategories Category { get; set; }
    }
}