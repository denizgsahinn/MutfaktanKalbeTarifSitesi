using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MutfaktanKalbeBlog
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                DataAccessLayer.Yonetici yon = (DataAccessLayer.Yonetici)Session["yonetici"];  // Unboxing
                lbl_kullanici.Text = yon.Isim + " " + yon.SoyIsim;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void lbtn_cikisYap_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;  // burda sessionu sıfırlıyoruz
            Response.Redirect("Giris.aspx");
        }

        protected void lb_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDefault.aspx");
        }

        protected void lb_anasayfa_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;  // burda sessionu sıfırlıyoruz
            Response.Redirect("../Default.aspx");
        }
    }
}