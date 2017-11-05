using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace Chroomsoft.Caliburn.Universal.Base
{
    public interface IRegisterNavigationFrame
    {
        INavigationService RegisterNavigationService(Frame frame);
    }
}
