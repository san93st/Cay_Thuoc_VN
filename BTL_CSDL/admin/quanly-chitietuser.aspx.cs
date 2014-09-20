using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class quanly_chitietuser : System.Web.UI.Page
    {
        private static Boolean isUpdate = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    
                    loadThongTin();
                    txtMaQL.Enabled = false;
                    isUpdate = true;
                    if (Session["isAdmin"].ToString().Equals("False"))
                    {
                        cbIsAdmin.Enabled = false;
                        btnKhoiPhuc.Visible = false;
                        lbKhoiPhucMatKhau.Text = "Chức năng này chỉ dành cho Admin";
                    }
                }
            }
        }

        private void loadThongTin()
        {
            String maql = Request.QueryString["id"].ToString();
            DataTable dt = dao.QuanLy_DAO.getQuanLyByMaQL(maql);
            txtMaQL.Text = dt.Rows[0][0].ToString();
            txtTenQL.Text = dt.Rows[0][1].ToString();
            txtDiaChi.Text = dt.Rows[0][3].ToString();
            txtEmail.Text = dt.Rows[0][4].ToString();
            txtSDT.Text = dt.Rows[0][5].ToString();
            txtNgaySinh.Text = dt.Rows[0][6].ToString();
            if (dt.Rows[0][7].ToString().Equals("True"))
            {
                cbIsAdmin.Checked = true;
            }
            else
                cbIsAdmin.Checked = false;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String strMaQL = txtMaQL.Text;
            String strTenQL = txtTenQL.Text;
            String strDiaChi = txtDiaChi.Text;
            String strEmail = txtEmail.Text;
            String strSDT = txtSDT.Text;
            
            DateTime dateNgaySinh = DateTime.Parse(Request.Form[txtNgaySinh.UniqueID]);
            if (isUpdate)
            {
                if (Session["isAdmin"].ToString().Equals("True"))
                {
                    Boolean isAdmin = cbIsAdmin.Checked;
                    if (dao.QuanLy_DAO.updateQuanLyAdmin(strMaQL, strTenQL, strDiaChi, strEmail, strSDT, dateNgaySinh, isAdmin))
                    {
                        Response.Redirect("quanly-user.aspx");
                    }
                    else
                    {
                        lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên Hệ Admin để sửa chữa!";
                    }
                }
                else
                {
                    if (dao.QuanLy_DAO.updateQuanLy(strMaQL, strTenQL, strDiaChi, strEmail, strSDT, dateNgaySinh))
                    {
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên Hệ Admin để sửa chữa!";
                    }
                }
            }
            else
            {
                if (Session["isAdmin"].ToString().Equals("False"))
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Boolean isAdmin = cbIsAdmin.Checked;
                    if (dao.QuanLy_DAO.insertQuanLy(strMaQL, strTenQL, strDiaChi, strEmail, strSDT, dateNgaySinh, isAdmin))
                    {
                        Response.Redirect("quanly-user.aspx");
                    }
                    else
                    {
                        lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên Hệ Admin để sửa chữa!";
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("quanly-user.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                String id = Request.QueryString["id"].ToString();
                if (dao.QuanLy_DAO.khoiphucmatkhau(id))
                {
                    lbKhoiPhucMatKhau.Text = "Đã khôi phục mật khẩu về mặc định cho user này";
                }
                else
                {
                    lbKhoiPhucMatKhau.Text = "Chức năng này không dùng cho chức năng insert";
                }
            }
        }
    }
}