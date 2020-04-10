namespace VaccineTrackingSystem.Models.Entity
{
    public class Packet
    {
        public int code;
        public string data;
        public string extra;

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
    }


}