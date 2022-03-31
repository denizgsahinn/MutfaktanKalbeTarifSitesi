<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="TarifEkle.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.TarifEkle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="formtitle" style="margin-top:15px;">
            <h3>Tarif Ekle</h3>
        </div>
         <div class="formLongContent">
             <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Tarif Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:500px; float:left;margin-top:30px;">
                <div class="row">
                    <label style="font-size:12pt;">Tarifin Adı</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput2"></asp:TextBox>
                </div>
                <div class="row">
                    <label style="font-size:12pt;">Tarif Kategorisi</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                 <div class="row">
                      <label style="font-size:12pt;">Servis Sayısı (Kişi)</label><br />
                    <asp:TextBox ID="tb_servisSayi" runat="server" CssClass="formInput2"></asp:TextBox>
                 </div>
                 <div class="row">
                      <label style="font-size:12pt;">Pişirme Süresi (dk) </label><br />
                    <asp:TextBox ID="tb_pisirmeSure" runat="server" CssClass="formInput2"></asp:TextBox>
                 </div>
                 <div class="row">
                      <label style="font-size:12pt;">Pişirme Derecesi</label><br />
                    <asp:TextBox ID="tb_pisirmeDerece" runat="server" CssClass="formInput2"></asp:TextBox>
                 </div>
                 <div class="row">
                      <label style="font-size:12pt;">Kalori Bilgisi (kcal)</label><br />
                    <asp:TextBox ID="tb_kaloriBilgi" runat="server" CssClass="formInput2"></asp:TextBox>
                 </div>   
                <div class="row">
                    <label style="font-size:12pt;">Kapak Resim</label><br /><br />
                    Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
            </div>
            <div style="width:500px; float:left;margin-top:30px;">
                <div class="row">
                    <label>Malzemeler</label><br />
                     <asp:TextBox ID="tb_malzemeler" runat="server" CssClass="formInput" TextMode="MultiLine" Width="475px"></asp:TextBox>
                </div>
                 <div class="row">
                    <label>Yapılış Aşamaları</label><br />
                    <%--<asp:TextBox ID="tb_yapilisAsamalari" runat="server" CssClass="formInput" TextMode="MultiLine" ></asp:TextBox>--%>
                     <asp:TextBox ID="tb_yapilisAsamalari" runat="server" CssClass="formInput" TextMode="MultiLine" Width="475px"></asp:TextBox>
                </div>
                <div style="margin-top:30px;float:left;">
                     <label class="label2">Tarifi Yayınla</label> 
                    <asp:CheckBox ID="cb_yayinla" runat="server"/>
                
                </div>
                 <div class="row" style="margin-top:30px;">
                     <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="formButton addTarif ">Tarif Ekle</asp:LinkButton>
                </div>
            </div>
         </div>
</asp:Content>
