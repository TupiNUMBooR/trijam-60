using System;
using System.Collections.Generic;
using System.Linq;
using URandom = UnityEngine.Random;


namespace Utils
{
    public static class ArrayUtils
    {
        public static T Random<T>(this IList<T> list, bool remove = false)
        {
            if (list.Count == 0) return default;

            var index = URandom.Range(0, list.Count);
            var result = list[index];

            if (remove)
                list.RemoveAt(index);

            return result;
        }

        public static T Random<T>(this IEnumerable<T> e, bool remove = false)
        {
            var a = e as T[] ?? e.ToArray();
            return Random(a, remove);
        }

        public static void ForEach<T>(this IList<T> list, Action<T, int> action)
        {
            for (var i = 0; i < list.Count; i++)
                action(list[i], i);
        }
    }
}