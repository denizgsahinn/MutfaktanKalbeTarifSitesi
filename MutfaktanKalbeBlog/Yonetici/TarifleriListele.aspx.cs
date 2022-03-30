using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class TarifleriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.TarifKategoriListele();
            rp_kategoriler.DataBind();


            pnl_kategoriIsim.Visible = true;
            lbl_kategori.Text = "Tüm Tarifler";

            if (Request.QueryString.Count == 0)
            {
                lv_tarifler.DataSource = dm.TarifListele();
                lv_tarifler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);

                Kategori k = dm.TarifKategoriGetir(id);
                lbl_kategori.Text = k.Isim;
                lv_tarifler.DataSource = dm.TarifListele(id);
                lv_tarifler.DataBind();
            }
        }


        protected void lv_tarifler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.TarifSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.TarifDurumDeğiştir(id);
            }
            lv_tarifler.DataSource = dm.TarifListele();
            lv_tarifler.DataBind();
        }
    }
}