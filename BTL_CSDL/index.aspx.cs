using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCayThuoc();
            }
        }

        private void loadCayThuoc()
        {
            DataTable dt = admin.dao.CayThuoc_DAO.getAllCayThuocClient();
            lv_danhsachcaythuoc.DataSource = dt;
            lv_danhsachcaythuoc.DataBind();
        }

        protected void lv_danhsachcaythuoc_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lv_danhsachcaythuoc.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadCayThuoc();
        }
        
        

    }
}