using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_lienhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData_LienHeChuaXuLy();
                loadData_LienHeDaXuLy();
            }
        }

        /// <summary>
        /// Hàm dùng để load tất cả các liên hệ chưa được người quản lý xử lý
        /// </summary>
        private void loadData_LienHeChuaXuLy()
        {
            DataTable dt = dao.LienHe_DAO.getLienHeChuaXuLy();
            ListView_ChuaLienHe.DataSource = dt;
            ListView_ChuaLienHe.DataBind();
        }
        private void loadData_LienHeDaXuLy()
        {
            DataTable dt = dao.LienHe_DAO.getLienHeDaXuLy();
            if (dt.Rows.Count > 0)
            {
                listview_dalienhe.DataSource = dt;
                listview_dalienhe.DataBind();
            }
            else
            {
                lbDisplayDaLienHe.Text = "Không có dữ liệu!";
            }
        }

        protected void ListView_ChuaLienHe_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_ChuaLienHe.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadData_LienHeChuaXuLy();
        }

        protected void listview_dalienhe_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_ChuaLienHe.FindControl("datapager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadData_LienHeDaXuLy();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strEmail = btn.CommandArgument;
            if (dao.LienHe_DAO.xoaLienHe(strEmail))
            {
                Response.Redirect("quanly-lienhe.aspx");

            }
            else
            {
                lbDisplayDaLienHe.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }
    }
}