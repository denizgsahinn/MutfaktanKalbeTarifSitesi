using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BesinKalori
    {
        public int ID { get; set; }
        public int kaloriKategoriID { get; set; }
        public string kaloriKategoriAdi { get; set; }
        public string Besin_adi { get; set; }
        public short Besin_degeri { get; set; }
        public string Miktar { get; set; }
        public string PorsiyonKarsiligi { get; set; }  // Porsiyon
        
    }
}
