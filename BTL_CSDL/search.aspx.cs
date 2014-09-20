using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Request.QueryString["search"] != null && Request.QueryString["type"]!=null)
                    loadResult(Request.QueryString["search"].ToString(), Request.QueryString["type"].ToString());
                else
                    Response.Redirect("index.aspx");
            
        }

        private void loadResult(string p,String type)
        {
            if (type.Equals("caythuoc"))
            {
                DataTable dt = admin.dao.CayThuoc_DAO.searchTenCayThuoc(p);
                lv_Result.DataSource = dt;
                lv_Result.DataBind();
            }
            else if(type.Equals("hocaythuoc"))
            {
                DataTable dt = admin.dao.CayThuoc_DAO.searchhocaythuoc(p);
                lv_Result.DataSource = dt;
                lv_Result.DataBind();
            }
            else if (type.Equals("baithuoc"))
            {
                DataTable dt = admin.dao.CayThuoc_DAO.searchBaiThuoc(p);
                lv_Result.DataSource = dt;
                lv_Result.DataBind();
            }
            else {
                Response.Redirect("index.aspx");
            }

        }

        protected void lv_Result_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lv_Result.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadResult(Request.QueryString["search"].ToString(),Request.QueryString["type"].ToString());
        }
    }
}