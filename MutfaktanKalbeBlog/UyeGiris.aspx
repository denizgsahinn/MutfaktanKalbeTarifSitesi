<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="MutfaktanKalbeBlog.UyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="choises">
        <a href="Default.aspx" class="mainpageButton" >Ana Sayfaya Dön</a>
        <h4 style="margin-right:130px;">Üye Giriş</h4>
    </div>
   <div class="girisForm form">
        <div class="row" style="text-align:center">
            <img src="assets/images/272354.png" class="loginpanelimage"/>
        </div>
       <asp:panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap"  OnClick="lbtn_giris_Click" CssClass="formbutton"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
