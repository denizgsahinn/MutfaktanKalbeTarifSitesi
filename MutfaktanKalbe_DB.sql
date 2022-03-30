CREATE DATABASE TarifBlogum
GO
USE TarifBlogum 
GO
CREATE TABLE YoneticiTurler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	Email nvarchar(120),
	Sifre nvarchar(20),
	Durum bit,
	CONSTRAINT pk_yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(50),
	Email nvarchar(120),
	Sifre nvarchar(20),
	UyelikTarihi datetime,
	Fotograf nvarchar(75),
	Durum bit,
	CONSTRAINT pk_uye PRIMARY KEY(ID)
)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE MakaleKategori
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_makKategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1000,1),
	KategoriID int,
	YazarID int, -- hangi yonetici yazdý
	Baslik nvarchar(50),
	Ozet nvarchar(500),
	Icerik nvarchar(MAX),
	KapakResim nvarchar(75),
	GoruntulenmeSayisi int,
	EklemeTarihi datetime,
	Durum bit,
	CONSTRAINT pk_makale PRIMARY KEY(ID),
	CONSTRAINT fk_makaleKategori FOREIGN KEY(KategoriID) REFERENCES MakaleKategori(ID),
	CONSTRAINT fk_makaleYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	UyeID int,
	MakaleID int,
	Icerik nvarchar(500),
	YorumTarihi datetime,
	OnayDurum bit,
	CONSTRAINT pk_yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(MakaleID) REFERENCES Makaleler(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)
)
GO
CREATE TABLE KaloriKategorileri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(100),
	Fotograf nvarchar(75),
	CONSTRAINT pk_kaloriKategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Besin_Kalori
(
	ID int IDENTITY(1,1),
	Besin_adi nvarchar(200),
	Besin_degeri smallint,
	Miktar nvarchar(25),
	PorsiyonKarsiligi nvarchar(100),
	kaloriKategoriID int,
	CONSTRAINT pk_besinKalori PRIMARY KEY(ID),
	CONSTRAINT fk_besinKategori FOREIGN KEY(kaloriKategoriID) REFERENCES KaloriKategorileri(ID)
)
GO
CREATE TABLE Tarifler
(
	ID int IDENTITY(1,1),
	kategori_id int,
	Isim nvarchar(150) NOT NULL,
	Aciklama nvarchar(500),
	Servis_sayisi smallint,
	Pisirme_suresi smallint,
	Pisirme_derecesi smallint,
	Kalori_bilgisi nvarchar(500),  -- 1 adet yulaflý diyet kurabiye yaklaþýk olarak 25 kaloriye denk gelmektedir. Gibi aciklama yapmak icin. 1 porsiyon 200 kaloridir gibi 
	Malzemeler nvarchar(MAX), -- nvarchar(4000),
	Yapilis_Asamalari text,  -- ? buranýn türü ne olmalý?(varchar mesela 8000 'e kadar tutuyor)
	Fotograf nvarchar(75),  -- Fotoðaf yolu ekleme 
	GoruntulenmeSayisi int,
	EklemeTarihi datetime,
	Durum bit,
	CONSTRAINT pk_tarif PRIMARY KEY(ID),
	CONSTRAINT fk_tarif_kategori FOREIGN KEY(kategori_id) REFERENCES Kategoriler(ID)
)
GO
CREATE TABLE TarifDefteri
(
	UyeID int,
	TarifID int,
	CONSTRAINT pk_tarifdefteri PRIMARY KEY(UyeID,TarifID),  
	CONSTRAINT fk_tarifdefteri_uye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID), 
	CONSTRAINT fk_tarifdefteri_tarif FOREIGN KEY(TarifID) REFERENCES Tarifler(ID)
)
GO
CREATE TABLE OzelGunListeleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(175), -- Yýlbaþý için Tarifler, Doðum günü için tarifler vb.
	Fotograf nvarchar(75),
	CONSTRAINT pk_ozelListe PRIMARY KEY(ID),	
)
GO
CREATE TABLE OzelGunTarifleri
(
	tarifID int,
	listeID int,
	CONSTRAINT pk_ozelTarifListeleri PRIMARY KEY(tarifID,listeID),
	CONSTRAINT fk_listeTarifleri_tarif FOREIGN KEY(tarifID) REFERENCES Tarifler(ID),
	CONSTRAINT fk_listeTarifleri_liste FOREIGN KEY(listeID) REFERENCES OzelGunListeleri(ID)
)