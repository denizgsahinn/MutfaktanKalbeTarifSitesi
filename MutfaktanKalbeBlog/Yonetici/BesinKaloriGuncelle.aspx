<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="BesinKaloriGuncelle.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.BesinKaloriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Besin ve Kalori Bilgisi Güncelle</h3>
        </div>
         <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Kalori Tablosunda Günccelleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
             <div class="row">
                <label>Besin No</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="formInput" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Yiyecek Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput" ></asp:TextBox>
            </div>
             <div class="row">
                 <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
             </div>
             <div class="row">
                <label>Miktar</label><br />
                <asp:TextBox ID="tb_miktar" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
             <div class="row">
                <label>Porsiyon</label><br />
                <asp:TextBox ID="tb_porsiyon" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
             <div class="row">
                <label>Kalori Değeri</label><br />
                <asp:TextBox ID="tb_kalori" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_guncelle" runat="server" OnClick="lbtn_guncelle_Click" CssClass="formButton">Güncelle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
