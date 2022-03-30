using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class KacKalori : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_besinKategoriler.DataSource = dm.KaloriKategoriListele();
            rp_besinKategoriler.DataBind();

            pnl_kategoriIsim.Visible = true;
            lbl_kategori.Text = "Tüm Besinler Ve Kalorileri";
            
            if (Request.QueryString.Count == 0)
            {
                lv_besinKalorileri.DataSource = dm.KalorileriListele();
                lv_besinKalorileri.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["bkid"]);
                
                KaloriKategorileri kk = dm.BesinKategoriGetir(id);
                lbl_kategori.Text = kk.Isim;
                lv_besinKalorileri.DataSource = dm.KalorileriListele(id);
                lv_besinKalorileri.DataBind();
            }
        }


        protected void lv_besinKalorileri_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            lv_besinKalorileri.DataSource = dm.KalorileriListele();
            lv_besinKalorileri.DataBind();
        }
    }
}