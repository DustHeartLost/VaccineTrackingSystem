using System;
using System.Collections.Generic;

namespace VaccineTrackingSystem.VIew.Module.Role
{
    public partial class Role : System.Web.UI.Page
    {
        protected int totalPage;
        protected int currentPage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetString() {
            string msg;
            string jsonData = Models.BLL.RoleManage.QueryAll(out msg);
            return jsonData;
        }
    }
}