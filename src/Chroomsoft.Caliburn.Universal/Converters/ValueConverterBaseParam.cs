﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class ValueConverterBase<TIn, TOut, TParam> : IValueConverter
    {
        protected string Language { get; private set; }
        protected Type TargetType { get; private set; }

        public abstract TOut Convert(TIn value, TParam param);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is TIn))
                return DependencyProperty.UnsetValue;

            this.Language = language;
            this.TargetType = targetType;

            return Convert((TIn)value, (TParam)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBack((TOut)value, (TParam)parameter);
        }

        public virtual TIn ConvertBack(TOut value, TParam param)
        {
            throw new NotImplementedException();
        }

        protected Visibility ToVisibility(bool predicate)
        {
            return predicate ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
