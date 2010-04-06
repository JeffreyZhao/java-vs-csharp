using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Closures
{
    public delegate T Func<T>();

    public delegate void Action<T>(T arg);
}
