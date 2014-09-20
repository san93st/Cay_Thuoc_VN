using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;

namespace BTL_CSDL.admin
{
    public partial class anh_caythuoc : System.Web.UI.Page
    {
        private int macay;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                macay = int.Parse(Request.QueryString["id"].ToString());
            }
            else
            {
                Response.Redirect("quanly-caythuoc.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Label2.Text = dao.CayThuoc_DAO.getTenHienThi_MaCay(macay);
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    loadAnh(id);

                }
                else
                {
                    Response.Redirect("quanly-caythuoc.aspx");
                }
            }
        }

        private void loadAnh(int id)
        {
            DataTable dt = dao.anh_caythuoc.getAnh_macay(id);
            lv_anhcaythuoc.DataSource = dt;
            lv_anhcaythuoc.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String strMaBT = btn.CommandArgument;
            int id = int.Parse(strMaBT);
            if (dao.anh_caythuoc.delete_anh(id))
            {
                Response.Redirect("anh-caythuoc.aspx?id=" + macay);

            }
            else
            {
                lbDisplay.Text = "Có lỗi xảy ra! Vui lòng liên hệ Admin để sửa chữa!";
            }
        }

        protected void AjaxFileUpload1_UploadComplete1(object sender, AjaxFileUploadEventArgs e)
        {
            string TenAnh = e.FileName;
            String[] tmp = TenAnh.Split('.');
            TenAnh = tmp[0];
            string strDestPath = Server.MapPath("~/admin/images/");
            String TenImage = macay.ToString() + "_" + DateTime.Now.ToFileTimeUtc().ToString();
            String url = "images/"+TenImage+"."+tmp[1];
            if (dao.anh_caythuoc.insert_anh(macay, TenAnh, url))
            {
                AjaxFileUpload1.SaveAs(@strDestPath + TenImage + "." + tmp[1]);
            }
            else
            {
                lbDisplay.Text = "Looix";
            }
            
        }
    }
}