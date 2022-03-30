using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["uye"] != null)
            {
                Uye u = (Uye)Session["uye"];
                pnlGirisVar.Visible = true;
                lbl_uye.Text = u.KullaniciAdi;
                pnl_girisyok.Visible = false;
            }
            else
            {
                pnlGirisVar.Visible = false;
                pnl_girisyok.Visible = true;
            }

        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void lb_tarifler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tarifler.aspx");
        }

        protected void lb_kacKalori_Click(object sender, EventArgs e)
        {
            Response.Redirect("KacKalori.aspx");
        }

        protected void lb_blog_Click(object sender, EventArgs e)
        {
            Response.Redirect("Blog.aspx");
        }

        protected void lb_anasayfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}