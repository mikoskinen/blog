using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using UWP_WidgetDasboard.Widgets.CustomerListWidget;

namespace UWP_WidgetDasboard.Widgets.NewCustomer
{
    public class NewCustomerViewModel : Screen, IWidget
    {
        private string _lastName;
        private string _firstName;
        private readonly IEventAggregator _eventAggregator;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string LastName  
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public bool CanSave
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FirstName))
                    return false;
                if (string.IsNullOrWhiteSpace(LastName))
                    return false;

                return true;
            }
        }

        public NewCustomerViewModel(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
        }

        public void Save()
        {
            // Direct communication
            //var widgets = ((ShellViewModel) this.Parent).Items;
            //foreach (var widget in widgets)
            //{
            //    if (widget is CustomerListViewModel customerList)
            //    {
            //        customerList.AddNewCustomer(FirstName, LastName);
            //    }
            //}

            // Event aggregator
            this._eventAggregator.PublishOnUIThread(new NewCustomerCreated(FirstName, LastName));
        }
    }
}