<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KaloriKategoriGuncelle.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.KaloriKategoriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Yiyecek Kalori Kategori Bilgisi Güncelle</h3>
        </div>
         <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Kalori Tablosuna Besin Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
              <div class="row">
                <label>Kategori No</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="formInput" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Yiyecek Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
             <div class="row">
                    <label>Kapak Fotoğrafı</label><br /><br />
                    Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
             </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_guncelle" runat="server" OnClick="lbtn_guncelle_Click" CssClass="formButton">Güncelle</asp:LinkButton>
                <asp:LinkButton ID="lbtn_listele" runat="server" OnClick="lbtn_listele_Click" CssClass="formButton right">Kalori Kategorisi Listele</asp:LinkButton>
            </div>

             <div class="row">
                
            </div>
        </div>
    </div>
</asp:Content>
