using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL
{
    public partial class chitiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (admin.utility.StringUtility.isNumber(Request.QueryString["id"].ToString()))
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        loadCayThuoc(id);
                        loadAnhCayThuoc(id);
                        loadTenKhac(id);
                        loadBaiThuoc(id);
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        private void loadBaiThuoc(int id)
        {
            DataTable dt = admin.dao.baithuoc_DAO.getBaiThuoc_MaCay(id);
            lv_baithuoc.DataSource = dt;
            lv_baithuoc.DataBind();
        }

        private void loadTenKhac(int id)
        {
            DataTable dt = admin.dao.tenkhac_DAO.getTenKhac_Macay(id);
            if (dt.Rows.Count > 0)
            {
                String tenKhac = "";
                foreach (DataRow r in dt.Rows)
                {
                    tenKhac += r[2].ToString() + " -";
                }
                lbTenKhac.Text = tenKhac;
            }
            else
            {
                lbTenKhac.Text = "";
            }

        }

        private void loadAnhCayThuoc(int id)
        {
            DataTable dt = admin.dao.anh_caythuoc.getAnh_macay(id);
            imgAnhHienThi.ImageUrl = "admin/" + dt.Rows[0][3].ToString();
            imgAnhHienThi.AlternateText = dt.Rows[0][2].ToString();
            lv_anh.DataSource = dt;
            lv_anh.DataBind();
        }

        private void loadCayThuoc(int id)
        {
            DataTable dt = admin.dao.CayThuoc_DAO.getCayThuoc_MaCay(id);
            if (dt.Rows[0][4].ToString().Equals("False"))
            {
                Response.Redirect("index.aspx");
            }
            lbTenHienThi.Text = dt.Rows[0][1].ToString();
            lbTenKH.Text = dt.Rows[0][2].ToString();
            lbND.Text = dt.Rows[0][3].ToString();
            int maHo = int.Parse(dt.Rows[0][5].ToString());
            DataTable dt2 = admin.dao.HoCayThuoc_DAO.getHoCayThuocByMaHo(maHo);
            lbHoCayThuoc.Text = dt2.Rows[0][1].ToString() + " - " + dt2.Rows[0][2].ToString();
        }
    }
}