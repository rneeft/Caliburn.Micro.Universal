using System;
using System.Collections.Generic;
using System.Diagnostics;
using Caliburn.Micro;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class BaseApplication : CaliburnApplication, IRegisterNavigationFrame
    {
        protected BaseContainer container;
        private Frame rootFrame;
        private LaunchActivatedEventArgs args;
        public static IEventAggregator EventAggregator { get; private set; }
        public static INavigationProvider NavigationProvider { get; private set; }

        public bool IsRootFrameAvailable
        {
            get { return rootFrame != null; }
        }

        public bool CanRootFrameGoBack
        {
            get { return rootFrame.CanGoBack; }
        }

        public void NavigateBack()
        {
            rootFrame.GoBack();
        }

        public INavigationService RegisterNavigationService(Frame frame)
        {
            this.rootFrame = frame;
            return container.RegisterNavigationService(frame);
        }

        public TService GetInstance<TService>(string key = null) where TService : class
        {
            return container.GetInstance<TService>(key);
        }

        protected override void Configure()
        {
            Debug.WriteLine("0. InitializeContainer");
            InitializeContainer();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            this.args = args;

            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            Debug.WriteLine("1. RegisterSpecialValues");
            RegisterSpecialValues();

            Debug.WriteLine("2. DisplayRootViewFor");
            HandoffShellView();
        }

        protected abstract Type ShellViewModelType();

        protected abstract BaseContainer CreateContainer();

        protected virtual void RegisterSpecialValues()
        {
        }

        protected void RegisterEventHandlerFor<T>(string key)
        {
            if (!MessageBinder.SpecialValues.ContainsKey(key))
                MessageBinder.SpecialValues.Add(key, x => (T)((ItemClickEventArgs)x.EventArgs).ClickedItem);
        }

        protected override void OnSuspending(object sender, SuspendingEventArgs e)
        {
            EventAggregator.PublishOnUIThread(new SuspendStateMessage(e.SuspendingOperation));
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        private void InitializeContainer()
        {
            container = CreateContainer();
            container.Initialize(this);

            EventAggregator = container.GetInstance<IEventAggregator>();
            NavigationProvider = container.GetInstance<INavigationProvider>();
            EventAggregator.Subscribe(this);

            container.RegisterApplicationComponents();
            container.RegisterShellViewModelAsSingleton(ShellViewModelType());
            container.RegisterOtherViewModels();

            Debug.WriteLine("0. InitializeContainer DONE");
        }

        private void HandoffShellView()
        {
            DisplayRootViewFor(ShellViewModelType());
        }

        private void BroadcastResumeStateMessageIfNeeded(ApplicationExecutionState previousExecutionState)
        {
            if (previousExecutionState == ApplicationExecutionState.Terminated)
                EventAggregator.PublishOnUIThread(new ResumeStateMessage());
        }
    }
}