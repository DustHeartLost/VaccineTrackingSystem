using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class Role
    {
        /* id */
        public int id;

        /* 名称 */
        public string name;

        /***权限***/


        /****备注***/
        public string note;

        public Role(int id, string name, string note)
        {
            this.id = id;
            this.name = name;
            this.note = note;
        }
    }
}