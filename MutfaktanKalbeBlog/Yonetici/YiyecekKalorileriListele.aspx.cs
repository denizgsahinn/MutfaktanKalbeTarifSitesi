using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class YiyecekKalorileriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_besinkalori.DataSource = dm.KalorileriListele();
            lv_besinkalori.DataBind();
        }

        protected void lv_besinkalori_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.BesinKaloriSil(id);
            }
            //if (e.CommandName == "durum")
            //{
            //    dm.BesinKaloriDurumDegistir(id);
            //}
            lv_besinkalori.DataSource = dm.KalorileriListele();
            lv_besinkalori.DataBind();
        }
    }
}