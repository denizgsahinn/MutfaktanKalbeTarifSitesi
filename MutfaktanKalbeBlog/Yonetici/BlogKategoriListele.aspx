<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="BlogKategoriListele.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.BlogKategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
    <link rel="stylesheet" href="Css/fontawesome-free-6.1.1-web/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
       <div class="formtitle">
           <h3>Blog Yazısı Konu Listesi</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_blogKategoriler" runat="server" OnItemCommand="lv_blogKategoriler_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                          <%-- <th>Tür</th>--%>
                           <th>İsim</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <%--<td><%# Eval("Tur") %></td>--%>
                       <td><%# Eval("Isim") %></td>
                       <td>
                           <a href='BlogKategoriGuncelle.aspx?bkid=<%# Eval("ID") %>' class="tablebutton update"><i class="fa-solid fa-pen-to-square"></i></a>

                           <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete"><i class="fa-solid fa-trash-can" style="float:right;margin-right:10px;"></i></asp:LinkButton>
                       </td>
                       
                   </tr>
               </ItemTemplate>
           </asp:ListView>
           <div class="row">
               <asp:LinkButton ID="lb_geri" runat="server" CssClass="formButton backButton" OnClick="lb_geri_Click" >GERİ DÖN</asp:LinkButton>
           </div>
       </div>

   </div>
</asp:Content>
