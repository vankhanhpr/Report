using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.area.response
{
    public class DataRespond
    {
        public Boolean success { get; set; }
        public dynamic data { get; set; }
        public string message { get; set; }
        public dynamic error { get; set; }
    }
}
