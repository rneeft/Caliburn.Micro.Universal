namespace Chroomsoft.Caliburn.Universal
{
    public abstract class ViewModelBase<TModel> : ViewModelBase
    {
        public object Parameter { get; set; }

        protected override void OnActivate()
        {
            base.OnActivate();

            var model = (TModel)Parameter;
            OnActivate(model);
        }

        public abstract void OnActivate(TModel parameter);
    }
}
