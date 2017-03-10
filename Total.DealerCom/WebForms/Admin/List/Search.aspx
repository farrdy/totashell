<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Search.aspx.cs" Inherits="TotalDealer_2008.List.Search" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .fixedHeader
        {
            overflow: auto;
            height: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px" HeaderText="List Search">
        <PanelCollection>
            <dxp:PanelContent>
                <table runat="server" id="OptionTable">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblList" Text="List: "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ListOptions">
                                <asp:ListItem Selected="True" Text="Dealer Communication Category" Value="ArticleCat"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="Dealer Communication Type" Value="ArticleType"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button CssClass="btn_grey" ID="btnFind" runat="server" Text="Find" Width="90px"
                                OnClick="btnFind_Click"></asp:Button>
                        </td>
                        <td>
                            <asp:Button CssClass="btn_grey" ID="btnCatAdd" runat="server" Text="Add" Width="90px"
                                OnClick="btnAddCategory_Click"></asp:Button>
                        </td>
                        <td nowrap="nowrap">
                            <asp:Label ID="lblCatStatus" runat="server" Text="" CssClass="status_msg"></asp:Label>
                        </td>
                        <td nowrap="nowrap">
                            <asp:Label ID="lblError" runat="server" Text="" CssClass="error_msg"></asp:Label>
                        </td>
                    </tr>
                </table>
            </dxp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
    <br />
    <div id="Category">
        <asp:Panel ID="CatPanel" runat="server" Width="700px" ScrollBars="None">
            <asp:GridView ID="grdCatResults" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                Width="100%" AutoGenerateEditButton="true" DataKeyNames="Id, idParent, LookupName"
                AllowSorting="True" BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1" GridLines="None"
                OnRowCommand="grdCatResults_RowCommand" OnRowCancelingEdit="grdCatResults_RowCancelingEdit"
                OnRowEditing="grdCatResults_RowEditing" OnRowUpdated="grdCatResults_RowUpdated"
                OnRowUpdating="grdCatResults_RowUpdating" OnPageIndexChanging="grdCatResults_PageIndexChanging1"
                OnRowDataBound="grdCatResults_RowDataBound">
                <PagerSettings Mode="NumericFirstLast" Visible="true" />
                <Columns>
                    <asp:BoundField DataField="Value" ReadOnly="false" HeaderText="Value"></asp:BoundField>
                    <asp:CheckBoxField DataField="isActive" ReadOnly="false" HeaderText="Active" />
                    <asp:BoundField DataField="SortOrder" ReadOnly="false" HeaderText="Sort Order"></asp:BoundField>
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
    <br />
    <div id="Types">
        <dxrp:ASPxRoundPanel ID="TypesPanel" runat="server" Width="200px" HeaderText="Type Search">
            <PanelCollection>
                <dxp:PanelContent>
                    <table runat="server" id="TypesTable">
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="Label1" Text="Types: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="dropdownTypes">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button CssClass="btn_grey" ID="btnTypeSelect" runat="server" Text="Select" Width="90px"
                                    OnClick="btnSelectType_Click"></asp:Button>
                            </td>
                            <td>
                                <asp:Button CssClass="btn_grey" ID="btnTypeAdd" runat="server" Text="Add" Width="90px"
                                    OnClick="btnAddType_Click"></asp:Button>
                            </td>
                            <td nowrap="nowrap">
                                <asp:Label ID="lblTypeStatus" runat="server" Text="" CssClass="status_msg"></asp:Label>
                            </td>
                            <td nowrap="nowrap">
                                <asp:Label ID="lblErrorTypes" runat="server" Text="" CssClass="error_msg"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </dxp:PanelContent>
            </PanelCollection>
        </dxrp:ASPxRoundPanel>
        <br />
        <div>
            <asp:Panel ID="TypePanel" runat="server" Width="700px" ScrollBars="None">
                <asp:GridView ID="grdResults" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                    Width="100%" AutoGenerateEditButton="true" DataKeyNames="Id, idParent, LookupName"
                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    AllowSorting="True" BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1" GridLines="None"
                    OnRowCommand="grdResults_RowCommand" OnRowCancelingEdit="grdResults_RowCancelingEdit"
                    OnRowEditing="grdResults_RowEditing" OnRowUpdated="grdResults_RowUpdated" OnRowUpdating="grdResults_RowUpdating"
                    OnPageIndexChanging="grdResults_PageIndexChanging1" OnRowDataBound="grdResults_RowDataBound">
                    <PagerSettings Mode="NumericFirstLast" Visible="true" />
                    <Columns>
                        <asp:BoundField DataField="Value" ReadOnly="false" HeaderText="Value"></asp:BoundField>
                        <asp:CheckBoxField DataField="isActive" ReadOnly="false" HeaderText="Active" />
                        <asp:BoundField DataField="SortOrder" ReadOnly="false" HeaderText="Sort Order"></asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="pgr" />
                    <EmptyDataTemplate>
                        Selected category currently has no Dealer Communication Types.
                    </EmptyDataTemplate>
                    <EditRowStyle CssClass="EditRowStyle" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
