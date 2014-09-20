using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_chitietlienhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["email"] == null)
                {
                    Response.Redirect("quanly-lienhe.aspx");
                }
                else
                {
                    String strEmail = Request.QueryString["email"].ToString();
                    loadChiTietLienHeChuaXuLy(strEmail);

                }
            }
        }

        private void loadChiTietLienHeChuaXuLy(string strEmail)
        {

            DataTable dt = dao.LienHe_DAO.getLienHeWithEmail(strEmail);
            txtEmail.Text = dt.Rows[0][0].ToString();
            txtTenHienThi.Text = dt.Rows[0][1].ToString();
            txtTieuDe.Text = dt.Rows[0][2].ToString();
            txtNoiDung.Text = dt.Rows[0][3].ToString();
            if (dt.Rows[0][4].ToString().Equals("False"))
            {
                cbTrangThai.Checked = false;
            }
            else
            {
                cbTrangThai.Checked = true;

                cbTrangThai.Enabled = false;
            }
            txtSoDienThoai.Text = dt.Rows[0][5].ToString();
            txtNgayGui.Text = dt.Rows[0][6].ToString();
            if (dt.Rows[0][7] != null)
            {
                txtNgayLienHe.Text = dt.Rows[0][7].ToString();
            }
            if (dt.Rows[0][8] != null)
            {
                txtMaQL.Text = dt.Rows[0][8].ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("quanly-lienhe.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String strEmail = txtEmail.Text;
            String strMaQl = Session["Username"].ToString();
            Boolean isAdmin = cbTrangThai.Checked;
            if (dao.LienHe_DAO.updateLienHe(strEmail, isAdmin, strMaQl))
            {
                Response.Redirect("quanly-lienhe.aspx");
            }
            else
            {
                Response.Redirect("quanly-lienhe.aspx");
            }
        }
    }
}