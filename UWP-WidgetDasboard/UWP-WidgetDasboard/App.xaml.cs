using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;

namespace UWP_WidgetDasboard
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        private WinRTContainer container;

        public App()
        {
            Initialize();
            InitializeComponent();
        }

        protected override void Configure()
        {
            container = new WinRTContainer();
            container.RegisterWinRTServices();

            container.Singleton<ShellViewModel>();
            AddWidgets();
        }

        private void AddWidgets()
        {
            var types = typeof(ShellViewModel).GetTypeInfo().Assembly.GetTypes().ToList();
            var widgets = types.Where(type => type.GetTypeInfo().IsClass && System.Reflection.TypeExtensions.IsAssignableFrom(typeof(IWidget), type)).ToList();

            foreach (var widget in widgets)
            {
                container.RegisterPerRequest(typeof(IWidget), null, widget);
            }
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootView<ShellView>();
        }


        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
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
    }
}
