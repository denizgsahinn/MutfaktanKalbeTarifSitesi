using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class TarifGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)  // sayfa ilk kez çağırılıyor ise bunları yap
                {
                    ddl_kategoriler.DataSource = dm.TarifKategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["tid"]);
                    Tarif tarif = dm.TarifGetir(id);
                    tb_isim.Text = tarif.Isim;
                    ddl_kategoriler.SelectedValue = Convert.ToString(tarif.kategori_id);
                    img_resim.ImageUrl = "../TarifResimleri/" + tarif.Fotograf;
                    tb_servisSayi.Text = Convert.ToString(tarif.Servis_sayisi);
                    tb_pisirmeDerece.Text = Convert.ToString(tarif.Pisirme_derecesi);
                    tb_pisirmeSure.Text = Convert.ToString(tarif.Pisirme_suresi);
                    tb_kaloriBilgi.Text = Convert.ToString(tarif.Kalori_bilgisi);
                    tb_malzemeler.Text= tarif.Malzemeler;
                    tb_yapilisAsamalari.Text = tarif.Yapilis_Asamalari;
                    cb_yayinla.Checked = tarif.Durum;
                }
            }
            else
            {
                Response.Redirect("TarifleriListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunMu = true;
            int id = Convert.ToInt32(Request.QueryString["tid"]);
            Tarif tarif = dm.TarifGetir(id);
            tarif.Isim = tb_isim.Text;
            tarif.kategori_id = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            tarif.Servis_sayisi = Convert.ToInt16(tb_servisSayi.Text);
            tarif.Pisirme_derecesi = Convert.ToInt16(tb_pisirmeDerece.Text);
            tarif.Pisirme_suresi = Convert.ToInt16(tb_pisirmeSure.Text);
            tarif.Kalori_bilgisi = tb_kaloriBilgi.Text;
            tarif.Malzemeler = tb_malzemeler.Text;
            tarif.Yapilis_Asamalari = tb_yapilisAsamalari.Text;
            tarif.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/TarifResimleri/" + dosyaadi));
                    tarif.Fotograf = dosyaadi;
                }
                else
                {
                    uygunMu = false;
                }
            }
            if (uygunMu)
            {
                if (dm.TarifGuncelle(tarif))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı png,jpg veya jpeg olmalıdır";
            }
        }
    }
}