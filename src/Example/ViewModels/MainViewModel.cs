using Chroomsoft.Caliburn.Universal;

namespace Example.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string FirstName
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public string LastName
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        [NotifiesOn(nameof(FirstName))]
        [NotifiesOn(nameof(LastName))]
        public string FullName => FirstName + " " + LastName;
    }
}