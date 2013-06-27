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
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace hubcontrol_getting_started
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Movie> trailers = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> nearyou = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> popular = new ObservableCollection<Movie>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Popular_Loaded(object sender, RoutedEventArgs e)
        {
            popular.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/qeUD7msuIMDm3VUxk48AQxdpdy0.jpg", Title = "This is the End", Subtitle = "Comedy", Description = "While attending a party at James Franco's house, Seth Rogen, Jay Baruchel and many other celebrities are faced with the apocalypse." });
            popular.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/gAt1PrsrFY1nX6UzebeiHP8njE9.jpg", Title = "World War Z", Subtitle = "Horror", Description = "A UN representative, writing a report on the great zombie war, interviews survivors in the wake of World War Z." });
            popular.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/xKeaR8RGXJKICgXRAD0bJS2cTYf.jpg", Title = "Monsters University", Subtitle = "Animation", Description = "A look at the relationship between Mike and Sulley during their days at Monsters University -- when they weren't necessarily the best of friends." });
            popular.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/6HQT7R0tiWGxi7CA1zb58j28OTM.jpg", Title = "Man of Steel", Subtitle = "Action", Description = "A young journalist raised by his adoptive parents after he was transported to Earth in infancy from the dying planet of Krypton finds himself in the position to save humankind after Earth is attacked." });

            var listView = (GridView)sender;
            listView.ItemsSource = popular;
        }

        private void MovieTrailers_Loaded(object sender, RoutedEventArgs e)
        {
            trailers.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w185/6HQT7R0tiWGxi7CA1zb58j28OTM.jpg", Title = "Man of Steel", Subtitle = "Action", Description = "A young journalist raised by his adoptive parents after he was transported to Earth in infancy from the dying planet of Krypton finds himself in the position to save humankind after Earth is attacked." });
            trailers.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w185/gAt1PrsrFY1nX6UzebeiHP8njE9.jpg", Title = "World War Z", Subtitle = "Horror", Description = "A UN representative, writing a report on the great zombie war, interviews survivors in the wake of World War Z." });
            trailers.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w185/xKeaR8RGXJKICgXRAD0bJS2cTYf.jpg", Title = "Monsters University", Subtitle = "Animation", Description = "A look at the relationship between Mike and Sulley during their days at Monsters University -- when they weren't necessarily the best of friends." });
            trailers.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w185/qeUD7msuIMDm3VUxk48AQxdpdy0.jpg", Title = "This is the End", Subtitle = "Comedy", Description = "While attending a party at James Franco's house, Seth Rogen, Jay Baruchel and many other celebrities are faced with the apocalypse." });

            var listView = (ListView)sender;
            listView.ItemsSource = trailers;
        }

        private void NearYou_Loaded(object sender, RoutedEventArgs e)
        {
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/gAt1PrsrFY1nX6UzebeiHP8njE9.jpg", Title = "World War Z", Subtitle = "Horror", Description = "A UN representative, writing a report on the great zombie war, interviews survivors in the wake of World War Z." });
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/6HQT7R0tiWGxi7CA1zb58j28OTM.jpg", Title = "Man of Steel", Subtitle = "Action", Description = "A young journalist raised by his adoptive parents after he was transported to Earth in infancy from the dying planet of Krypton finds himself in the position to save humankind after Earth is attacked." });
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/xKeaR8RGXJKICgXRAD0bJS2cTYf.jpg", Title = "Monsters University", Subtitle = "Animation", Description = "A look at the relationship between Mike and Sulley during their days at Monsters University -- when they weren't necessarily the best of friends." });
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/qeUD7msuIMDm3VUxk48AQxdpdy0.jpg", Title = "This is the End", Subtitle = "Comedy", Description = "While attending a party at James Franco's house, Seth Rogen, Jay Baruchel and many other celebrities are faced with the apocalypse." });
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/6HQT7R0tiWGxi7CA1zb58j28OTM.jpg", Title = "Man of Steel", Subtitle = "Action", Description = "A young journalist raised by his adoptive parents after he was transported to Earth in infancy from the dying planet of Krypton finds himself in the position to save humankind after Earth is attacked." });
            nearyou.Add(new Movie { Image = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/original/gAt1PrsrFY1nX6UzebeiHP8njE9.jpg", Title = "World War Z", Subtitle = "Horror", Description = "A UN representative, writing a report on the great zombie war, interviews survivors in the wake of World War Z." });

            var gridView = (GridView)sender;
            gridView.ItemsSource = nearyou;
        }

        private async void Hub_SectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            var clickedSection = e.Section;
            if (clickedSection.Name == "TrailersSection")
            {
                // Add navigation logic
                var dialog = new MessageDialog("The navigation logic can be added in here.");
                await dialog.ShowAsync();
            }
        }

        private void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            var sections = this.Hub.Sections;
            var headers = new List<string>();

            foreach(var item in sections)
            {
                var section = (HubSection)item;
                var header = (string)section.Header;
                if (string.IsNullOrWhiteSpace(header))
                    continue;

                headers.Add(header);
            }

            ((GridView)this.Zoom.ZoomedOutView).ItemsSource = headers;
        }
    }

    public class Movie
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}
