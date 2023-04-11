using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.Extensions
{
    public static class IListExtensions
    {

        //  --------------------------------------------------------------------------------
        /// <summary> Check if IList is null or empty. </summary>
        /// <param name="source"> IList. </param>
        /// <returns> True - IList is null or empty; False - otherwise. </returns>
        /*public static bool IsNullOrEmpty(this IList source)
        {
            if (source != null)
            {
                foreach (object _ in source)
                    return false;
            }

            return true;
        }*/

        //  --------------------------------------------------------------------------------
        /// <summary> Check if IList is null or empty. </summary>
        /// <typeparam name="T"> IList object type. </typeparam>
        /// <param name="source"> IList. </param>
        /// <returns> True - IList is null or empty; False - otherwise. </returns>
        public static bool IsNullOrEmpty<T>(this IList<T> source)
        {
            return source == null || !source.Any();
        }

    }
}
