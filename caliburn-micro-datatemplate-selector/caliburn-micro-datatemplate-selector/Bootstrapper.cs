using Caliburn.Micro;

namespace caliburn_micro_datatemplate_selector
{
    public class MyBootstrapper : Bootstrapper
    {
        private SimpleContainer container;
        protected override void Configure()
        {
            container = new SimpleContainer();

            container.PerRequest<MainPageViewModel>();

            Caliburn.Micro.ViewLocator.NameTransformer.AddRule("");
        }

        protected override object GetInstance(System.Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAllInstances(System.Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
