using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application6
{
    public class SecondPageViewModel
    {
        private readonly NavigationService navigation;

        public SecondPageViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }

        public DelegateCommand GoBack
        {
            get
            {
                return new DelegateCommand(x => navigation.GoBack(), x => true);
            }
        }
    }
}
