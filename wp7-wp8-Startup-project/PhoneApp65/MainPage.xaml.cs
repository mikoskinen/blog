using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace MainProject
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
                NavigationService.RemoveBackEntry();
        }
    }
}