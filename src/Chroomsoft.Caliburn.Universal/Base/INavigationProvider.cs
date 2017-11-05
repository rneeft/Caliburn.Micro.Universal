using Caliburn.Micro;
using Chroomsoft.Caliburn.Universal.ViewModels;

namespace Chroomsoft.Caliburn.Universal.Base
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
