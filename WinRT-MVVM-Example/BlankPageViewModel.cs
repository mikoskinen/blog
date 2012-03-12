using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application6
{
    public class BlankPageViewModel
    {
        private readonly NavigationService navigation;

        public BlankPageViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }

        public DelegateCommand GoToNextPage
        {
            get
            {
                return new DelegateCommand(x => navigation.Navigate<SecondPage>(), x => true);
            }
        }
    }
}
