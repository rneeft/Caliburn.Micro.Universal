namespace Chroomsoft.Caliburn.Universal
{
    public class StringFormatConverter : ValueConverterBase<object, string, string>
    {
        public override string Convert(object value, string param) => string.Format(param, value);
    }
}
