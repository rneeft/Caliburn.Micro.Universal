﻿using System.Linq;

namespace Chroomsoft.Caliburn.Universal
{
    public class GroupedCollection<TKey, TItem> : System.Collections.ObjectModel.ObservableCollection<TItem>
    {
        public GroupedCollection(IGrouping<TKey, TItem> group) : base(group)
        {
            this.GroupKey = group.Key;
        }

        public GroupedCollection(TKey groupKey, System.Collections.ObjectModel.ObservableCollection<TItem> collection) : base(collection)
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