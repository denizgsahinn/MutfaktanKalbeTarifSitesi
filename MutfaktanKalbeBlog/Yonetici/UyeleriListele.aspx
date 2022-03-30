<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="UyeleriListele.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.UyeleriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
    <link rel="stylesheet" href="Css/fontawesome-free-6.1.1-web/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="cardContainer" style="width:950px;margin-left:50px;">
       <div class="formtitle">
           <h3>Üyeler</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>Fotoğraf</th>
                           <th>İsim</th>
                           <th>Soyisim</th>
                           <th>Kullanıcı Adı</th>
                           <th>Email</th>
                           <th>Üyelik Tarihi</th>
                           <th>Durum</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                      <%--<td><img src='../UyeResimleri/<%# Eval("Fotograf") %>' width="50" /></td>--%>
                       <td><img src='../UyeResimleri/<%# Eval("Fotograf") %>'  width="50" /></td>
                       <td><%# Eval("Isim") %></td> 
                       <td><%# Eval("Soyisim") %></td>
                       <td><%# Eval("KullaniciAdi") %></td>
                       <td><%# Eval("Email") %></td>
                       <td><%# Eval("UyelikTarihi") %></td>
                       <td><%# Eval("Durum") %></td>
                       <td>
                           <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton>
                           <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete"><i class="fa-solid fa-trash-can" style="float:right;margin-right:10px;"></i></asp:LinkButton>
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
