using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class KaloriKategorileriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = dm.KaloriKategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.BesinKategoriSil(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori silinirken bir hata oluştu";
                }
            }
            lv_kategoriler.DataSource = dm.KaloriKategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lb_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("BesinKategoriEkle.aspx");
        }
    }
}