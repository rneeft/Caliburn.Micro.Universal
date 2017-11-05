using Windows.UI.Xaml;

namespace Chroomsoft.Caliburn.Universal
{
    public class InvertedBooleanToVisibilityConverter : ValueConverterBase<bool, Visibility>
    {
        public override Visibility Convert(bool value) => ToVisibility(!value);
    }
}
