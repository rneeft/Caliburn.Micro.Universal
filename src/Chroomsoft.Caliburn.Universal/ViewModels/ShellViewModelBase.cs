using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class ShellViewModelBase : ViewModelBase, IHandle<ResumeStateMessage>, IHandle<SuspendStateMessage>, IHandle<LoadingMessage>
    {
        private readonly IRegisterNavigationFrame registerNavigation;
        protected Frame shellFrame;
        protected bool resume;

        public ShellViewModelBase(IRegisterNavigationFrame registerNavigation)
        {
            this.registerNavigation = registerNavigation;
        }

        public bool IsLoaded
        {
            get { return GetPropertyValue<bool>(); }
            set { SetPropertyValue(value); }
        }

        public virtual Task OnAppLoadedAsync()
        {
            return Task.FromResult(0);
        }

        public void SetupNavigationService(Frame frame)
        {
            this.shellFrame = frame;

            NavigationProvider.SetNavigationService(registerNavigation.RegisterNavigationService(frame));

            if (resume)
                NavigationProvider.ResumeNavigationServiceState();
        }

        public void Handle(ResumeStateMessage message)
        {
            resume = true;
        }

        public void Handle(SuspendStateMessage message)
        {
            NavigationProvider.SuspendNavigationServiceState();
        }

        public void Handle(LoadingMessage message) => IsLoaded = message.IsLoading;
    }
}
