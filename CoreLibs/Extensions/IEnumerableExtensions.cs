using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.Extensions
{
    public static class IEnumerableExtensions
    {
        //  --------------------------------------------------------------------------------
        /// <summary> Check if IEnumerable is null or empty. </summary>
        /// <param name="source"> IEnumerable. </param>
        /// <returns> True - IEnumerable is null or empty; False - otherwise. </returns>
        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            if (source != null)
            {
                foreach (object _ in source)
                    return false;
            }

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if IEnumerable is null or empty. </summary>
        /// <typeparam name="T"> IEnumerable object type. </typeparam>
        /// <param name="source"> IEnumerable. </param>
        /// <returns> True - IEnumerable is null or empty; False - otherwise. </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

    }
}
