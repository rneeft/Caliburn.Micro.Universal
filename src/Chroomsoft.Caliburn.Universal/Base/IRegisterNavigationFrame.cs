using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace Chroomsoft.Caliburn.Universal
{
    public interface IRegisterNavigationFrame
    {
        INavigationService RegisterNavigationService(Frame frame);
    }
}
