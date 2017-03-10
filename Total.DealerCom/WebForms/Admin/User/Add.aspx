<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="TotalDealer_2008.User.Add" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/styles/Common.css" />
    <style type="text/css">
        #Table2
        {
            margin-right: 2px;
        }
        .style1
        {
            width: 203px;
        }
        .style2
        {
            width: 872px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" DefaultButton="btnOk"  runat="server" Width="200px" HeaderText="Add User">
        <PanelCollection>
            <dxp:PanelContent>
                <table cellpadding="4" id="Table1" width="100%" border="0">
                    <tr>
                        <td rowspan="2" style="font-family: Tahoma; font-size: small" class="style2">
                            <table cellspacing="0" cellpadding="2" border="0" id="Table2">
                                <tr>
                                    <td nowrap="nowrap" class="style1">
                                        <asp:Label ID="lblQuestion" runat="server" Text="User Type" EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropdownUserType" runat="server" Width="150px" AutoPostBack="true"
                                            EnableViewState="true" OnSelectedIndexChanged="dropdownUserType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>  
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="Label3" runat="server" Text="Email" EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblEmail" runat="server" Text="Outlet / Employee No." EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserID" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblDateRange" runat="server" Text="Service Station / Employee Name"
                                            EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td nowrap="nowrap" class="style1">
                                        <asp:Label ID="lblSalesArea" runat="server" Text="Sales Area" EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropdownSalesArea" runat="server" Width="150px" AutoPostBack="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRegion" runat="server" Text="Region" EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropdownRegion" runat="server" Width="150px" AutoPostBack="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBoutique" runat="server" Text="La Boutique" EnableViewState="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkBoutique" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </dxp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel><br />
    <table>
        <tr>
            <td>
                <asp:Button  CssClass="btn_grey"  ID="btnOk" runat="server" Text="Ok" Width="90px" OnClick="btnOk_Click">
                </asp:Button>
            </td>
            <td>
                <asp:Button  CssClass="btn_grey"  ID="btnCancel" runat="server" Text="Cancel" Width="90px" OnClick="btnCancel_Click">
                </asp:Button>                
            </td>
            <td>
            <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
