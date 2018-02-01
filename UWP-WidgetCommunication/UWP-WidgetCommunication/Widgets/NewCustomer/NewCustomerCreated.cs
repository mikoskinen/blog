namespace UWP_WidgetDasboard.Widgets.NewCustomer
{
    public class NewCustomerCreated
    {
        public string FirstName { get;  }
        public string LastName { get; }

        public NewCustomerCreated(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}