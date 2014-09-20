using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XnaFan.ImageComparison;

namespace BTL_CSDL
{
    public partial class search_anh : System.Web.UI.Page
    {
        private static String anh = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string TenAnh = e.FileName;
            String[] strTmp = TenAnh.Split('.');
            TenAnh = DateTime.Now.ToFileTimeUtc().ToString();
            TenAnh += "."+strTmp[1];
            string strDestPath = Server.MapPath("~/imagesTmp/");
            AjaxFileUpload1.SaveAs(@strDestPath + TenAnh);
            anh = "imagesTmp/" + TenAnh;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (anh.Length < 0 || anh.Equals(""))
            {
                lbDisplay.Text = "Xin hãy upload ảnh rồi mới tìm kiếm!";
                return;
            }
            Image1.ImageUrl = anh;
            String strPathImg = Server.MapPath("~/" + anh);
            DataTable dt = admin.dao.anh_caythuoc.getAllAnh();
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("Ma_Anh");
            dtNew.Columns.Add("Ma_Cay");
            dtNew.Columns.Add("Ten_Anh");
            dtNew.Columns.Add("URL");
            dtNew.Columns.Add("Percent");
            foreach (DataRow r in dt.Rows)
            {
                String p = Server.MapPath("~/admin/" + r[3].ToString());
                float difference = ImageTool.GetPercentageDifference(strPathImg, p);
                if ((difference*100) < 50)
                {
                    dtNew.Rows.Add(r[0],r[1],r[2],r[3],(difference*100).ToString());
                }
            }
            GridView1.DataSource = dtNew;
            GridView1.DataBind();
        }
    }
}