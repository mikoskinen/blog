using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace WinRT_MVVM_GridView_SemanticZoom
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class Movies : WinRT_MVVM_GridView_SemanticZoom.Common.LayoutAwarePage
    {
        public Movies()
        {
            this.InitializeComponent();

            var viewModel = new MoviesPageViewModel();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property provides the grouped collection of items to be displayed.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var collectionGroups = groupedItemsViewSource.View.CollectionGroups;
            ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
        }
    }
}
