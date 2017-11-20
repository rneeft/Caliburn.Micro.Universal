using Chroomsoft.Caliburn.Universal;
using Example.ViewModels;

namespace Example
{
    public class AppContainer : BaseContainer
    {
        public override void RegisterApplicationComponents()
        {
        }

        public override void RegisterOtherViewModels()
        {
            this.RegisterViewModel<MainViewModel>();
        }
    }
}