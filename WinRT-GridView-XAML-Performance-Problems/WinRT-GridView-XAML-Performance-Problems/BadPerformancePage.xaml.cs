using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace WinRT_GridView_XAML_Performance_Problems
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class BadPerformancePage
    {
        private readonly MoviesVm viewModel = new MoviesVm();
    
        public BadPerformancePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                return;

            this.DataContext = viewModel;
            this.viewModel.CreateBadPerformingData();
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(MovieDetailsPage));
        }
    }

}
