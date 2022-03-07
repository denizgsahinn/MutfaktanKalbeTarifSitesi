<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <img src="../assets/images/Tarif.jpg" />
        <div class="option">
            <asp:LinkButton ID="lb_kategoriEkle" runat="server" OnClick="lb_kategoriEkle_Click"><h4>Kategori Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_kategoriListele" runat="server"><h4>Kategorileri Listele</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_tarifEkle" runat="server"><h4>Tarif Ekle</h4></asp:LinkButton>
        </div>        
        <div class="option">
            <asp:LinkButton ID="lb_tarifListele" runat="server"><h4>Tarifleri Kategorilerine Göre Listele</h4></asp:LinkButton>
        </div>        
    </div>
    <div class="section">
        <img src="../assets/images/KacKalori.jpg" />
        <div class="option">
            <asp:LinkButton ID="lb_yiyecekEkle" runat="server"><h4>Yiyecek ve Kalori Bilgisi Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_kaloriListele" runat="server"><h4>Yiyecek ve Kalorilerinin Tablosunu Listele</h4></asp:LinkButton>
        </div>
    </div>
    <div class="section">
        <img src="../assets/images/Blog.jpg" />
        <div class="option">
            <asp:LinkButton ID="lb_makKatEkle" runat="server"><h4>Makale Kategorisi Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_makEkle" runat="server"><h4>Makale Ekle</h4></asp:LinkButton>
        </div><div class="option">
            <asp:LinkButton ID="lb_makListele" runat="server"><h4>Makaleleri Listele</h4></asp:LinkButton>
        </div>

    </div>
</asp:Content>
