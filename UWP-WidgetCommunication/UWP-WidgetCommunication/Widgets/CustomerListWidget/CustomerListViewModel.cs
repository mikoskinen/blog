using Caliburn.Micro;
using UWP_WidgetDasboard.Widgets.CustomerInfo;
using UWP_WidgetDasboard.Widgets.NewCustomer;

namespace UWP_WidgetDasboard.Widgets.CustomerListWidget
{
    public class CustomerListViewModel : Conductor<Customer>.Collection.AllActive, IWidget, IHandle<NewCustomerCreated>
    {
        public CustomerListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

            this.Items.Add(new Customer("Test", "Customer"));
            this.Items.Add(new Customer("Another", "One"));
            this.Items.Add(new Customer("Mikael", "Koskinen"));
        }

        public void Handle(NewCustomerCreated message)
        {
            // Event aggregator
            this.Items.Add(new Customer(message.FirstName, message.LastName));
        }

        public void AddNewCustomer(string firstName, string lastName)
        {
            // Direct communication
            this.Items.Add(new Customer(firstName, lastName));
        }
    }
}
