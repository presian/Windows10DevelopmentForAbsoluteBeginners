// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The constants.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoundBoard.UtilityClasses
{
    using System;

    /// <summary>
    /// The constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The assets root.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string AssetsRoot()
        {
            return new Uri("ms-appx://SoundBoard/Assets/SoundBoardAssets/").ToString();
        }
    }
}