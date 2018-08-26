using Windows.UI.Xaml;

namespace Chroomsoft.Caliburn.Universal
{
    public class ToggleVisibilityConverter : ValueConverterBase<Visibility, Visibility>
    {
        public override Visibility Convert(Visibility value) => ToVisibility(value != Visibility.Visible);
    }
}