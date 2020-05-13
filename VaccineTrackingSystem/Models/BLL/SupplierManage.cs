using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineTrackingSystem.Models.DAL;
using VaccineTrackingSystem.Models.Entity;

namespace VaccineTrackingSystem.Models.BLL
{
    public class SupplierManage
    {
        static public bool Add(Suppliers suppliers, out string msg)
        {
            return SupplierDAL.Add(suppliers, out msg);
        }

        static public bool Update(Suppliers suppliers, out string msg)
        {
            return SupplierDAL.Update(suppliers, out msg);
        }
        static public string Query(string name, out string msg)
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            if (SupplierDAL.Query(name, out msg) != null)
                suppliers.Add(SupplierDAL.Query(name, out msg));
            else
                return null;
            return JsonConvert.SerializeObject(suppliers);
        }
        static public string QueryAll(out string msg, ref int totalPage, ref int currentPage)
        {
            List<Suppliers> list = SupplierDAL.QueryAll(out msg);
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
        static public List<string> GetSuppliers()
        {
            return SupplierDAL.GetSuppliers();
        }

        static public bool Destory(List<int> list, out string msg)
        {
            if (list == null || list.Count == 0)
            {
                msg = "没有记录需要销毁";
                return false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (!SupplierDAL.Delete(list[i], out msg))
                {
                    return false;
                }
            }
            msg = "";
            return true;
        }
    }
}