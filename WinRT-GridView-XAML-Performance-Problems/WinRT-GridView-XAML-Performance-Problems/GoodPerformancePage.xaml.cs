using WinRT_GridView_XAML_Performance_Problems.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WinRT_GridView_XAML_Performance_Problems
{
    public sealed partial class GoodPerformancePage
    {
        private readonly MoviesVm viewModel = new MoviesVm();
        public GoodPerformancePage()
        {
            this.InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                return;

            this.DataContext = viewModel;
            this.viewModel.CreateDataWithGreatPerformance();
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is MovieInfo)
                this.Frame.Navigate(typeof (MovieDetailsPage));
            else
                this.Zoom.IsZoomedInViewActive = false;
        }

        private void SemanticZoom_OnViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (e.IsSourceZoomedInView)
                return;

            this.itemGridView.Opacity = 0;
        }

        private void SemanticZoom_OnViewChangeCompleted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (e.IsSourceZoomedInView)
                return;

            try
            {
                var selectedGroup = e.SourceItem.Item as string;
                if (selectedGroup == null)
                    return;

                itemGridView.ScrollIntoView(selectedGroup, ScrollIntoViewAlignment.Leading);
            }
            finally
            {
                this.itemGridView.Opacity = 1;
            }
        }
    }
}
