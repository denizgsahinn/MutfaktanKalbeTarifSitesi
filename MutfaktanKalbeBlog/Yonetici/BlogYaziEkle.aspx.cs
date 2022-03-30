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
    public partial class BlogYaziEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.BlogKategoriListele();
                ddl_kategoriler.DataBind();
            }
            
        }

        protected void lbtn_katListele_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogKategoriListele.aspx");
        }

        protected void lbtn_katEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_katIsim.Text))
            {
                BlogKategori bk = new BlogKategori();
                bk.Isim = tb_katIsim.Text;


                if (dm.BlogKategoriEkle(bk))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_katIsim.Text = "";
                    ddl_kategoriler.DataSource = dm.BlogKategoriListele();
                    ddl_kategoriler.DataBind();
                 

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz!";
            }
        }

        protected void lbtn_yaziEkle_Click(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(tb_ozet.Text) && !string.IsNullOrEmpty(tb_makIcerik.Text))
            //{

            bool resimformat = false;
            Makale mak = new Makale();
            mak.Baslik = tb_isim.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            mak.Durum = cb_yayinla.Checked;
            mak.Ozet = tb_ozet.Text;
            mak.Icerik = tb_makIcerik.Text;
            DataAccessLayer.Yonetici y = (DataAccessLayer.Yonetici)Session["yonetici"];
            mak.EklemeTarih = DateTime.Now;
            mak.Yazar_ID = y.ID;

            if (fu_resim.HasFile)//Resim Seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg,.png
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + resimadi));
                    mak.KapakResim = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                mak.KapakResim = "none.png";
            }

            if (resimformat)
            {
                if (dm.MakaleEkle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    mak.Baslik = "";
                    mak.Ozet = "";
                    mak.Icerik = "";

                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Makale eklenirken bir hata oluştu";
                }

            }

            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır";
            }

            //}
            //else
            //{
            //    pnl_basarisiz.Visible = true;
            //    pnl_basarili.Visible = false;
            //    lbl_mesaj.Text = "Makale alanları boş bırakılamaz!";
            //}
        }

    }
}