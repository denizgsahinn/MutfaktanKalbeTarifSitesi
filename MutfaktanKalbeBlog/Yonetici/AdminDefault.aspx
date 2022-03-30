<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <%--   <div class="option">
            <asp:LinkButton ID="lb_kategoriListele" runat="server" OnClick="lb_kategoriListele_Click"><h4>Kategori Listesi</h4></asp:LinkButton>
        </div>--%>


    


    <div class="section">
        <img src="../assets/images/Tarif.jpg" />
        <div class="option">
            <asp:LinkButton ID="lb_tarifKatEkle" runat="server" OnClick="lb_tarifKatEkle_Click"><h4> Tarif Kategorisi Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_tarifListele" runat="server" OnClick="lb_tarifListele_Click"><h4>Tarifleri Listele</h4></asp:LinkButton>
        </div>
        <div class="option">
             <asp:LinkButton ID="lb_tarifEkle" runat="server" OnClick="lb_tarifEkle_Click"><h4>Tarif Ekle</h4></asp:LinkButton>
        </div>

    </div>
    <div class="section">
        <img src="../assets/images/KacKalori.jpg" />
        <div class="option">
            <asp:LinkButton ID="lb_yiyecekEkle" runat="server" OnClick="lb_yiyecekEkle_Click"><h4>Yiyecek ve Kalori Bilgisi Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
             <asp:LinkButton ID="lb_kaloriListele" runat="server" OnClick="lb_kaloriListele_Click"><h4>Yiyecek ve Kalorilerini Listele</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_besinkategoriEkle" runat="server" OnClick="lb_besinkategoriEkle_Click"><h4>Yiyeceğin Kategori Bilgisini Ekle</h4></asp:LinkButton>
        </div>
    </div>
    <div class="section">
        <img src="../assets/images/Blog.jpg" />
        
        <div class="option">
            <asp:LinkButton ID="lb_makEkle" runat="server" OnClick="lb_makEkle_Click"><h4>Blog Yazısı ve Kategorisi Ekle</h4></asp:LinkButton>
        </div>
        <div class="option">
            <asp:LinkButton ID="lb_makListele" runat="server" OnClick="lb_makListele_Click"><h4>Blog Yazılarını Listele</h4></asp:LinkButton>
        </div>
 
    </div>

</asp:Content>
