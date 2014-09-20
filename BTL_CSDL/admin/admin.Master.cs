using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (checkSession())
            {
                String strName = Session["Name"].ToString();
                String isAdmin = Session["isAdmin"].ToString();
                lbNameUser.Text = strName;
                if (isAdmin.Equals("False"))
                {
                    btnQuanlyTaiKhoanKhac.Visible = false;
                }
                else 
                {
                    btnQuanlyTaiKhoanKhac.Visible = true;
                }
            }
            else
            {
                Response.Redirect("LOGIN.aspx");
            }
        }
        private Boolean checkSession()
        {
            if (Session["Username"] != null && Session["password"] != null)
            {
                String strUserName = Session["Username"].ToString();
                String strPass = Session["password"].ToString();
                DataTable dt = dao.QuanLy_DAO.check_Login(strUserName, strPass);
                if (dt.Columns.Count > 1)
                    return true;
            }
            return false;
        }
        protected void btnSignOut_onClick(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Session["password"] = null;
            Session["isAdmin"] = null;
            Session["Name"] = null;
            Response.Redirect("LOGIN.aspx");
        }

        protected void btnChiTietUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("quanly-chitietuser.aspx?id=" + Session["Username"].ToString());
        }
    }
}