using Chroomsoft.Caliburn.Universal;

namespace Example.ViewModels
{
    public class ShellViewModel : ShellViewModelBase
    {
        public ShellViewModel(IRegisterNavigationFrame registerNavigation) : base(registerNavigation) { }

        public void ShowMain()
        {
            NavigationProvider.NavigateTo<MainViewModel>();
        }
    }
}