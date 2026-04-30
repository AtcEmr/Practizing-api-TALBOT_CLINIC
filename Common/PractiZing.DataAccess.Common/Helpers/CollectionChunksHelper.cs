using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.DataAccess.Common.Helpers
{
    public static partial class CollectionChunksHelper
    {
        public static List<List<T>> Chunk<T>(IEnumerable<T> data, int size)
        {
            return data
              .Select((x, i) => new { Index = i, Value = x })
              .GroupBy(x => x.Index / size)
              .Select(x => x.Select(v => v.Value).ToList())
              .ToList();
        }
    }
}
