<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="MakaleGuncelle.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.MakaleGuncelle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addArticleContainer">
        <div class="formtitle" style="padding: 10px;">
            <h3>Blog Yazısı Güncelle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Makale Güncelleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width: 450px; float: left">
                <div class="row">
                    <label>Makale Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
                <div class="row ">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row ">
                    <label>Kapak Resim</label><br /><br />
                     <asp:Image ID="img_resim" runat="server" Width="300" /><br />
                    Seçiniz :<asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row ">
                    <label>Makaleyi Yayınla</label>
                    <asp:CheckBox ID="cb_yayinla" runat="server" />
                </div>
                <div class="row" style="margin-bottom: 20px;">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>

            </div>
            <div style="width: 450px; float: left">

                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_makIcerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_guncelle" runat="server" CssClass="blogYazibutton" OnClick="lbtn_guncelle_Click">Makale Güncelle</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
