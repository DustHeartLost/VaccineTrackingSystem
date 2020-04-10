namespace VaccineTrackingSystem.Models.Entity
{
    public class Packet
    {
       public int code;
       public string data;
        
       public Packet(int code, string data) {
            this.code = code;
            this.data = data;
       }
    }

    
}