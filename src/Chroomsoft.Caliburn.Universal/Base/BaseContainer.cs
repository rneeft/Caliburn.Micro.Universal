using System;
using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class BaseContainer : WinRTContainer
    {
        public void Initialize(IRegisterNavigationFrame frameRegister)
        {
            RegisterWinRTServices();
            this.Singleton<INavigationProvider, NavigationProvider>();
            RegisterInstance(typeof(IRegisterNavigationFrame), null, frameRegister);
        }

        public abstract void RegisterApplicationComponents();
        public abstract void RegisterOtherViewModels();

        public void RegisterShellViewModelAsSingleton(Type shellViewModel)
        {
            this.RegisterSingleton(shellViewModel, null, shellViewModel);
        }

        public void RegisterSingleton<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            this.RegisterSingleton(typeof(TService), null, typeof(TImplementation));
        }

        public TService GetInstance<TService>() where TService : class
        {
            return (TService)this.GetInstance(typeof(TService), null);
        }

        public void RegisterInstance<TService>(TService service) where TService : class
        {
            this.RegisterInstance(typeof(TService), null, service);
        }

        public void RegisterViewModel<TViewModel>() where TViewModel : ViewModelBase
        {
            this.PerRequest<TViewModel>();
        }
    }
}