<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="EnCokGoruntulenenTarifler.aspx.cs" Inherits="MutfaktanKalbeBlog.Yonetici.EnCokGoruntulenenTarifler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cardContainer " style="margin-left:135px;">
        <div class="topic"><h2 style="text-align:center;padding:15px;border-bottom:2px dotted black;"> EN ÇOK GÖRÜNTÜLENEN TARİFLER</h2></div>
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
                        <a href="TarifIcerik.aspx?tid= <%# Eval("ID") %>">Tarif Detay</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
