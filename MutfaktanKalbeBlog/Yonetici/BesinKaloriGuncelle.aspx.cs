using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    
    public partial class BesinKaloriGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    ddl_kategoriler.DataSource = dm.KaloriKategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["bkid"]);
                    BesinKalori bk = dm.BesinKalorisiGetir(id);

                    tb_ID.Text = bk.ID.ToString();
                    tb_isim.Text = bk.Besin_adi;
                    ddl_kategoriler.SelectedValue = Convert.ToString(bk.kaloriKategoriID);
                    tb_miktar.Text =bk.Miktar;
                    tb_porsiyon.Text=bk.PorsiyonKarsiligi;
                    tb_kalori.Text =Convert.ToString(bk.Besin_degeri);
                }
                else
                {
                    Response.Redirect("KaloriKategorileriListele.aspx");
                }
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["bkid"]);
            BesinKalori bk = dm.BesinKalorisiGetir(id);
            bk.Besin_adi = tb_isim.Text;
            bk.kaloriKategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            bk.Miktar = tb_miktar.Text;
            bk.PorsiyonKarsiligi = tb_porsiyon.Text;
            bk.Besin_degeri = Convert.ToInt16(tb_kalori.Text);



            if (dm.BesinKaloriGuncelle(bk))
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