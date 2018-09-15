using Chroomsoft.Caliburn.Universal;

namespace Example.ViewModels
{
    public class ShellViewModel : ShellViewModelBase
    {
        public ShellViewModel(IRegisterNavigationFrame registerNavigation) : base(registerNavigation)
        {
        }

        public string SearchQuery
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public void ShowMain()
        {
            NavigationProvider.NavigateTo<MainViewModel>();
        }

        public void Search()
        {
            NavigationProvider.NavigateTo<SearchViewModel>(SearchQuery);
        }
    }
}