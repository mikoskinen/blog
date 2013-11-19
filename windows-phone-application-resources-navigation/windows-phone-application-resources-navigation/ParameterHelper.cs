using System.Windows;

namespace windows_phone_application_resources_navigation
{
    public static class ParameterHelper
    {
        private const string NavigationParamKey = "NavigationParam";

        public static void Store(object data)
        {
            if (Application.Current.Resources.Contains(NavigationParamKey))
                Application.Current.Resources.Remove(NavigationParamKey);

            Application.Current.Resources.Add(NavigationParamKey, data);
        }

        public static T Get<T>() where T : class
        {
            if (!Application.Current.Resources.Contains(NavigationParamKey))
                return null;

            return Application.Current.Resources[NavigationParamKey] as T;
        }
    }
}