using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class BlogKategoriGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["bkid"]);
                    BlogKategori bk = dm.BlogKategoriGetir(id);

                    tb_ID.Text = bk.ID.ToString();
                    tb_isim.Text = bk.Isim;
                }
                else
                {
                    Response.Redirect("BlogKategoriListele.aspx");
                }
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["bkid"]);
            BlogKategori bk = dm.BlogKategoriGetir(id);
            bk.Isim = tb_isim.Text;

            if (dm.BlogKategoriGuncelle(bk))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Güncelleme işlemi sırasında bir hata meydana geldi";
            }
        }
    }
}