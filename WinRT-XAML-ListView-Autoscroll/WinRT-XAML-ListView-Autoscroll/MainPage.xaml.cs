using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App27
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<string> items = new ObservableCollection<string>();
        private int messageIndex;

        private bool lockToBottom = true;
        public bool LockToBottom
        {
            get { return lockToBottom; }
            set
            {
                lockToBottom = value;

                this.Status.Text = lockToBottom ? "Enabled" : "Disabled";
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            LockToBottom = true;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var someNewMessageFromTheServer = string.Format("{0}: Some new message from the server", messageIndex);
            items.Add(someNewMessageFromTheServer);

            messageIndex += 1;
        }

        private void MyListviewLoaded(object sender, RoutedEventArgs e)
        {
            this.MyListView.ItemsSource = items;

            items.CollectionChanged += (s, args) => ScrollToBottom();

            var scrollViewer =
                MyListView.GetFirstDescendantOfType<ScrollViewer>();

            var scrollbars =
                scrollViewer.GetDescendantsOfType<ScrollBar>().ToList();

            var verticalBar = scrollbars.FirstOrDefault(x => x.Orientation == Orientation.Vertical);

            if (verticalBar != null)
                verticalBar.Scroll += BarScroll;

        }

        void BarScroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollEventType != ScrollEventType.EndScroll) return;

            var bar = sender as ScrollBar;
            if (bar == null)
                return;

            System.Diagnostics.Debug.WriteLine("Scrolling ended");

            if (e.NewValue >= bar.Maximum)
            {
                System.Diagnostics.Debug.WriteLine("We are at the bottom");
                LockToBottom = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("We are away from the bottom");
                LockToBottom = false;
            }
        }


        private void ScrollToBottom()
        {
            if (!LockToBottom)
                return;

            var selectedIndex = MyListView.Items.Count - 1;
            if (selectedIndex < 0)
                return;

            MyListView.SelectedIndex = selectedIndex;
            MyListView.UpdateLayout();

            MyListView.ScrollIntoView(MyListView.SelectedItem);
        }


    }
}
