using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
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
using Tile_Generator;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinRT_Live_Tile_Notification_Queue
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

            for (var i = 0; i < 5; i++)
            {
                var tileTitle = string.Format("Local Notification {0}", i);
                var tilesSubtitle = DateTime.UtcNow.AddHours(i);
                var myTile = Generator.Generate(tileTitle, tilesSubtitle);

                var notification = new TileNotification(myTile.ToXmlDoc()) { ExpirationTime = tilesSubtitle.AddMinutes(15), Tag = i.ToString()};

                TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
            }
        }
    }

    public static class XmlLinqConversionExtensions
    {
        public static XmlDocument ToXmlDoc(this XElement xElement)
        {
            var xml = xElement.ToString();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            return xmlDoc;
        }
    }
}
