using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Models.Resources
{
    public class ObjectResource<T> : StatusResource where T : class, new()
    {
        public T Data { get; set; }
    }
}
