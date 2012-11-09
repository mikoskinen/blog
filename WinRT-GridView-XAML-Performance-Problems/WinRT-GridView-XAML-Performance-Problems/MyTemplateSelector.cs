using WinRT_GridView_XAML_Performance_Problems.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WinRT_GridView_XAML_Performance_Problems
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var movie = item as MovieInfo;
            if (movie != null)
                return (DataTemplate) App.Current.Resources["MovieTemplate"];

            return (DataTemplate)App.Current.Resources["MovieCategoryTemplate"];
        }
    }
}