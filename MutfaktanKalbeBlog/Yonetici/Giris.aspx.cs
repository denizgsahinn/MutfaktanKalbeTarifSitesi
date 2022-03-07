using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MutfaktanKalbeBlog
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel db = new DataModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_mail.Text) && !String.IsNullOrEmpty(tb_sifre.Text))
            {
                string mail = tb_mail.Text;
                string sifre = tb_sifre.Text;

                DataAccessLayer.Yonetici y = db.YoneticiGiris(mail, sifre);
                if (y != null)
                {
                    Session["yonetici"] = y;//boxing işlemi yapar
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    hata_pnl.Visible = true;
                }

            }
            else
            {
                lbl_mesaj.Text = "Mail ve Şifre Boş Bırakılamaz!";
                hata_pnl.Visible = true;
            }
        }
    }
}