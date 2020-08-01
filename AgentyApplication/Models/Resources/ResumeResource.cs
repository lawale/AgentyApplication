using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Models.Resources
{
    public class ResumeResource
    {
        public string ResumeId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public string Experience { get; set; }
    }
}
