<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="BlogYaziEkle.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.BlogYaziEkle"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addArticleContainer">
        <div class="subtitle">
            <%--<div class="formContent">--%>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                    <label>Kategori Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>

                <div class="row">
                    <label style="margin-right: 30px; margin-left: 15px;">Blog Yazısı Kategorisi Ekle:</label><br />

                    <asp:TextBox ID="tb_katIsim" runat="server" CssClass="formInput"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_katEkle" runat="server" OnClick="lbtn_katEkle_Click" CssClass="formButton2">Kategorilere Ekle</asp:LinkButton><br />
                    <asp:LinkButton ID="lbtn_katListele" runat="server" CssClass="formButton2 right3" OnClick="lbtn_katListele_Click">Kategorileri Listele</asp:LinkButton>
                </div>
            <%--</div>--%>
        </div>
        <div class="formtitle" style="padding:10px;margin-top:20px;">
            <h3>Blog Yazısı Ekle</h3>
        </div>
                <div class="formContent2">
                   <%-- <asp:Panel ID="pnl_basarili2" runat="server" CssClass="basariliMesaj" Visible="false">
                        <label>Makale Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
                    </asp:Panel>
                    <asp:Panel ID="pnl_basarisiz2" runat="server" CssClass="basarisizMesaj" Visible="false">
                        <asp:Label ID="lbl_mesaj2" runat="server"></asp:Label>
                    </asp:Panel>--%>
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
                            <label>Kapak Resim</label><br />
                            <br />
                            Seçiniz :
                            <asp:FileUpload ID="fu_resim" runat="server" />
                        </div>
                        <div class="row ">
                            <label>Makaleyi Yayınla</label>
                            <asp:CheckBox ID="cb_yayinla" runat="server" />
                        </div>
                        <div class="row" style="margin-bottom:20px;">
                            <label>Özet</label><br />
                            <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div style="width: 450px; float: left">
                        
                        <div class="row" >
                            <label>İçerik</label><br />
                            <asp:TextBox ID="tb_makIcerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:LinkButton ID="lbtn_yaziEkle" runat="server" CssClass="blogYazibutton" OnClick="lbtn_yaziEkle_Click">Yazı Ekle</asp:LinkButton>
                        </div>
                    </div>
                   <%-- <div class="row" style="clear: both">
                        <asp:LinkButton ID="lbtn_yaziEkle" runat="server" OnClick="lbtn_yaziEkle_Click" CssClass="formButton">Yazıyı Ekle</asp:LinkButton>
                    </div>--%>
                </div>
            

       
    </div>
</asp:Content>
