using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Chroomsoft.Caliburn.Universal.Base;

namespace Chroomsoft.Caliburn.Universal.ViewModels
{
    public abstract class ViewModelBase : Screen
    {
        private readonly PropertyHelper propertyHelper;

        protected ViewModelBase()
        {
            propertyHelper = new PropertyHelper(NotifyOfPropertyChange, this.GetType());
        }

        protected INavigationProvider NavigationProvider
        {
            get { return BaseApplication.NavigationProvider; }
        }

        protected IEventAggregator EventAggregator
        {
            get { return BaseApplication.EventAggregator; }
        }

        protected override void OnActivate()
        {
            EventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            EventAggregator.Unsubscribe(this);
        }

        protected T GetPropertyValue<T>([CallerMemberName] string propertyName = null) => propertyHelper.GetPropertyValue<T>(propertyName);
        protected bool SetPropertyValue<T>(T newValue, [CallerMemberName] string propertyName = null) => propertyHelper.SetPropertyValue(newValue, propertyName);
    }
}
