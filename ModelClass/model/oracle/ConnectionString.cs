using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.model.oracle
{
    public class ConnectionString
    {
        public  string returnConnection()
        {
            return "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.159.136.76 )(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = DBHCM)));Password= qlycDBBK4826;User ID=HDDT_BK";
        }
    }
}
