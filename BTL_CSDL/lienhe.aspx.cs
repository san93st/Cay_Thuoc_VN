using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL
{
    public partial class lienhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            String strEmail = txtEmail.Text;
            String strTenHienThi = txtTenHienThi.Text;
            String strTieuDe = txtTieuDe.Text;
            String strND = txtNoiDung.Text;
            String strSDT = txtSDT.Text;
            if (admin.dao.LienHe_DAO.insertLienHe(strEmail, strTenHienThi, strTieuDe, strND, strSDT))
            {
                lbDisplay.Text = "Gửi Thành Công! Xin Chuyển Sang trang khác!";
            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Xin vui lòng liên hệ lại sau!";
            }
        }
    }
}