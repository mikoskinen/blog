using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace windows_phone_application_resources_navigation
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var customers = (List<Customer>) Application.Current.Resources["NavigationParam"];

            this.Customers.Text = string.Join(", ", customers.Select(x => x.Name));
        }
    }
}