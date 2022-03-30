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
                <asp:LinkButton ID="ln_uyeOl" runat="server" CssClass="uyeButton">Üye Ol </asp:LinkButton>
                <asp:LinkButton ID="lb_uyeGiris" runat="server" CssClass="uyeButton">Giriş Yap </asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
