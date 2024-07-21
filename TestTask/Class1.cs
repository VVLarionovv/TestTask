using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Class1
    {
        public class Request
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; set; } = "New";
            public string Courier { get; set; }
            public string CancellationReason { get; set; }
        }
    }
}
