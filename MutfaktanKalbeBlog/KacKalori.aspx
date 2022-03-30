<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KacKalori.aspx.cs" Inherits="MutfaktanKalbeBlog.KacKalori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kaloriContainer">
        <div class="menucontainer">
            <ul>
                <a href='KacKalori.aspx'>
                    <li>Tümü</li>
                </a>
                <asp:Repeater ID="rp_besinKategoriler" runat="server">
                    <ItemTemplate>
                        <a href='KacKalori.aspx?bkid=<%# Eval("ID") %>'>
                            <li><%# Eval("Isim") %></li>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <br />
        </div>

        <asp:Panel ID="pnl_kategoriIsim" runat="server">
            <div class="catTitle">
                <asp:Label ID="lbl_kategori" runat="server"></asp:Label>
            </div>
        </asp:Panel>



        <asp:ListView ID="lv_besinKalorileri" runat="server" OnItemCommand="lv_besinKalorileri_ItemCommand">
            <LayoutTemplate>
                <table class="listTable" cellspacing="0" cellpadding="0">
                    <tr>
                        <th>Yiyecek</th>
                        <th>Kalori</th>
                        <th>Miktar</th>
                        <th>Porsiyon</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Besin_adi") %></td>
                    <td><%# Eval("Besin_degeri") %> &nbsp;Kcal</td>
                    <td><%# Eval("Miktar") %>&nbsp;Gram</td>
                    <td><%# Eval("PorsiyonKarsiligi") %></td>

                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
