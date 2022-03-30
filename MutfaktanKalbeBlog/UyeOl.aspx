<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="MutfaktanKalbeBlog.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="choises">
        <%-- <asp:LinkButton ID="lb_anasayfa" runat="server" CssClass="mainpageButton">Ana Sayfaya Dön</asp:LinkButton>--%>
        <a href="Default.aspx" class="mainpageButton">Ana Sayfaya Dön</a>
        <h4 style="color: teal; margin-right: 80px;">ÜYE OL</h4>
    </div>
    <div class="form" style="background-color: #dedede">
        <h4>Üye Olmak İçin Gerekli Alanları Doldurunuz.</h4>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
            <label>Üyelik Kaydınız Başarıyla Gerçekleştirildi</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <asp:TextBox ID="tb_isim" runat="server" CssClass="textbox" placeholder="İsim Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_soyad" runat="server" CssClass="textbox" placeholder="Soyad Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="textbox" placeholder="Kullanıcı Adı Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" placeholder="E-Mail Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="textbox" TextMode="Password" placeholder="Parola Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifreTekrar" runat="server" CssClass="textbox" TextMode="Password" placeholder="Parolayı Tekrar Giriniz"></asp:TextBox>
        </div>
        <div class="row">
            <label>Fotoğraf</label><br />
            <br />
            Seçiniz :
            <asp:FileUpload ID="fu_resim" runat="server" />
        </div>
        <div class="row" style="margin-top: 15px; margin-left: 400px;">
            <asp:LinkButton ID="lb_uyeOl" runat="server" Text="Kaydol" OnClick="lb_uyeOl_Click" CssClass="formbutton"></asp:LinkButton>
        </div>


    </div>
</asp:Content>
