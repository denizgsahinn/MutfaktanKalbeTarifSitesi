using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class DataModel
    {

        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();

        }

        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {

                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE EMail= @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,EMail,Sifre,Durum FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;  // initial value
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.SoyIsim = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumOnayla(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Yorumlar SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Üye Metotları

        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());  // tablo değil de tek bir değer dönücekse -->  ExecuteScalar

                if (sayi == 1)  // güvenlik önlemi amaçlı.Sorgudan sadece 1 veya 0 dönücek yani bu kişi vardır veya yoktur diye, ama bilgileri kontrolden sonraki kısımda gelicek 
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Email = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeOl(Uye uye)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Durum) VALUES(@isim,@soyisim,@kullaniciAdi,@email,@sifre,@uyelikTarihi,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", uye.Isim);
                cmd.Parameters.AddWithValue("@soyisim", uye.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciAdi", uye.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email", uye.Email);
                cmd.Parameters.AddWithValue("@sifre", uye.Sifre);
                cmd.Parameters.AddWithValue("@uyelikTarihi", uye.UyelikTarihi);
                cmd.Parameters.AddWithValue("@durum", uye.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uye> UyeleriListele()
        {
            try
            {
                List<Uye> uyeler = new List<Uye>();

                cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Fotograf, Durum FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uye uye = new Uye();
                    uye.ID = reader.GetInt32(0);
                    uye.Isim = reader.GetString(1);
                    uye.Soyisim = reader.GetString(2);
                    uye.KullaniciAdi = reader.GetString(3);
                    uye.Sifre = reader.GetString(4);
                    uye.UyelikTarihi = reader.GetDateTime(5);
                    uye.Fotograf = reader.GetString(6);
                    uye.Durum = reader.GetBoolean(7);
                    uyeler.Add(uye);
                }
                return uyeler;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Uye UyeGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Fotograf, Durum FROM Uyeler WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                Uye uye = new Uye();

                while (reader.Read())
                {
                    uye.ID = reader.GetInt32(0);
                    uye.Isim = reader.GetString(1);
                    uye.Soyisim = reader.GetString(2);
                    uye.KullaniciAdi = reader.GetString(3);
                    uye.Email = reader.GetString(4);
                    uye.Sifre = reader.GetString(5);
                    uye.UyelikTarihi = reader.GetDateTime(6);
                    uye.Fotograf = reader.GetString(7);
                    uye.Durum = reader.GetBoolean(8);
                }
                return uye;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyelikGuncelle(Uye uye)
        {
            try
            {
                cmd.CommandText = "UPDATE Uyeler SET Isim=@isim, Soyisim=@soyisim, KullaniciAdi=@kullaniciadi, Email=@email, Sifre=@sifre, Fotograf=@fotograf, Durum=@durum  WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim",uye.Isim);
                cmd.Parameters.AddWithValue("@soyisim",uye.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciadi",uye.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email",uye.Email);
                cmd.Parameters.AddWithValue("@sifre",uye.Sifre);
                cmd.Parameters.AddWithValue("@fotograf",uye.Fotograf);
                cmd.Parameters.AddWithValue("@durum",uye.Durum); // üyelik sonlandırmak için olabilir belki
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Kategori Metotları

        public bool KategoriEkle(Kategori k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@isim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim",k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();

                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler ";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategori k = new Kategori();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        } // tek bir tane kategori

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID= @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Kaç Kalori için Besin Değeri Metotları

        public bool BesinKaloriEkle(BesinKalori bk)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Besin_Kalori(Besin_adi, Besin_degeri) VALUES (@besin_adi, @besin_degeri)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@besin_adi", bk.Besin_adi);
                cmd.Parameters.AddWithValue("@besin_degeri", bk.Besin_degeri);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<BesinKalori> KalorileriListele()
        {
            try
            {
                List<BesinKalori> besinkalorileri = new List<BesinKalori>();

                cmd.CommandText = "SELECT ID, Besin_adi, Besin_degeri FROM Besin_Kalori ";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BesinKalori bk = new BesinKalori();
                    bk.ID = reader.GetInt32(0);
                    bk.Besin_adi = reader.GetString(1);
                    bk.Besin_degeri = reader.GetInt16(2);
                    besinkalorileri.Add(bk);
                }
                return besinkalorileri;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public BesinKalori BesinKalorisiGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Besin_adi, Besin_degeri FROM Besin_Kalori WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                BesinKalori bk = new BesinKalori();

                while (reader.Read())
                {
                    bk.ID = reader.GetInt32(0);
                    bk.Besin_adi = reader.GetString(1);
                    bk.Besin_degeri = reader.GetInt16(2);
                }
                return bk;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool BesinKaloriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Besin_Kalori WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool BesinKaloriGuncelle(BesinKalori bk)
        {
            try
            {
                cmd.CommandText = "UPDATE Besin_Kalori SET Besin_adi=@besin_adi, Besin_degeri=@besin_degeri  WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@besin_adi", bk.Besin_adi);
                cmd.Parameters.AddWithValue("@besin_degeri", bk.Besin_degeri);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Makale Metoları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResim, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResim, @goruntulenmeSayisi, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", mak.GoruntulenmeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makaleler.Add(m);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele(int katid)
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID WHERE M.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makaleler.Add(m);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID WHERE M.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale m = new Makale();
                while (reader.Read())
                {

                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulenmeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                }
                return m;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleGuncelle(Makale mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET KategoriID=@kategoriID, Baslik=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Makaleler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Yorum Metotları

        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(int Mid)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID WHERE Y.MakaleID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Mid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(bool onay)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID WHERE Y.OnayDurum = @d";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", onay);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }   // Onaylanan yorumları listeler

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(UyeID, MakaleID, Icerik, YorumTarihi, OnayDurum) VALUES(@uyeID, @makaleID,@icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@makaleID", y.MakaleID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.Tarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion


        #region Tarif Metotları

        public bool TarifEkle(Tarif t)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Tarifler(kategori_id, Isim, Aciklama, Servis_sayisi, Pisirme_suresi, Pisirme_derecesi, Kalori_bilgisi, Malzemeler, Yapilis_Asamalari, Fotograf, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriId, @isim, @aciklama, @servis_sayisi, @pisirme_suresi, @pisirme_derecesi, @kalori_bilgisi, @malzemeler, @yapilis_Asamalari, @fotograf, @goruntulenmeSayisi, @eklemetarihi, @durum )";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriId", t.kategori_id);
                cmd.Parameters.AddWithValue("@isim", t.Isim);
                cmd.Parameters.AddWithValue("@aciklama", t.Aciklama);
                cmd.Parameters.AddWithValue("@servis_sayisi", t.Servis_sayisi);
                cmd.Parameters.AddWithValue("@pisirme_suresi", t.Pisirme_suresi);
                cmd.Parameters.AddWithValue("@pisirme_derecesi", t.Pisirme_derecesi);
                cmd.Parameters.AddWithValue("@kalori_bilgisi", t.Kalori_bilgisi);
                cmd.Parameters.AddWithValue("@malzemeler", t.Malzemeler);
                cmd.Parameters.AddWithValue("@yapilis_Asamalari", t.Yapilis_Asamalari);
                cmd.Parameters.AddWithValue("@fotograf", t.Fotograf);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", t.GoruntulenmeSayisi);
                cmd.Parameters.AddWithValue("@eklemetarihi", t.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", t.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Tarif> TarifListele(int kategoriID)
        {
            try
            {
                List<Tarif> tarifler = new List<Tarif>();

                cmd.CommandText = "SELECT T.ID, T.kategori_id, K.Isim, T.Isim, T.Aciklama, T.Servis_sayisi, T.Pisirme_suresi, T.Pisirme_derecesi, T.Kalori_bilgisi, T.Malzemeler, T.Yapilis_Asamalari, T.Fotograf, T.GoruntulenmeSayisi, T.EklemeTarihi, T.Durum FROM Tarifler AS T JOIN Kategoriler AS K ON K.ID = T.kategori_id = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kategoriID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tarif t = new Tarif();
                    t.ID = reader.GetInt32(0);
                    t.kategori_id = reader.GetInt32(1);
                    t.kategoriAdi = reader.GetString(2);
                    t.Aciklama = reader.GetString(3);
                    t.Servis_sayisi = reader.GetInt16(4);
                    t.Pisirme_suresi = reader.GetInt16(5);
                    t.Pisirme_derecesi = reader.GetInt16(6);
                    t.Kalori_bilgisi = reader.GetString(7);
                    t.Malzemeler = reader.GetString(8);
                    t.Yapilis_Asamalari = reader.GetString(9);
                    t.Fotograf = reader.GetString(10);
                    t.GoruntulenmeSayisi = reader.GetInt32(11);
                    t.EklemeTarih = reader.GetDateTime(12);
                    t.Durum = reader.GetBoolean(13);
                    tarifler.Add(t);
                }
                return tarifler;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool TarifGuncelle(Tarif tarif)
        {
            try
            {
                cmd.CommandText = "UPDATE Tarifler SET kategori_id=@kategoriId, Isim=@isim, Aciklama=@aciklama, Servis_sayisi=@servis_sayisi, Pisirme_suresi=@pisirme_suresi, Pisirme_derecesi=@pisirme_derecesi, Kalori_bilgisi=@kalori_bilgisi, Malzemeler=@malzemeler, Yapilis_Asamalari=@yapilis_Asamalari, Fotograf=@fotograf, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriId", tarif.kategori_id);
                cmd.Parameters.AddWithValue("@isim", tarif.Isim);
                cmd.Parameters.AddWithValue("@aciklama", tarif.Aciklama);
                cmd.Parameters.AddWithValue("@servis_sayisi", tarif.Servis_sayisi);
                cmd.Parameters.AddWithValue("@pisirme_suresi", tarif.Pisirme_suresi);
                cmd.Parameters.AddWithValue("@pisirme_derecesi", tarif.Pisirme_derecesi);
                cmd.Parameters.AddWithValue("@kalori_bilgisi", tarif.Kalori_bilgisi);
                cmd.Parameters.AddWithValue("@malzemeler", tarif.Malzemeler);
                cmd.Parameters.AddWithValue("@yapilis_Asamalari", tarif.Yapilis_Asamalari);
                cmd.Parameters.AddWithValue("@fotograf", tarif.Fotograf);
                cmd.Parameters.AddWithValue("@durum", tarif.Durum);
                cmd.Parameters.AddWithValue("@id", tarif.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool TarifSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Tarifler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        } 

        #endregion


        public bool OzelGunEkle(OzelGunListeleri ogl)
        {
            try
            {
                cmd.CommandText = "INSERT INTO OzelGunListeleri(Isim,Fotograf) VALUES(@isim,@fotograf)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", ogl.Isim);
                cmd.Parameters.AddWithValue("@fotograf", ogl.Fotograf);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        //public bool OzelGuneTarifEkle(Tarif t)
        //{

        //}
    }
}
