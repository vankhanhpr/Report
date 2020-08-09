using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.auth
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public Boolean active { get; set; }
        public int status { get; set; }
    }
}
