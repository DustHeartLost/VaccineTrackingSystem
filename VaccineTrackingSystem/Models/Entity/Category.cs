namespace VaccineTrackingSystem.Models
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


        /****备注***/
        public string note;

        public Category(int id, string num, string name, string kind, string unit, string spec, string note)
        {
            this.id = id;
            this.num = num;
            this.name = name;
            this.kind = kind;
            this.unit = unit;
            this.spec = spec;
            this.note = note;
        }
        public Category(string num, string name, string kind, string unit, string spec, string note)
        {
            this.num = num;
            this.name = name;
            this.kind = kind;
            this.unit = unit;
            this.spec = spec;
            this.note = note;
        }
    }
}