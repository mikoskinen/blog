using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace caliburn_micro_winrt_getting_started
{
    sealed partial class App : Caliburn.Micro.CaliburnApplication
    {
        private WinRTContainer container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            base.Configure();

            container = new WinRTContainer(RootFrame);
            container.RegisterWinRTServices();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override Type GetDefaultView()
        {
            return typeof(MainPage);
        }
    }
}
