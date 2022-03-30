using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class BlogKategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_blogKategoriler.DataSource = dm.BlogKategoriListele();
            lv_blogKategoriler.DataBind();
        }

        protected void lb_geri_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogYaziEkle.aspx");
        }

        protected void lv_blogKategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.BlogKategoriSil(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori silinirken bir hata oluştu";
                }
            }
            lv_blogKategoriler.DataSource = dm.BlogKategoriListele();
            lv_blogKategoriler.DataBind();
        }
    }
}