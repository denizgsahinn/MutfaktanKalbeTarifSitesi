using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class TarifDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["tid"]);
                Tarif trf = dm.TarifGetir(id);
                ltrl_title.Text = trf.Isim;
                img_recipe.ImageUrl = trf.Fotograf;
                ltrl_kategori.Text = trf.kategoriAdi;
                ltrl_servis.Text = Convert.ToString(trf.Servis_sayisi);
                ltrl_sure.Text = Convert.ToString(trf.Pisirme_suresi);
                ltrl_derece.Text = Convert.ToString(trf.Pisirme_derecesi);
                ltrl_kalori.Text = trf.Kalori_bilgisi;
                ltrl_ekleTarih.Text = Convert.ToString(trf.EklemeTarih);
                ltrl_goruntulenme.Text = Convert.ToString(trf.GoruntulenmeSayisi);
                img_recipe.ImageUrl = "~/TarifResimleri/" + trf.Fotograf;
                ltrl_malzemeler.Text = trf.Malzemeler;
                ltrl_yapilis.Text = trf.Yapilis_Asamalari;

            }
            else
            {
                Response.Redirect("TarifleriListele.aspx");
            }
        }

        protected void lb_geri_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(Request.QueryString["tid"]);
            Tarif trf = dm.TarifGetir(tid);
            int kid = trf.kategori_id;
            Response.Redirect("Tarifler.aspx?tid="+kid);
        }
    }
}