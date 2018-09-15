using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class ViewModelBase<TModel> : ViewModelBase, IHandle<ViewModelParameterChangedMessage>
    {
        public object Parameter { get; set; }

        public void Handle(ViewModelParameterChangedMessage message) => OnParameterUpdate((TModel)message.NewValue);

        public abstract void OnActivate(TModel parameter);

        public virtual void OnParameterUpdate(TModel newValue)
        {
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            var model = (TModel)Parameter;
            OnActivate(model);
        }
    }
}