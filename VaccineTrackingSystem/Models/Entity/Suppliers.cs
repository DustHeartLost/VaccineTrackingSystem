namespace VaccineTrackingSystem.Models.Entity
{
    public class Suppliers
    {
        /* id */
        public int id;

        /* 名称 */
        public string name;

        /* 供应商代码 */
        public string code;

        public Suppliers(int id, string name, string code)
        {
            this.id = id;
            this.name = name;
            this.code = code;
        }

        public Suppliers(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public Suppliers() { }
    }
}