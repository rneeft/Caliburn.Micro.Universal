using Windows.UI.Xaml;

namespace Chroomsoft.Caliburn.Universal
{
    public class NullToCollapsedConverter : ValueConverterBase<object, Visibility>
    {
        public override Visibility Convert(object value) => ToVisibility(value != null);
    }
}
