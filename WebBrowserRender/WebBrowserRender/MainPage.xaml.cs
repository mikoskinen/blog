using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;

namespace WebBrowserRender
{
    public partial class MainPage
    {
        private const string url = "http://assets.softwaremk.org/temp/NotWorking.html";
     
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateStringClick(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();
            var content = await client.DownloadStringTaskAsync(url);

            WebBrowser.NavigateToString(content);

            //// Isolated storage solution
            //var store = IsolatedStorageFile.GetUserStoreForApplication();

            //using (var writeFile = new StreamWriter(new IsolatedStorageFileStream("htmlcontent.html", FileMode.Create, FileAccess.Write, store)))
            //{
            //    writeFile.Write(content);
            //    writeFile.Close();
            //}

            //var uri = new Uri("htmlcontent.html", UriKind.Relative);

            //WebBrowser.Navigate(uri);
        }

        private void NavigateUrlClick(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri(url));
        }
    }
}