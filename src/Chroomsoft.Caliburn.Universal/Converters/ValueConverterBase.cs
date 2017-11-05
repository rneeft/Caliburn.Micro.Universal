using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class ValueConverterBase<TIn, TOut> : IValueConverter
    {
        protected object Parameter { get; private set; }
        protected string Language { get; private set; }
        protected Type TargetType { get; private set; }

        public abstract TOut Convert(TIn value);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is TIn))
                return DependencyProperty.UnsetValue;

            this.Parameter = parameter;
            this.Language = language;
            this.TargetType = targetType;

            return Convert((TIn)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBack((TOut)value);
        }

        public virtual TIn ConvertBack(TOut value)
        {
            throw new NotImplementedException();
        }

        protected Visibility ToVisibility(bool predicate)
        {
            return predicate ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
