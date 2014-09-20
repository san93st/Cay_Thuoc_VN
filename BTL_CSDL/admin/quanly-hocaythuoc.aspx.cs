using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_hocaythuoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }


        /// <summary>
        /// Hàm dùng để load dữ liệu lên thành phần ListView sử dụng hàm trong class dao.HoCayThuoc_DAO.cs
        /// </summary>
        private void bindData()
        {
            DataTable dt = dao.HoCayThuoc_DAO.getAll_Hocaythuoc();
            ListView_HoCayThuoc.DataSource = dt;
            ListView_HoCayThuoc.DataBind();

        }

        /// <summary>
        /// Sự kiện khi chuyển trang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ListView_HoCayThuoc_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView_HoCayThuoc.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            bindData();// Sử dụng để load lại dữ liệu cho ListView sau khi chuyển trang khác
        }

        /// <summary>
        /// Sự kiện khi nhấn nút delete trong listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            LinkButton btn = (LinkButton)sender;
            String strMaHo = btn.CommandArgument;
            int maHo = int.Parse(strMaHo);
            if (dao.HoCayThuoc_DAO.delete(maHo))
            {
                Response.Redirect("quanly-hocaythuoc.aspx");
                
            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }


    }
}