using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace MutfaktanKalbeBlog.Yonetici
{
    public partial class OnayBekleyenYorumlar : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.YorumSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.YorumOnayla(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();
        }
    }
}