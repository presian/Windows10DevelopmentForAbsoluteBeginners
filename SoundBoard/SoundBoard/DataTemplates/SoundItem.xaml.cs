// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoundItem.xaml.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   Defines the SoundItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SoundBoard.DataTemplates
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    using SoundBoard.Models;

    /// <summary>
    /// The sound item.
    /// </summary>
    public sealed partial class SoundItem : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoundItem"/> class.
        /// </summary>
        public SoundItem()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        /// <summary>
        /// Gets the sounds.
        /// </summary>
        public Sound SoundViewItem => this.DataContext as Sound;
    }
}
