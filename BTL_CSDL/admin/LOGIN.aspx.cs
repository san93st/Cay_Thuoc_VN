using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BTL_CSDL.admin
{
    public partial class LOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkCookie();
            if (!IsPostBack)
            {
                if (checkSession())
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
        /// <summary>
        /// Sự kiện khi click vào nút đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Vì là phần login nên không sử dụng validate
            String strUserName = txtUserName.Text;
            String strPass = txtPass.Text;
            DataTable dt = dao.QuanLy_DAO.check_Login(strUserName, strPass);//Kiểm tra UserName và mật khẩu có trùng trong cơ sở dữ liệu không?
            if (dt.Columns.Count > 1)
            {
                if (cbRememberMe.Checked)// Xử lý khi nút checkBox Remember Me được tích
                {
                    if (Request.Cookies["UserSetting"] == null)//Nếu không có cookie tồn tại trong client thì lưu mới
                    {
                        HttpCookie myCookie = new HttpCookie("UserSetting");
                        myCookie["UserName"] = strUserName;
                        myCookie["Password"] = strPass;
                        myCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(myCookie);
                    }
                }
                //Tạo session cho phiên làm việc của người dùng
                Session["Username"] = dt.Rows[0][0].ToString();
                Session["password"] = dt.Rows[0][3].ToString();
                Session["isAdmin"] = dt.Rows[0][2].ToString();
                Session["Name"] = dt.Rows[0][1].ToString();
                Response.Redirect("index.aspx");
            }
            else
            {
                lbHienThi.ForeColor = System.Drawing.Color.Red;
                lbHienThi.Text = "Khong thanh cong! Xin thử lại tên tài khoản hoặc mật khẩu.";
                txtUserName.Focus();
            }
        }
        /// <summary>
        /// Kiểm tra Session, nếu tồn tại thì kiểm tra xem dữ liệu session đó chính xác chưa? (Sử dụng hàm
        /// trong class dao.QuanLy_DAO.cs với phương thức check_Login(String,String)
        /// </summary>
        /// <returns>Boolean</returns>
        private Boolean checkSession() {
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
        /// <summary>
        /// Hàm dùng để kiểm tra cookie xem máy client đã có cookie chưa. Nếu có thì sẽ load lên các TextBox bao gồm tên 
        /// UserName và mật khẩu
        /// </summary>
        private void checkCookie()
        {
            if (Request.Cookies["UserSetting"] != null)
            {
                txtUserName.Text = Request.Cookies["UserSetting"]["UserName"].ToString();
                txtPass.Text = Request.Cookies["UserSetting"]["Password"].ToString();
            }
        }

    }
}