using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class baithuoc_caythuoc : System.Web.UI.Page
    {
        private int macay;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                macay = int.Parse(Request.QueryString["id"].ToString());
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    lbTitle.Text = "Các bài thuốc của cây thuốc " + dao.CayThuoc_DAO.getTenHienThi_MaCay(macay);
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    loadBaiThuoc(id);
                }
            }
        }

        private void loadBaiThuoc(int id)
        {
            DataTable dt = dao.baithuoc_DAO.getBaiThuoc_MaCay(id);
            lv_baithuoc.DataSource = dt;
            lv_baithuoc.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strMaBT = btn.CommandArgument;
            int id = int.Parse(strMaBT);
            if (dao.baithuoc_DAO.delete_baithuoc(id))
            {
                Response.Redirect("baithuoc-caythuoc.aspx?id=" + macay);

            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strMaBT = btn.CommandArgument;
            int id = int.Parse(strMaBT);
            DataTable dt = dao.baithuoc_DAO.getBaiThuoc_MaBT(id);
            txtMaBT.Text = dt.Rows[0][0].ToString();
            txtND.Text = dt.Rows[0][2].ToString();

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            String strId = txtMaBT.Text;
            if (strId.Length > 0)
            {
                int mabt = int.Parse(strId);
                String strBT = txtND.Text;
                if (dao.baithuoc_DAO.update_baithuoc(mabt, strBT))
                {
                    Response.Redirect("baithuoc-caythuoc.aspx?id="+macay);
                }
                else
                {
                    lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
                }
            }
            else
            {
                String strBT = txtND.Text;
                if (dao.baithuoc_DAO.insert_baithuoc(macay, strBT))
                {
                    Response.Redirect("baithuoc-caythuoc.aspx?id=" + macay);
                }
                else
                {
                    lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
                }
            }
        }

        protected void lv_baithuoc_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lv_baithuoc.FindControl("datapager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadBaiThuoc(macay);// Sử dụng để load lại dữ liệu cho ListView sau khi chuyển trang khác
        }
    }
}