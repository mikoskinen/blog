using Caliburn.Micro;

namespace UWP_WidgetDasboard.Widgets.UserCount
{
    public class UserCountViewModel : Screen, IWidget
    {
        public double[] Items { get; set; }

        public UserCountViewModel()
        {
            this.Items = new double[] {20, 30, 50, 10, 60, 40, 20, 80};
        }
    }
}
