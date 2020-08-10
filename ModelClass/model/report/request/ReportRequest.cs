using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.model.report.request
{
    public class ReportRequest
    {
        public DateTime v_FROM_DATE { get; set; } //YYYY-MM-DD
        public DateTime v_TO_DATE { get; set; }   //YYYY-MM-DD

        public Int16 v_ID_NHOM_GIAI_DOAN { get; set; }
        public Int16 v_YEAR { get; set; }
        public Int16 v_MONTH { get; set; }
    }
}
