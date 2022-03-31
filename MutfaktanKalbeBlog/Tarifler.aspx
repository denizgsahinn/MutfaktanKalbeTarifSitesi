<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Tarifler.aspx.cs" Inherits="MutfaktanKalbeBlog.Tarifler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="float:left;width:20%;">
            <div class="menucontainer">
                <ul>
                    <a href='Tarifler.aspx'>
                        <li>Tümü</li>
                    </a>
                    <asp:Repeater ID="rp_tarifler" runat="server">
                        <ItemTemplate>
                            <a href='Tarifler.aspx?tid=<%# Eval("ID") %>'>
                                <li><%# Eval("Isim") %></li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <br />
            </div>
        </div>
        <div style="float:left;width:80%;">
            <asp:Panel ID="pnl_kategoriIsim" runat="server">
                <div class="catTitle">
                    <asp:Label ID="lbl_kategori" runat="server"></asp:Label>
                </div>
            </asp:Panel>

            <asp:ListView ID="lv_tarifler" runat="server">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="cardTarif">
                        <div class="cardPicture">
                            <img src='../TarifResimleri/<%# Eval("Fotograf") %>' />
                        </div>
                        <div class="cardtTittle"><label><%# Eval("Isim") %> </label></div>
                        <div style="padding-bottom: 7px; border-bottom: 1px solid silver; margin-bottom: 7px;">
                            <h6>Görüntülenme : <%# Eval("GoruntulenmeSayisi") %></h6>
                        </div>
                        <div class="cardbButton">
                            <a href="TarifDetay.aspx?tid= <%# Eval("ID") %>">Tarif Detay</a>
                            <%--<asp:LinkButton ID="lb_detay" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="lb_detay_Click">Tarif Detay</asp:LinkButton>--%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
