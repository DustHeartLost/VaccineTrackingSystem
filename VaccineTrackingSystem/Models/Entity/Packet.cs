namespace VaccineTrackingSystem.Models.Entity
{
    public class Packet
    {
        public int code;
        public string data;
        public string extra;
        public string extra2;
        public Packet(int code, string data, string extra)
        {
            this.code = code;
            this.data = data;
            this.extra = extra;
        }
        public Packet(int code, string data)
        {
            this.code = code;
            this.data = data;
        }
        public Packet(int code, string data, string extra, string extra2)
        {
            this.code = code;
            this.data = data;
            this.extra = extra;
            this.extra2 = extra2;
        }
    }


}