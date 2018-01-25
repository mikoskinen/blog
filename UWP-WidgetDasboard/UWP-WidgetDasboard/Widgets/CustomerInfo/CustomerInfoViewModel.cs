using Caliburn.Micro;

namespace UWP_WidgetDasboard.Widgets.CustomerInfo
{
    public class CustomerInfoViewModel : Screen, IWidget
    {
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }

        protected override void OnActivate()
        {
            this.Customer = new Customer("Mikael", "Koskinen");
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
