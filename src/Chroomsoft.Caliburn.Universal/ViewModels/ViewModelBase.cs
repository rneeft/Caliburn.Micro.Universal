using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
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
            this.PropertyChanged += ViewModelBasePropertyChanged;
            EventAggregator.Subscribe(this);
        }

        private async void ViewModelBasePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            await OnProperyChangedAsync(e.PropertyName);
        }

        protected virtual Task OnProperyChangedAsync(string propertyName) { return Task.FromResult(0); }

        protected override void OnDeactivate(bool close)
        {
            this.PropertyChanged -= ViewModelBasePropertyChanged;

            EventAggregator.Unsubscribe(this);
        }

        protected T GetPropertyValue<T>([CallerMemberName] string propertyName = null) => propertyHelper.GetPropertyValue<T>(propertyName);
        protected bool SetPropertyValue<T>(T newValue, [CallerMemberName] string propertyName = null) => propertyHelper.SetPropertyValue(newValue, propertyName);
    }
}
