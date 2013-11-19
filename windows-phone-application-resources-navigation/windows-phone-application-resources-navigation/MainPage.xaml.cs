using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace windows_phone_application_resources_navigation
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Navigate_OnClick(object sender, RoutedEventArgs e)
        {
            var customers = GetCustomers();

            // Calling this line twice throws an exception. Remember to clear the current data from Application.Resources before setting it again.
            Application.Current.Resources.Add("NavigationParam", customers);

            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }

        private void NavigateUsingHelper_OnClick(object sender, RoutedEventArgs e)
        {
            var customers = GetCustomers();
            ParameterHelper.Store(customers);

            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer(1, "Test User 1"),
                new Customer(2, "Test User 2"),
                new Customer(3, "Test User 3")
            };

            return customers;
        }

    }

    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}