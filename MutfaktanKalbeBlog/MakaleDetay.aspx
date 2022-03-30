<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="MutfaktanKalbeBlog.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/Css/FormStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/fontawesome-free-6.1.1-web/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="display: inline-block; margin-left: 20px; margin-top: 10px;margin-bottom:15px;">
            <asp:LinkButton ID="lb_geri" runat="server" OnClick="lb_geri_Click"><i class="fa-solid fa-circle-arrow-left fa-2xl fa-beat"></i></asp:LinkButton>
        </div>
    <div class="arthicle">
        <div class="title">
            <h2><asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h2>
        </div>
        <div class="image">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="subcontent">
            Kategori:
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Yazar : 
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
        </div>
        <div class="summary">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>
    </div>
     <div style="min-height: 500px;">
        <div class="yorum" style="margin-top:50px;">
            
            <asp:Panel ID="pnl_girisVar" runat="server" Visible="false" CssClass="pnl_giris">
                <br /><br />


                <h3 style="margin:10px;">Yorumunuzu Yazınız</h3>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="YorumKutu"></asp:TextBox>
                <br /><br /><br />
                <asp:LinkButton ID="lbtn_yorumYap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumYap_Click"  CssClass="yorumYapButton">
                </asp:LinkButton>                
            </asp:Panel>

            <div class="yorumPanelBaslik"><h2>Yorumlar</h2></div>

            <asp:Panel ID="pnl_girisyok" runat="server" style="margin:10px 0;">
                <h2>Yorum yapabilmek için lütfen <a href="uyegiris.aspx">giriş yapınız </a></h2>
            </asp:Panel>

            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorumitem">
                        <i class="fa-solid fa-circle-user" style="margin-left:10px;margin-right:10px;"></i>
                        <label><%# Eval("Uye") %></label> | <label><%# Eval("Tarih") %></label>
                        <br /><br />
                        <i class="fa-solid fa-comment" style="margin-left:10px;margin-right:10px;"></i>
                        <span><%# Eval("Icerik") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
