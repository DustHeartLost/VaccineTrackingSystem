﻿namespace VaccineTrackingSystem.Models
{
    public class Role
    {
        /* id */
        public int id;

        /* 名称 */
        public string name;

        /***权限***/
        public string authority;

        /****备注***/
        public string note;

        public Role(int id, string name, string authority, string note)
        {
            this.id = id;
            this.name = name;
            this.note = note;
            this.authority = authority;
        }

        public Role(string name, string authority, string note)
        {
            this.name = name;
            this.note = note;
            this.authority = authority;
        }
    }
}