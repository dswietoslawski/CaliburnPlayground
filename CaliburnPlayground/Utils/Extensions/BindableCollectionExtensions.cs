using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Utils.Extensions
{
    public static class BindableCollectionExtensions
    {
        public static void ForEach<T>(this BindableCollection<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }
    }
}
