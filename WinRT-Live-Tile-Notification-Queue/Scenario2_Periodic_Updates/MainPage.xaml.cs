using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Scenario2_Periodic_Updates
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();

            var uris = new List<Uri>();
            const string baseUri = "http://localhost:8080/api/tileupdater/get?position=";

            for (var i = 0; i < 5; i++)
            {
                uris.Add(new Uri(baseUri + i, UriKind.Absolute));
            }

            TileUpdateManager.CreateTileUpdaterForApplication().StartPeriodicUpdateBatch(uris,
                                                                                         PeriodicUpdateRecurrence.HalfHour);
        }
    }
}
