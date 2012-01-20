using Caliburn.Micro;

namespace caliburn_micro_datatemplate_selector
{
    public class MyBootstrapper : PhoneBootstrapper
    {
        private PhoneContainer container;
        protected override void Configure()
        {
            container = new PhoneContainer(RootFrame);
            container.RegisterPhoneServices();

            container.PerRequest<MainPageViewModel>();

            ViewLocator.NameTransformer.AddRule(typeof(File).FullName, typeof(FileView).FullName);
            ViewLocator.NameTransformer.AddRule(typeof (Folder).FullName, typeof (FolderView).FullName);
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
