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
    public partial class TarifEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.TarifKategoriListele();
                ddl_kategoriler.DataBind();
            } 
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;

            Tarif tarif = new Tarif();

            tarif.Isim = tb_isim.Text;
            tarif.kategori_id = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            tarif.Servis_sayisi = Convert.ToInt16(tb_servisSayi.Text);
            tarif.Pisirme_derecesi = Convert.ToInt16(tb_pisirmeDerece.Text);
            tarif.Pisirme_suresi = Convert.ToInt16(tb_pisirmeSure.Text);
            tarif.Kalori_bilgisi = tb_kaloriBilgi.Text;
            tarif.Malzemeler = tb_malzemeler.Text;
            tarif.Yapilis_Asamalari = tb_yapilisAsamalari.Text;
            tarif.EklemeTarih = DateTime.Now;
            tarif.Durum = cb_yayinla.Checked;

            if (fu_resim.HasFile)//Resim Seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg,.png
                if (uzanti == ".jpg" || uzanti == ".png" || uzanti=="JPG" || uzanti=="PNG")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/TarifResimleri/" + resimadi));
                    tarif.Fotograf = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                tarif.Fotograf = "none.png";
            }


            if (resimformat)
            {
                if (dm.TarifEkle(tarif))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_isim.Text = "";
                    tb_servisSayi.Text = "";
                    tb_pisirmeDerece.Text = "";
                    tb_pisirmeSure.Text = "";
                    tb_kaloriBilgi.Text = "";
                    tb_malzemeler.Text = "";
                    tb_yapilisAsamalari.Text = "";
                    

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Tarif Eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır.";
            }


           
        }
    }
}