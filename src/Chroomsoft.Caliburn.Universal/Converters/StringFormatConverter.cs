namespace Chroomsoft.Caliburn.Universal.Converters
{
    public class StringFormatConverter : ValueConverterBase<object, string, string>
    {
        public override string Convert(object value, string param) => string.Format(param, value);
    }
}
