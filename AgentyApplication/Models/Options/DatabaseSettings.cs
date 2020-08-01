using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Models.Options
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
