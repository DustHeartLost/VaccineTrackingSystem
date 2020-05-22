using Newtonsoft.Json;
using System.Collections.Generic;
using VaccineTrackingSystem.Models.DAL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.BLL
{
    public class DrugManage
    {
        static public bool Add(Drug drug, out string msg)
        {
            return DrugDAL.Add(drug, out msg);
        }


        static public bool Update(Drug drug, out string msg)
        {
            return DrugDAL.Update(drug, out msg);
        }
        static public string Query(string num, out string msg)
        {
            List<Drug> list = new List<Drug>();
            if (DrugDAL.Query(num, out msg) != null)
                list.Add(DrugDAL.Query(num, out msg));
            else
                return null;
            return JsonConvert.SerializeObject(list);
        }

        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
        {
            List<Drug> list = DrugDAL.QueryAll(out msg);
            if (list == null)
            {
                totalPage = 0;
                currentPage = -1;
                return null;
            }
            totalPage = (int)System.Math.Floor((decimal)(list.Count / 10));
            if (list.Count != 0 && list.Count % 10 == 0)
                --totalPage;
            if (currentPage < totalPage)
                ++currentPage;
            try
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, 10));
            }
            catch
            {
                return JsonConvert.SerializeObject(list.GetRange(currentPage * 10, list.Count - currentPage * 10));
            }
        }

        static public bool Destory(List<int> drugs, out string msg)
        {
            if (drugs == null || drugs.Count == 0)
            {
                msg = "没有记录需要销毁";
                return false;
            }
            for (int i = 0; i < drugs.Count; i++)
            {
                if (!DrugDAL.Delete(drugs[i], out msg))
                {
                    return false;
                }
            }
            msg = "";
            return true;
        }

        static public Dictionary<string, int> GetDrug()
        {
            return DrugDAL.GetDrug();
        }

    }
}