<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="TotalDealer_2008.User.ChangePassword" Theme="Red Glass" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/styles/Common.css" />
    <title></title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server" style="height: 100%; width: 100%; background-color: White">
    <br />
    <div align="center">
        <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" DefaultButton="btnChange" runat="server"
            Width="300px" Font-Size="Small" HeaderText="Change Password:" Height="110px"
             Font-Names="Tahoma">
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
            <HeaderStyle Font-Names="Tahoma" Font-Size="Small">
                <Paddings PaddingBottom="5px" PaddingLeft="7px" PaddingTop="5px" />
            </HeaderStyle>
            <TopRightCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpTopRightCorner.png" />
            <HeaderContent BackColor="#D01F3C">
                <BackgroundImage ImageUrl="~/App_Themes/Red Glass/Web/rpHeader.png" Repeat="RepeatX" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="#F7F7F7">
            </NoHeaderTopEdge>
            <PanelCollection>
                <dxp:PanelContent>
                    <table style="height: 55px; text-align: left">
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label2" Text="User Id (outlet number)" runat="server" 
                                    Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserId" runat="server" Font-Size="Small" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label1" Text="Old Password" runat="server" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" Font-Size="Small" Width="200px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label3" Text="New Password" runat="server" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" Font-Size="Small" Width="200px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label4" Text="Confirm Password" runat="server" Font-Names="Tahoma"
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" Font-Size="Small" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Button CssClass="btn_grey" ID="btnChange" Text="Change Password" runat="server"
                                    OnClick="btnChange_Click" BackColor="Gray" Width="150px"></asp:Button>
                            </td>
                            <td nowrap="nowrap">
                                <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
                            </td>
                            <td nowrap="nowrap">
                                <asp:Label ID="lblStatus" runat="server" CssClass="status_msg"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </dxp:PanelContent>
            </PanelCollection>
            <TopLeftCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpTopLeftCorner.png" />
            <BottomLeftCorner Height="2px" Url="~/App_Themes/Red Glass/Web/rpBottomLeftCorner.png" />
        </dxrp:ASPxRoundPanel>
        <asp:HyperLink ID="lnkBack" runat="server" Font-Names="Tahoma" Font-Size="Small"
            NavigateUrl="~/Login.aspx">Back</asp:HyperLink>
    </div>
    </form>
</body>
</html>
