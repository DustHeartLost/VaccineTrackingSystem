namespace VaccineTrackingSystem.Models.Entity
{
    public class Drug
    {

        /* id */
        public int id;

        /*编号 */
        public string kind;

        public Drug(int id, string kind)
        {
            this.id = id;
            this.kind = kind;
        }

    }
}