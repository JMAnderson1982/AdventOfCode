namespace AdventOfCode.Shared.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ListExtension
    {
        public static T Shift<T>(this List<T> list)
        {
            var o = list[0];
            list.RemoveAt(0);
            return o;
        }
        
        public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}