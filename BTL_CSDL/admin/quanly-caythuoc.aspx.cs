using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_caythuoc : System.Web.UI.Page
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
            DataTable dt = dao.CayThuoc_DAO.getAllCayThuoc();
            lv_caythuoc.DataSource = dt;
            lv_caythuoc.DataBind();
        }

        protected void lv_caythuoc_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lv_caythuoc.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadCayThuoc();// Sử dụng để load lại dữ liệu cho ListView sau khi chuyển trang khác
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strMaCay = btn.CommandArgument;
            int id = int.Parse(strMaCay);
            if (dao.CayThuoc_DAO.deleteCayThuoc(id))
            {
                Response.Redirect("quanly-caythuoc.aspx");

            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }
    }
}