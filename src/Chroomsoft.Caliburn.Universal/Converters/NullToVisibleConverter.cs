using Windows.UI.Xaml;

namespace Chroomsoft.Caliburn.Universal
{
    public class NullToVisibleConverter : ValueConverterBase<object, Visibility>
    {
        public override Visibility Convert(object value) => ToVisibility(value == null);
    }
}
