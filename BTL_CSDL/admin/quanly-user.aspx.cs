using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData_QUanLy();
            }
        }

        private void loadData_QUanLy()
        {
            DataTable dt = dao.QuanLy_DAO.getAllQuanLy();
            ListView_QuanLy.DataSource = dt;
            ListView_QuanLy.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strMaQL = btn.CommandArgument;
            if (dao.QuanLy_DAO.deleteQuanLy(strMaQL))
            {
                Response.Redirect("quanly-user.aspx");

            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }

        protected void ListView_QuanLy_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_QuanLy.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadData_QUanLy();// Sử dụng để load lại dữ liệu cho ListView sau khi chuyển trang khác
        }
    }
}