using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class Blog : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_makaleler.DataSource = dm.BlogKategoriListele();
            rp_makaleler.DataBind();

            pnl_kategoriIsim.Visible = true;
            lbl_kategori.Text = "Tüm Blog Yazıları";

            if (Request.QueryString.Count == 0)
            {
                lv_makaleler.DataSource = dm.MakaleListele();
                lv_makaleler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);

                BlogKategori bk = dm.BlogKategoriGetir(id);
                lbl_kategori.Text = bk.Isim;
                lv_makaleler.DataSource = dm.MakaleListele(id);
                lv_makaleler.DataBind();
            }
        }
    }
}