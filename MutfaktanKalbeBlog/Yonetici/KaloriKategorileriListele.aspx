<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KaloriKategorileriListele.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.KaloriKategorileriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="formContainer">
       <div class="formtitle">
           <h3>Besin Kalori Kategorileri</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>İsim</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("Isim") %></td>
                       <td>
                           <a href='KaloriKategoriGuncelle.aspx?kkid=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>

                           <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                       </td>
                       
                   </tr>
               </ItemTemplate>
           </asp:ListView>
           <div class="row">
               <asp:LinkButton ID="lb_geri" runat="server" CssClass="formButton backButton" OnClick="lb_geri_Click" >GERİ</asp:LinkButton>
           </div>
       </div>

   </div>
</asp:Content>
