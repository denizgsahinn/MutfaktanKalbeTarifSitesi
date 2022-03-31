<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="YiyecekKalorileriListele.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.YiyecekKalorileriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
    <link rel="stylesheet" href="Css/fontawesome-free-6.1.1-web/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>KALORİ CETVELİ</h3>
        </div>
        <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_besinkalori" runat="server" OnItemCommand="lv_besinkalori_ItemCommand">
                <LayoutTemplate>
                    <table class="listTable" cellspacing="0" cellpadding="0">
                        <tr>

                            <th>Isim</th>
                            <th>Kategori</th>
                            <th>Miktar (Gr) </th>
                            <th>Porsiyon </th>
                            <th>Kalori (kcal)</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>

                        <td><%# Eval("Besin_adi") %></td>
                        <td><%# Eval("kaloriKategoriAdi") %></td>
                        <td><%# Eval("Miktar") %> </td>
                        <td><%# Eval("PorsiyonKarsiligi") %> </td>
                        <td><%# Eval("Besin_degeri") %> Kcal</td>
                        <td>
                            <a href='BesinKaloriGuncelle.aspx?bkid=<%# Eval("ID") %>' class="tablebutton update"><i class="fa-solid fa-pen-to-square"></i></a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete"><i class="fa-solid fa-trash-can" style="float:right;margin-right:10px;"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
