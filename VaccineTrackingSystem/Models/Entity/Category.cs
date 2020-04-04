using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class Category
    {
        /* id */
        public int id;

        /* 品类编码 */
        public string num;

        /***权限***/
        public string name;

        /****类别***/
        public string kind;

        /* 单位 */
        public string unit;

        /***规格***/
        public string spec;

        /****生产厂家***/
        public string factory;

        /****备注***/
        public string note;

        public Category(int id, string num, string name, string kind, string unit, string spec, string factory, string note)
        {
            this.id = id;
            this.num = num;
            this.name = name;
            this.kind = kind;
            this.unit = unit;
            this.spec = spec;
            this.factory = factory;
            this.note = note;
        }
    }
}