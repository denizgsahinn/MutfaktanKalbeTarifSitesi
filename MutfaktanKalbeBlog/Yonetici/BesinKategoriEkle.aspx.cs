using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class BesinKategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            KaloriKategorileri kk = new KaloriKategorileri();
            kk.Isim = tb_isim.Text;
            bool resimformat = false;

            if (fu_resim.HasFile)//Resim Seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg,.png
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/KaloriKategoriResimleri/" + resimadi));
                    kk.Fotograf = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                kk.Fotograf = "none.png";
            }
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (dm.KaloriKategoriEkle(kk))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kalori Kategorisi Eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır. Ve metin kutusu boş bırakılamaz!";
            }
        }

        protected void lbtn_listele_Click(object sender, EventArgs e)
        {
            Response.Redirect("KaloriKategorileriListele.aspx");
        }
    }
}