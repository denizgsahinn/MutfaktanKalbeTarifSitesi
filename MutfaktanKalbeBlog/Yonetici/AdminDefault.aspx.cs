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



        protected void lb_tarifKatEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarifKategoriEkle.aspx");
        }

        protected void lb_tarifListele_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarifleriListele.aspx");
        }

        protected void lb_tarifEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarifEkle.aspx");
        }

        protected void lb_yiyecekEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("BesinKaloriEkle.aspx");
        }

        protected void lb_kaloriListele_Click(object sender, EventArgs e)
        {
            Response.Redirect("YiyecekKalorileriListele.aspx");
        }

        protected void lb_besinkategoriEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("BesinKategoriEkle.aspx");
        }


        protected void lb_makEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogYaziEkle.aspx");
        }

        protected void lb_makListele_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogYaziListele.aspx");
        }












        //protected void lb_makEkle_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("BlogYaziEkle.aspx");
        //}

        //protected void lb_makKatEkle_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("BlogYaziKategoriListele.aspx");
        //}
    }
}