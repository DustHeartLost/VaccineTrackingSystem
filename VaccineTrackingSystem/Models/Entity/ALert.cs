using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineTrackingSystem.Models.Entity
{
    public class Alert
    {
        public int id;
        public int days;
        public string color;

        public Alert() { }
        public Alert(int id,int days,string color) {
            this.id = id;
            this.color = color;
            this.days = days;
        }
        public Alert(int days,string color) {
            this.color = color;
            this.days = days;
        }
    }
}