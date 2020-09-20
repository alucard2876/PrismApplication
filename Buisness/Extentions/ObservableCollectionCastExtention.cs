using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Buisness.Extentions
{
    public static class ObservableCollectionCastExtention
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return new ObservableCollection<T>();
            return new ObservableCollection<T>(source);
        }
    }
}
