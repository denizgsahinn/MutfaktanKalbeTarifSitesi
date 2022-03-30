using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class BesinKaloriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                ddl_kategoriler.DataSource = dm.KaloriKategoriListele();
                ddl_kategoriler.DataBind();
            }
           
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            
                BesinKalori bk = new BesinKalori();
                bk.Besin_adi = tb_isim.Text;
                bk.kaloriKategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
                bk.Miktar = tb_miktar.Text;
                bk.PorsiyonKarsiligi = tb_porsiyon.Text;
                bk.Besin_degeri = Convert.ToInt16(tb_kalori.Text);

                if (dm.BesinKaloriEkle(bk))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_miktar.Text = "";
                    tb_isim.Text = "";
                    tb_porsiyon.Text = "";
                    tb_kalori.Text = "";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Besini Kalori bilgileri eklenirken bir hata oluştu";
                }
            //if (!string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(ddl_kategoriler.SelectedValue) && !string.IsNullOrEmpty(tb_miktar.Text) && !string.IsNullOrEmpty(tb_porsiyon.Text) && !string.IsNullOrEmpty(tb_kalori.Text)){}
            //else
            //{
            //    pnl_basarili.Visible = false;
            //    pnl_basarisiz.Visible = true;
            //    lbl_mesaj.Text = "Alanlar boş bırakılamaz";
            //}
        }
    }
}