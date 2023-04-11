using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.Extensions
{
    public static class ObservableCollectionExtension
    {

        //  --------------------------------------------------------------------------------
        /// <summary> This method removes all items which matches the predicate. </summary>
        /// <typeparam name="T"> ObservableCollection object type. </typeparam>
        /// <param name="source"> ObservableCollection. </param>
        /// <param name="match"> The predicate in T delegate that defines the conditions of the elements to remove. </param>
        /// <returns> The number of elements removed from ObservableCollection. </returns>
        public static int RemoveAll<T>(this ObservableCollection<T> source, Func<T, bool> match)
        {
            var itemsToRemove = source.Where(match).ToList();

            foreach (var itemToRemove in itemsToRemove)
                source.Remove(itemToRemove);

            return itemsToRemove.Count;
        }

    }
}
