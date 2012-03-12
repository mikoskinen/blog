using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application6
{
    public class ViewModelLocator
    {
        public BlankPageViewModel BlankPageViewModel
        {
            get
            {
                return new BlankPageViewModel(App.NavigationService);
            }
        }

        public SecondPageViewModel SecondPageViewModel
        {
            get
            {
                return new SecondPageViewModel(App.NavigationService);
            }
        }
    }
}
