using Caliburn.Micro;

namespace UWP_WidgetDasboard.Widgets.Pie
{
    public class PieViewModel : Screen, IWidget
    {
        public double[] Items { get; set; }

        public PieViewModel()
        {
            this.Items = new double[] { 20, 45, 35 };
        }
    }
}
