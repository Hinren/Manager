using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.Utilities
{
    public static class EnumUtilities
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of enum values. </summary>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <returns> List of enum values. </returns>
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

    }
}
