using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL.admin
{
    public partial class reset_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String maQl = Session["Username"].ToString();
            String strOldPass = txtOldPass.Text;
            DataTable dt = dao.QuanLy_DAO.check_Login(maQl, strOldPass);
            if (dt.Columns.Count > 1)
            {
                String strNewPass = txtNewPass1.Text;
                if (dao.QuanLy_DAO.doimatkhau(maQl, strNewPass))
                {
                    lbDisplay.Text = "Đổi mật khẩu thành công!";
                }
                else
                {
                    lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa";
                }
            }
            else
            {
                lbDisplay.Text = "Mật khẩu cũ không chính xác";
                txtOldPass.Focus();
            }

        }
    }
}