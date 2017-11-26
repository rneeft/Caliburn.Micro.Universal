namespace Chroomsoft.Caliburn.Universal
{
    public class InvertedBooleanConverter : ValueConverterBase<bool, bool>
    {
        public override bool Convert(bool value) => !value;
    }
}