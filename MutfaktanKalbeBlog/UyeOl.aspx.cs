using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_uyeOl_Click(object sender, EventArgs e)
        {

            bool resimformat = false;
            Uye uye = new Uye();

            if (!string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(tb_soyad.Text) && !string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text) && !string.IsNullOrEmpty(tb_sifreTekrar.Text))
            {

                uye.Isim = tb_isim.Text;
                uye.Soyisim = tb_soyad.Text;
                uye.KullaniciAdi = tb_kullaniciAdi.Text;
                uye.Email = tb_mail.Text;
                uye.Sifre = tb_sifre.Text;
                uye.UyelikTarihi = DateTime.Now;
                uye.Durum = true;

                if (fu_resim.HasFile)//Resim Seçilmiş ise
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    string uzanti = fi.Extension;//.jpg,.png
                    if (uzanti == ".jpg" || uzanti == ".png" || uzanti == ".PNG" || uzanti == ".JPG")
                    {
                        string resimadi = Guid.NewGuid() + uzanti;
                        fu_resim.SaveAs(Server.MapPath("~/UyeResimleri/" + resimadi));
                        uye.Fotograf = resimadi;
                        resimformat = true;
                    }
                }
                else
                {
                    uye.Fotograf = "none.png";
                }

                if (tb_sifre.Text == tb_sifreTekrar.Text)
                {
                    if (resimformat)
                    {
                        if (dm.UyeOl(uye))
                        {
                            pnl_basarili.Visible = true;
                            pnl_basarisiz.Visible = false;
                            tb_isim.Text = "";
                            tb_soyad.Text = "";
                            tb_kullaniciAdi.Text = "";
                            tb_mail.Text = "";
                            tb_sifre.Text = "";
                            tb_sifreTekrar.Text = "";
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Üye olunurken bir hata oluştu";
                        }
                    }  
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Parolarınız eşleşmedi.Lütfen kontrol edip tekrar giriniz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır.Boş Alan Bırakılamaz!";
            }
        }
    }
}