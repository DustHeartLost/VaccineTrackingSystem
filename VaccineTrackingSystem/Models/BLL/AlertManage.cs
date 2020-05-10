using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.BLL
{
    public class AlertManage
    {
        static public bool Add(Alert alert, out string msg)
        {
            return AlertDAL.Add(alert, out msg);
        }
        static public bool Update(Alert alert, out string msg)
        {
            return AlertDAL.Update(alert, out msg);
        }

        static public string QueryAll(out string msg)
        {
            List<Alert> list = AlertDAL.QueryAll(out msg);
            return list != null ? JsonConvert.SerializeObject(list) : null;
        }
        static public string GetAlert() {
            Dictionary<string, int> list = new Dictionary<string, int>();
            return list != null ? JsonConvert.SerializeObject(list) : null;
        }

        static public bool Destory(List<Alert> alerts, out string msg)
        {
            if (alerts == null || alerts.Count == 0)
            {
                msg = "没有记录需要销毁";
                return false;
            }
            for (int i = 0; i < alerts.Count; i++)
            {
                if (!AlertDAL.Delete(alerts[i].id, out msg))
                {
                    return false;
                }
            }
            msg = "";
            return true;
        }
    }
}