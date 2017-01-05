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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236
namespace SoundBoard.DataTemplates
{
    using SoundBoard.Models;


        /// <summary>
        /// The main menu item.
        /// </summary>
        public sealed partial class MainMenuItem : UserControl
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DataTemplates.MainMenuItem"/> class.
            /// </summary>
            public MainMenuItem()
            {
                this.InitializeComponent();
                this.DataContextChanged += (s, e) => Bindings.Update();
            }

            /// <summary>
            /// Gets the item.
            /// </summary>
            public MenuItem Item => this.DataContext as MenuItem;
        }

}
