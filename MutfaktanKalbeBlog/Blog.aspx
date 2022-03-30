<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="MutfaktanKalbeBlog.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="menucontainer">
        <ul>
            <a href='Blog.aspx'>
                <li>Tümü</li>
            </a>
            <asp:Repeater ID="rp_makaleler" runat="server">
                <ItemTemplate>
                    <a href='Blog.aspx?kid=<%# Eval("ID") %>'>
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


    <div class="articleDiv">
        <asp:ListView ID="lv_makaleler" runat="server">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="arthicle">
                    <div class="makaleTitle">
                        <h2><%# Eval("Baslik") %></h2>
                    </div>
                    <div class="image">
                        <img src='MakaleResimleri/<%# Eval("KapakResim") %>' />
                    </div>
                    <div class="subcontent">
                        Kategori: <%# Eval("Kategori") %> | Yazar :  <%# Eval("Yazar") %>
                    </div>
                    <div class="summary">
                        <%# Eval("Ozet") %>
                    </div>
                    <div class="linkButton">
                        <a href="MakaleDetay.aspx?mid= <%# Eval("ID") %>">Makalenin Devamı</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
