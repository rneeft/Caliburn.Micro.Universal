using System.Collections.ObjectModel;
using System.Linq;

namespace Chroomsoft.Caliburn.Universal.Base
{
    public class GroupedCollection<TKey, TItem> : ObservableCollection<TItem>
    {
        public GroupedCollection(IGrouping<TKey, TItem> group) : base(group)
        {
            this.GroupKey = group.Key;
        }

        public GroupedCollection(TKey groupKey, ObservableCollection<TItem> collection) : base(collection)
        {
            this.GroupKey = groupKey;
        }

        public TKey GroupKey
        {
            get;
            private set;
        }
    }
}
