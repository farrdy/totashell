<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/WebForms/Master.Master"
    AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="TotalDealer_2008.LoginLog.Search" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v11.1" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <base target="_self" />
    <link rel="stylesheet" type="text/css" href="../Styles/Common.css" />
    <style type="text/css">
        #Table2
        {
            margin-right: 2px;
        }
        .style1
        {
            width: 203px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" DefaultButton="btnSearch"  runat="server" Width="200px" HeaderText="User Login Log Search">
        <PanelCollection>
            <dxp:PanelContent>
                <table cellspacing="0" cellpadding="2" border="0" id="Table2">
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblEmail" runat="server" Text="Outlet / Employee No." 
                                EnableViewState="False" Width="155px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserID" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="Station / Employee Name" 
                                EnableViewState="False" Width="170px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblDateRange" runat="server" Text="Date Range" EnableViewState="False"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="dtFromYear" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="dtFromMonth" runat="server">
                            </asp:DropDownList>
                            &nbsp;to
                            <asp:DropDownList ID="dtToYear" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="dtnToMonth" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </dxp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel><br />
    <table>
        <tr>
            <td>
                <asp:Button  CssClass="btn_grey"  ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    Width="90px"></asp:Button>
            </td>
            <td>
                <asp:Label ID="lblStatus" runat="server" CssClass="status_msg"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <div id="results">
        <div>
            <asp:Panel ID="CatPanel" runat="server"  Width="800px" ScrollBars="None">
                <asp:GridView ID="grdResults" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    HorizontalAlign="Center" Width="800px" OnPageIndexChanging="grdResults_PageIndexChanging"
                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1"  AllowSorting="True">
                    <PagerSettings Mode="NumericFirstLast" Visible="true" />
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="No"></asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="Name"></asp:BoundField>
                        <asp:BoundField DataField="LoginCount" HeaderText="Login Count"></asp:BoundField>
                        <asp:BoundField DataField="LastLogin" HeaderText="Last Login"></asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="pgr" />
                    <EmptyDataTemplate>
                        No results were found matching search criteria
                    </EmptyDataTemplate>
                    <EditRowStyle CssClass="EditRowStyle" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div><br/>
    <table>
        <tr>
            <td>
                <asp:Button  CssClass="btn_grey"  ID="btnDownload" runat="server" Text="Download" Width="90px" OnClick="btnDownload_Click"
                    Visible="False"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
