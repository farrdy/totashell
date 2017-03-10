<%@ Page Language="C#" ValidateRequest="true"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TotalDealer_2008.Login"
     EnableSessionState="True" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title id="title">Login page</title>
    <link rel="stylesheet" type="text/css" href="~/Content/styles/Common.css" />

    <script type="text/javascript">
      function HideErrorMsg() {
          var message = document.getElementById('divErrorMsg');
          message.style.display = 'none';
      }
    </script>
 </head>
<body style="background-color: White">
    <form id="form1" runat="server" style="height: 100%; width: 100%; background-color: White">
    <br />
    <div align="center" style="background-color: White">
        <div style="width: 400px; margin: 0 auto; text-align: left; background-color: White">
            <table style="height:100%; vertical-align:middle">
                <tr>
                    <td>
                    <dxrp:ASPxRoundPanel runat="server" HeaderText="Please enter your login details:" 
                             HorizontalAlign="Left" Width="300px" Font-Size="Small"
                            Height="221px" DefaultButton="btnLogin">
                   
                            <TopEdge BackColor="#EA9CA8">
                            </TopEdge>
                            <BottomRightCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpBottomRightCorner.png" />
                            <ContentPaddings Padding="9px" />
                            <HeaderRightEdge BackColor="#D01F3C">
                                <BackgroundImage ImageUrl="~/App_Themes/Red Glass/Web/rpHeader.png" Repeat="RepeatX" />
                            </HeaderRightEdge>
                            <Border BorderColor="#959595" />
                            <HeaderLeftEdge BackColor="#D01F3C">
                                <BackgroundImage ImageUrl="~/App_Themes/Red Glass/Web/rpHeader.png" Repeat="RepeatX" />
                            </HeaderLeftEdge>
                            <HeaderStyle>
                                <Paddings PaddingBottom="5px" PaddingLeft="7px" PaddingTop="5px" />
                            </HeaderStyle>
                            <TopRightCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpTopRightCorner.png" />
                            <HeaderContent BackColor="#D01F3C">
                                <BackgroundImage ImageUrl="~/App_Themes/Red Glass/Web/rpHeader.png" Repeat="RepeatX" />
                            </HeaderContent>
                            <NoHeaderTopEdge BackColor="#F7F7F7">
                            </NoHeaderTopEdge>
                            <PanelCollection>
                                <dxp:PanelContent ID="PanelContent1" runat="server">
                                    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="Small" ForeColor="#666666"
                                        Text="Username (outlet number):">
                                    </dxe:ASPxLabel>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtUserName" runat="server" Font-Size="Small" Width="200px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Font-Size="Small" ForeColor="#666666"
                                        Text="Password:">
                                    </dxe:ASPxLabel>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" TextMode="Password"
                                        Width="200px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <font size="1" color="#AFAFAF">Please note: The password is case sensitive.</font><br /><br />
                                    <asp:Button CssClass="btn_grey" ID="btnLogin" runat="server" EnableViewState="False"
                                        OnClick="btnLogin_Click" Text="Login" />
                                </dxp:PanelContent>
                            </PanelCollection>
                            <TopLeftCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpTopLeftCorner.png" />
                            <BottomLeftCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpBottomLeftCorner.png" />
                        </dxrp:ASPxRoundPanel>   
                        <table>
                        <tr>
                             <td align="right" style="font-size:xx-small; color:Gray">
                                <asp:Label runat="server" ID="lblVersion" Width="300px" Text='<%= GetApplicationVersion() %>'></asp:Label>
                                </td>
                            </tr>
                        </table>                     
                        <asp:ValidationSummary ID="validationSummary" runat="server" Width="321px" Font-Names="Tahoma"
                            Font-Size="Small" />
                        <table width="500" style="font-family: Tahoma; font-size: small; vertical-align: middle;
                            text-align: left;">                        
                            
                            <tr>
                                <td>
                                    <asp:Label runat="server" CssClass="error_msg" Font-Size="Small" ID="lblMessage"></asp:Label>
                                </td>                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Font-Size="Small" ID="lblAdd" Text="Additional Options:"
                                        Font-Names="Tahoma" ForeColor="Maroon" Style="font-weight: 700"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkForgotPassword" runat="server" Font-Names="Tahoma" Font-Size="Small"
                                        NavigateUrl="~/User/ResetPassword.aspx" Target="_self">Forgotten Password</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="lnkChangePassword" runat="server" Font-Names="Tahoma" Font-Size="Small"
                                        NavigateUrl="~/User/ChangePassword.aspx" Target="_self">Change Password</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    If you experience problems accessing the system, please  
                                    <asp:HyperLink runat="server" ID="lblURL"></asp:HyperLink> us or call                                   
                                    (011) 778 2070.</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
