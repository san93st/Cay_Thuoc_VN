using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_chitietcaythuoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMaCayThuocs.Enabled = false;
                loadMaHo();
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    loadThongTinCayThuoc(id);
                }
            }
        }

        private void loadMaHo()
        {
            DataTable dt = dao.HoCayThuoc_DAO.getAll_Hocaythuoc();
            dlMaHo.DataSource = dt;
            dlMaHo.DataValueField = "MA_HO";
            dlMaHo.DataTextField = "TEN_HIEN_THI";
            dlMaHo.DataBind();
        }

        private void loadThongTinCayThuoc(int macay)
        {
            
            DataTable dt = dao.CayThuoc_DAO.getCayThuoc_MaCay(macay);
            txtMaCayThuocs.Text = dt.Rows[0][0].ToString();
            txtTenHienThi.Text = dt.Rows[0][1].ToString();
            txtTenKH.Text = dt.Rows[0][2].ToString();
            txtNoiDung.Text = dt.Rows[0][3].ToString();
            if (dt.Rows[0][4].ToString().Equals("True"))
            {
                cbDisplay.Checked = true;
            }
            String maho = dt.Rows[0][5].ToString();
            dlMaHo.SelectedValue = maho;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("quanly-caythuoc.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String strTenHienThi = txtTenHienThi.Text;
            String strTenKH = txtTenKH.Text;
            String strND = txtNoiDung.Text;
            Boolean TrangThai = cbDisplay.Checked;
            int maHo = int.Parse(dlMaHo.SelectedValue);
            String MaQl = Session["Username"].ToString();
            if (txtMaCayThuocs.Text!=null && txtMaCayThuocs.Text.Length>0)
            {
                int macay = int.Parse(txtMaCayThuocs.Text);
                if (dao.CayThuoc_DAO.updateCayThuoc(macay, strTenHienThi, strTenKH, strND, TrangThai, maHo, MaQl))
                {
                    Response.Redirect("quanly-caythuoc.aspx");
                }
                else
                {
                    lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
                }
            }
            else
            {
                if (dao.CayThuoc_DAO.insertCayThuoc(strTenHienThi, strTenKH, strND, TrangThai, maHo, MaQl))
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
}