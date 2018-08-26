using System.Collections.Generic;
using System.Collections.Specialized;

namespace Chroomsoft.Caliburn.Universal
{
    /// <summary> List with observable items that changed as a whole instead of item based. For Item
    /// based observable list use the <see
    /// cref="System.Collections.ObjectModel.ObservableCollection<TItem>"/> </summary>
    public class ObservableList<TItem> : List<TItem>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Removed all the items in the list, add the list of items and notify the observers.
        /// </summary>
        /// <param name="items">Items to add</param>
        public void ClearAddRange(IEnumerable<TItem> items)
        {
            this.Clear();
            this.AddRange(items);

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}