﻿namespace VaccineTrackingSystem.Models
{
    public class Apartment
    {
        /* id */
        public int id;

        /*编号 */
        public string num;

        /* 名称 */
        public string name;

        /* 密保答案 */
        public string note;

        public Apartment(int id, string num, string name, string note)
        {
            this.id = id;
            this.num = num;
            this.name = name;
            this.note = note;
        }

        public Apartment(string num, string name, string note)
        {
            this.num = num;
            this.name = name;
            this.note = note;
        }



    }
}