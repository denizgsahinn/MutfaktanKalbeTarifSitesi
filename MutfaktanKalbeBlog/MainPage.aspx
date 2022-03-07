<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="MutfaktanKalbeBlog.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ana Sayfa</title>
    <link href="mainPage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="contentHeader">
                <img src="assets/images/logo2.jpg" />
                <label class="pageName">MUTFAKTAN KALBE TARİFLER</label>
                <asp:LinkButton ID="ln_uyeOl" runat="server" CssClass="uyeButton">Üye Ol </asp:LinkButton>
                <asp:LinkButton ID="lb_uyeGiris" runat="server" CssClass="uyeButton">Giriş Yap </asp:LinkButton>
            </div>
            <%--<div class="pageTopics">
                <div class="circle" style="background-image:url()"></div>
                <div class="circle"></div>
                <div class="circle"></div>
                <div class="circle"></div>

            </div>
            <div class="choises">
                <div class="choiseTopics"><p class="pFont" style="margin-left:40px;">TARİFLER</p></div>
                <div class="choiseTopics"><p class="pFont" style="margin-left:30px;">Kaç Kalori?</p></div>
                <div class="choiseTopics"><p class="pFont">Özel Gün Listleri</p></div>
                <div class="choiseTopics"><p class="pFont" style="margin-left:-10px;">Blog</p></div>
            </div>--%>
            
        </div>
    </form>
</body>
</html>
