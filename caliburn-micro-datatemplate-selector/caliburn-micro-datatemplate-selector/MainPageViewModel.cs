using System.Collections.Generic;
using Caliburn.Micro;

namespace caliburn_micro_datatemplate_selector
{
    public class MainPageViewModel : Conductor<object>.Collection.AllActive
    {
        protected override void OnInitialize()
        {
            Items.AddRange(new List<object>()
                               {
                                   new Folder(1, "Folder 1", null),
                                   new Folder(2, "Folder 2", null),
                                   new File(1, "File 1", 30.0),
                                   new File(2, "File 2", 30.0),
                                   new File(3, "File 3", 30.0),
                                   new Folder(4, "Folder 3", null),
                               });
        }
    }
}
