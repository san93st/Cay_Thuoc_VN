using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class HoCayThuoc_ChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMaHo.Enabled = false;
                if (Request.QueryString["id"] == null)
                {
                    lbTitle.Text = "Thêm mới cây thuốc";
                    btnSave.Text = "Thêm";
                }
                else
                {
                    String strId = Request.QueryString["id"].ToString();
                    lbTitle.Text = "Sửa cây thuốc";
                    btnSave.Text = "Sửa";
                    
                    loadHoCayThuoc(strId);
                }
            }
        }


        private void loadHoCayThuoc(string strId)
        {
            if (!utility.StringUtility.isNumber(strId))
            {
                Response.Redirect("quanly-hocaythuoc.aspx");
            }
            int Ma_Ho = int.Parse(strId);
            DataTable dt = dao.HoCayThuoc_DAO.getHoCayThuocByMaHo(Ma_Ho);
            txtMaHo.Text = dt.Rows[0][0].ToString();
            txtTenHienThi.Text = dt.Rows[0][1].ToString();
            txtTenKH.Text = dt.Rows[0][2].ToString();
            txtMaHo.Enabled = false;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("quanly-hocaythuoc.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String strMaHo = txtMaHo.Text;
            String strTenHienThi = txtTenHienThi.Text;
            String strTenKH = txtTenKH.Text;
            if (btnSave.Text.Equals("Thêm"))
            {
                String maQl = Session["Username"].ToString();
                if (dao.HoCayThuoc_DAO.insert(strTenHienThi, strTenKH, maQl))
                {
                    Response.Redirect("quanly-hocaythuoc.aspx");
                }
                else
                {
                    lbDisplay.Text = "Có lỗi xảy! Chưa thêm được thông tin! Xin liên hệ với admin để sửa chữa!";
                }
            }
            else
            {
                int maho = int.Parse(strMaHo);
                if (dao.HoCayThuoc_DAO.update(maho, strTenHienThi, strTenKH))
                {
                    Response.Redirect("quanly-hocaythuoc.aspx");
                }else
                {
                    lbDisplay.Text = "Có lỗi xảy! Chưa update được thông tin! Xin liên hệ với admin để sửa chữa!";
                }
            }
        }



    }
}