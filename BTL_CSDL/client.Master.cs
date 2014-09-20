using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_CSDL
{
    public partial class client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String strSearch = txtSearch.Text;
            if (strSearch.Length > 0)
            {
                if(checkboxHoCayThuoc.Checked)
                    Response.Redirect("search.aspx?type=hocaythuoc&search=" + strSearch);
                else if(checkboxBaiThuoc.Checked)
                    Response.Redirect("search.aspx?type=baithuoc&search=" + strSearch);
                else
                    Response.Redirect("search.aspx?type=caythuoc&search=" + strSearch);
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

    }
}