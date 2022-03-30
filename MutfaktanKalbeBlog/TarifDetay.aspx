<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TarifDetay.aspx.cs" Inherits="MutfaktanKalbeBlog.TarifDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/fontawesome-free-6.1.1-web/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row" style="display: inline-block; margin-left: 20px; margin-top: 10px;">
            <asp:LinkButton ID="lb_geri" runat="server" OnClick="lb_geri_Click"><i class="fa-solid fa-circle-arrow-left fa-2xl fa-beat"></i></asp:LinkButton>
        </div>
        <div class="tarifTitle">
            <h2>
                <asp:Literal ID="ltrl_title" runat="server"></asp:Literal></h2>
        </div>
        <div style="margin-left:30px;">
            <div class="tarifImage">
                <asp:Image ID="img_recipe" runat="server" />
            </div>

            <div class="section_malzemeler">
                <h3 style="margin-bottom: 10px;">MALZEMELER</h3>
                <asp:Literal ID="ltrl_malzemeler" runat="server"></asp:Literal>
            </div>
        </div>
        <div <%--style="float:left;--%>">

            <div class="section_bilgi">

                <ul>
                    <li>
                        <label>Kategori: </label>
                        <span>
                            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>

                        </span>
                    </li>
                    <li>
                        <label>Servis Sayısı:</label>
                        <span>
                            <asp:Literal ID="ltrl_servis" runat="server"></asp:Literal>

                        </span>
                    </li>
                    <li>
                        <label>Pişirme Süresi: </label>
                        <span>
                            <asp:Literal ID="ltrl_sure" runat="server"></asp:Literal>

                        </span>
                    </li>
                    <li>
                        <label>Pişirme Derecesi:</label>
                        <span>
                            <asp:Literal ID="ltrl_derece" runat="server"></asp:Literal>

                        </span>
                    </li>
                    <li>
                        <label>Kalori Bilgisi:</label>
                        <span>
                            <asp:Literal ID="ltrl_kalori" runat="server"></asp:Literal>
                        </span>
                    </li>
                    <li>
                        <label>Eklenme Tarihi: </label>
                        <span>
                            <asp:Literal ID="ltrl_ekleTarih" runat="server"></asp:Literal>

                        </span>
                    </li>
                    <li>
                        <label>Görüntülenme Sayısı:</label>
                        <span>
                            <asp:Literal ID="ltrl_goruntulenme" runat="server"></asp:Literal>

                        </span>
                    </li>
                </ul>
            </div>

            <div class="section_yapilis">
                <h3 style="margin-bottom: 10px;">YAPILIŞ AŞAMALARI</h3>
                <asp:Literal ID="ltrl_yapilis" runat="server"></asp:Literal>
            </div>

        </div>
    </div>
</asp:Content>
<%--    <div class="row info">
            <label>Kategori: </label>
            <span>
                <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Servis Sayısı:</label>
            <span>
                <asp:Literal ID="ltrl_servis" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Pişirme Süresi: </label>
            <span>
                <asp:Literal ID="ltrl_sure" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Pişirme Derecesi:</label>
            <span>
                <asp:Literal ID="ltrl_derece" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Kalori Bilgisi:</label>
            <span>
                <asp:Literal ID="ltrl_kalori" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Eklenme Tarihi: </label>
            <span>
                <asp:Literal ID="ltrl_ekleTarih" runat="server"></asp:Literal></span>
        </div>
        <div class="row info">
            <label>Görüntülenme Sayısı:</label>
            <span>
                <asp:Literal ID="ltrl_goruntulenme" runat="server"></asp:Literal></span>
        </div>--%>