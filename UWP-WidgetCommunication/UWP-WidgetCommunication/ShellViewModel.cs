using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace UWP_WidgetDasboard
{
    public class ShellViewModel : Conductor<IWidget>.Collection.AllActive
    {
        public ShellViewModel(IEnumerable<IWidget> widgets)
        {
            this.Items.AddRange(widgets);
        }
    }
}
