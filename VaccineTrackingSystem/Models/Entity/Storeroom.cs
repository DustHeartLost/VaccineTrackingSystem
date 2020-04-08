namespace VaccineTrackingSystem.Models
{
    public class Storeroom
    {
        /* id */
        public int id;

        /* 名称 */
        public string name;

        /***位置***/
        public string site;


        /****库管员编号***/
        public string userNum;

        public Storeroom(int id, string name, string site, string userNum)
        {
            this.id = id;
            this.name = name;
            this.site = site;
            this.userNum = userNum;
        }
        public Storeroom(string name, string site, string userNum)
        {
            this.name = name;
            this.site = site;
            this.userNum = userNum;
        }
    }
}