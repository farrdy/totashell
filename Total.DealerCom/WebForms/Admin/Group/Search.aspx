<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="TotalDealer_2008.Group.Search" %>

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
            <li class="active"><a href="#">Group Maintenance</a></li>

            <div style="float: right">
                <li style="text-align: right">Logged in user: John Doe</li>
            </div>


        </ol>
    </div>
    <div class="container-fluid">

        <h2 class="page-heading-large">Group Maintenance</h2>
        <p>Please fill out search form or click search to view all groups</p>
        <div data-widget-group="group1">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-total-red" data-widget='{"draggable": "false"}'>
                        <div class="panel-heading">
                            <h2>Group Search Form</h2>
                        </div>
                    </div>
                </div>


            </div>

            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="horizontal-form">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtGroupName" class="col-sm-2 control-label">User Type</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtGroupName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtNo" class="col-sm-2 control-label">Outlet / Employee No.</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtNo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtName" class="col-sm-2 control-label">Outlet / Employee Name</label>
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
                    <asp:Button class="btn-primary btn" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                    <asp:Button class="btn-default btn" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Are you sure you want to remove these groups?');"></asp:Button>
                    <asp:Button class="btn-default btn" ID="btnAdd" runat="server" Text="Add" OnClick="btn_Add_Click"></asp:Button>
                    <asp:Label ID="lblStatus" runat="server" BackColor="Yellow" Font-Bold="True" Font-Size="Small"></asp:Label>
                    <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table">
            <tr>
                <td align="center">
                    <asp:GridView ID="grdResults" runat="server" AllowPaging="true" DataKeyNames="IdGroup"
                        AutoGenerateColumns="False" HorizontalAlign="Center" Width="800" class="table" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="grdResults_PageIndexChanging" PageSize="10" AllowSorting="True"
                        BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1" GridLines="None">
                        <PagerSettings Mode="NumericFirstLast" Visible="true" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="UserSelector" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" DataNavigateUrlFields="IdGroup, GroupName, SpecialGroup"
                                Text="Edit" Target="_self" HeaderText="" DataNavigateUrlFormatString="Edit.aspx?GroupId={0}&GroupName={1}&Special={2}">
                                <ControlStyle Font-Underline="True"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:HyperLinkField>
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="SpecialGroup" HeaderText="Special Group">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="GroupName" HeaderText="Group Name">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
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
