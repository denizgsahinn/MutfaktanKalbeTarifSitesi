using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_kategoriEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarifKategoriEkle.aspx");
        }
    }
}