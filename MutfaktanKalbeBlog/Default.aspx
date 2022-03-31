<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MutfaktanKalbeBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="cardContainer">
        <div class="topic"><h2> EN POPÜLER TARİFLER</h2></div>
        <asp:Repeater ID="rp_populerTarifler" runat="server">
            <ItemTemplate>
                <div class="card">
                    <div class="picture">
                        <img src='../TarifResimleri/<%# Eval("Fotograf") %>' />
                    </div>
                    <div class="tittle"><%# Eval("Isim") %></div>
                    <div style="padding-bottom: 7px; border-bottom: 1px solid silver; margin-bottom: 7px;">
                        <h6>Görüntülenme : <%# Eval("GoruntulenmeSayisi") %></h6>
                    </div>
                    <div class="button">
                        <a href="TarifDetay.aspx?tid= <%# Eval("ID") %>">Tarif Detay</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
