using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class Tarifler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_tarifler.DataSource = dm.TarifKategoriListele();
            rp_tarifler.DataBind();

            pnl_kategoriIsim.Visible = true;
            lbl_kategori.Text = "Tüm Tarifler";

            if (Request.QueryString.Count == 0)
            {
                lv_tarifler.DataSource = dm.TarifListele(true);
                lv_tarifler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["tid"]);

                Kategori k = dm.TarifKategoriGetir(id);
                lbl_kategori.Text = k.Isim;
                lv_tarifler.DataSource = dm.TarifListele(id,true);
                lv_tarifler.DataBind();
            }
        }

    }
}