<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="TotalDealer_2008.LoginAs.Search" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <base target="_self" />
    <link rel="stylesheet" type="text/css" href="../Styles/Common.css" />
    <style type="text/css">
        #Table2 {
            margin-right: 2px;
        }

        .style1 {
            width: 203px;
        }

        .style2 {
            width: 872px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="page-content">
        <ol class="breadcrumb">

            <li class=""><a href="#">Home</a></li>
            <li class=""><a href="#">Admin</a></li>
            <li class="active"><a href="#">Login As</a></li>

            <div style="float: right">
                <li style="text-align: right">Logged in user: John Doe</li>
            </div>


        </ol>
    </div>
    <div class="container-fluid">

        <h2 class="page-heading-large">Login As</h2>
        <p>Please select user type and search for a user to login as</p>
        <div data-widget-group="group1">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-total-red" data-widget='{"draggable": "false"}'>
                        <div class="panel-heading">
                            <h2>User Search Form</h2>
                        </div>
                    </div>
                </div>


            </div>

            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="horizontal-form">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="dropdownUserType" class="col-sm-2 control-label">User Type</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList class="form-control" ID="dropdownUserType" runat="server" AutoPostBack="true"
                                        EnableViewState="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtUserID" class="col-sm-2 control-label">Outlet / Employee No.</label>
                                <div class="col-sm-8">
                                    <asp:TextBox class="form-control" ID="txtUserID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtName" class="col-sm-2 control-label">Service Station / Employee Name</label>
                                <div class="col-sm-8">
                                    <asp:TextBox class="form-control" ID="txtName" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2">
                    <asp:Button class="btn-primary btn" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                        Width="90px"></asp:Button>
                    <asp:Label ID="lblStatus" runat="server" BackColor="Yellow" Font-Bold="True" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table">
            <tr>
                <td align="center">
                    <asp:GridView ID="grdResults" runat="server" AllowPaging="true" DataKeyNames="Id"
                        class="table" PagerStyle-CssClass="pgr" 
                        AutoGenerateColumns="False" Width="800" OnPageIndexChanging="grdResults_PageIndexChanging"
                        AllowSorting="True" BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1" GridLines="None">
                        <PagerSettings Mode="NumericFirstLast" Visible="true" />
                        <Columns>
                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" DataNavigateUrlFields="Id" Text="Login As"
                                Target="_self" HeaderText="Login" DataNavigateUrlFormatString="Login.aspx?UserID={0}">
                                <ControlStyle Font-Underline="True"></ControlStyle>
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Id" HeaderText="No"></asp:BoundField>
                            <asp:BoundField DataField="UserName" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField DataField="idRole" HeaderText="User Type"></asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="pgr" />
                        <EmptyDataTemplate>
                            No results were found matching search criteria
                        </EmptyDataTemplate>
                        <EditRowStyle CssClass="EditRowStyle" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
