namespace Chroomsoft.Caliburn.Universal
{ 
    public abstract class ValueConverterBase<TIn, TOut> : ValueConverterBase<TIn, TOut, object>
    {
        public abstract TOut Convert(TIn value);

        public override TOut Convert(TIn value, object param) => Convert(value);
    }
}
