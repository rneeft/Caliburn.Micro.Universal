using System;
using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class BaseContainer : WinRTContainer
    {
        /// <summary>
        /// Gets the default key for every DI call.
        /// </summary>
        public virtual string DefaultContainerKey
        {
            get { return null; }
        }

        public void Initialize(IRegisterNavigationFrame frameRegister)
        {
            RegisterWinRTServices();
            this.Singleton<INavigationProvider, NavigationProvider>();
            RegisterInstance(typeof(IRegisterNavigationFrame), DefaultContainerKey, frameRegister);
        }

        public abstract void RegisterApplicationComponents();

        public abstract void RegisterOtherViewModels();

        public void RegisterShellViewModelAsSingleton(Type shellViewModel)
        {
            this.RegisterSingleton(shellViewModel, DefaultContainerKey, shellViewModel);
        }

        public void RegisterSingleton<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            this.RegisterSingleton(typeof(TService), DefaultContainerKey, typeof(TImplementation));
        }

        public TService GetInstance<TService>() where TService : class
        {
            return (TService)this.GetInstance(typeof(TService), DefaultContainerKey);
        }

        public void RegisterInstance<TService>(TService service) where TService : class
        {
            this.RegisterInstance(typeof(TService), DefaultContainerKey, service);
        }

        public void RegisterViewModel<TViewModel>() where TViewModel : ViewModelBase
        {
            this.PerRequest<TViewModel>();
        }
    }
}