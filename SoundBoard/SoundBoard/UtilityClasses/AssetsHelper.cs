// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetsHelper.cs" company="PrsianDanailov">
//   Null
// </copyright>
// <summary>
//   The assets helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoundBoard.UtilityClasses
{
    /// <summary>
    /// The assets helper.
    /// </summary>
    public static class AssetsHelper
    {
        /// <summary>
        /// The make image path.
        /// </summary>
        /// <param name="imagePathInAssetsFolder">
        /// The image path in assets folder.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string MakeImagePath(string imagePathInAssetsFolder)
        {
            return string.Format("{0}{1}", Constants.AssetsRoot(), imagePathInAssetsFolder);
        }
    }
}