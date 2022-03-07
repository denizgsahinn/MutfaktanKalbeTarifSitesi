<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="MutfaktanKalbeBlog.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Sayfası</title>
    <link href="Css/Giris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="FormContainer">
            <div class="ContainerTitle">  
                <h2> Yönetici Giriş </h2>
            </div>
            <div class="contentContainer">
                <div class="info"> 
                    <label class="Label">Mail / Kullanıcı Adı</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="textBox" placeholder="demo@demo.com"> </asp:TextBox>
                </div>
                 <div class="info"> 
                    <label class="Label">Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="textBox" TextMode="Password" placeholder="Şifreniz"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" CssClass="girisButton" OnClick="btn_giris_Click"/>
                </div>
                <asp:Panel ID="hata_pnl" runat="server" CssClass="hataMesaj" Visible="false" > 
                    <asp:Label ID="lbl_mesaj" runat="server"> Hata Mesajı</asp:Label>
                </asp:Panel>
            </div>
            
        </div>
    </form>
</body>
</html>
