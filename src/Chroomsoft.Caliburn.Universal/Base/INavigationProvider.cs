using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public interface INavigationProvider
    {
        void SetNavigationService(INavigationService service);

        void NavigateTo<TViewModel>(object parameter = null) where TViewModel : ViewModelBase;

        bool IsActiveScreenTypeOf<TViewModel>() where TViewModel : Screen;

        void ResumeNavigationServiceState();

        void SuspendNavigationServiceState();

        void GoBack();
    }
}
