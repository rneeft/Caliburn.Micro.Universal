using System.Collections.ObjectModel;
using Chroomsoft.Caliburn.Universal;

namespace Example.ViewModels
{
    public class SearchViewModel : ViewModelBase<string>
    {
        public SearchViewModel()
        {
            History = new ObservableCollection<string>();
        }

        public string SearchQuery
        {
            get { return GetPropertyValue<string>(); }
            set { SetPropertyValue(value); }
        }

        public ObservableCollection<string> History { get; }

        public override void OnActivate(string parameter)
        {
            History.Clear();
            SearchQuery = parameter;
        }

        public override void OnParameterUpdate(string newValue)
        {
            History.Insert(0, SearchQuery);
            SearchQuery = newValue;
        }
    }
}