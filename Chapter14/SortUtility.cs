using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter14
{
  static class SortUtility
  {
    public enum SortOrder
    {
      Acending,
      Descending
    }

    public static IEnumerable<T> Sort<T>(IEnumerable<T> collection, SortOrder order)
    {
      return (order == SortOrder.Acending)
                    ? collection.OrderBy(v => v)
                    : collection.OrderByDescending(v => v);
    }

    public static Func<IEnumerable<T>, SortOrder, IEnumerable<T>> SortDelegate<T>()
    {
      return Sort<T>;
    }
  }
}
