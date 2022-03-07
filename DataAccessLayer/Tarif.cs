using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Tarif
    {
        public int ID { get; set; }
        public int kategori_id { get; set; }
        public string kategoriAdi { get; set; }
        public string Isim { get; set; }
        public string Aciklama { get; set; }
        public short Servis_sayisi { get; set; }
        public short Pisirme_suresi { get; set; }
        public short Pisirme_derecesi { get; set; }
        public string Kalori_bilgisi { get; set; }
        public string Malzemeler { get; set; }
        public string Yapilis_Asamalari { get; set; }
        public string Fotograf { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime EklemeTarih { get; set; }
        public bool Durum { get; set; }
    }
}
