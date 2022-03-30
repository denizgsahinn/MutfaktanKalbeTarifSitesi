<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="TarifleriListele.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.TarifleriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
    <link rel="stylesheet" href="Css/fontawesome-free-6.1.1-web/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="cardContainer" style="width: 775px;">
        <asp:Panel ID="pnl_kategoriIsim" runat="server">
            <div class="formtitle">
                <asp:Label ID="lbl_kategori" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_tarifler" runat="server" OnItemCommand="lv_tarifler_ItemCommand">
                <LayoutTemplate>
                    <table class="listTable" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>Resim</th>
                            <th>İsim</th>
                            <th>Kategori</th>
                            <th>Ekleme Tarihi</th>
                            <th>Görüntülenme Sayısı</th>
                            <th>Yayımlanma Durumu</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src='../TarifResimleri/<%# Eval("Fotograf") %>' width="100" /></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("kategoriAdi") %></td>
                        <td><%# Eval("EklemeTarih") %></td>
                        <td><%# Eval("GoruntulenmeSayisi") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton>
                            <a href='TarifGuncelle.aspx?tid=<%# Eval("ID") %>' class="tablebutton update"><i class="fa-solid fa-pen-to-square"></i></a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete"><i class="fa-solid fa-trash-can" style="float:right;margin-right:10px;"></i></asp:LinkButton>
                            <div class="tablebutton detail"><a href="TarifIcerik.aspx?tid= <%# Eval("ID") %>">Tarif Detay</a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="rightMenu">
        <ul style="padding: 15px; border-bottom: 1px solid silver; text-align: center; font-weight: 800;">TARİF KATEGORİLERİ</ul>
        <ul>
            <a href='TarifleriListele.aspx'>
                <li>Tümü</li>
            </a>
            <asp:Repeater ID="rp_kategoriler" runat="server">
                <ItemTemplate>
                    <a href='TarifleriListele.aspx?kid=<%# Eval("ID") %>'>
                        <li><%# Eval("Isim") %></li>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

    </div>
</asp:Content>
