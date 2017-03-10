<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="TotalDealer_2008.Group.Edit" %>

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
        <p>Please edit group by adding and removing Group Members</p>
        <div data-widget-group="group1">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-total-red" data-widget='{"draggable": "false"}'>
                        <div class="panel-heading">
                            <h2>Edit Group Form</h2>
                        </div>
                    </div>
                </div>


            </div>

            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane active" id="horizontal-form">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtGroupName" class="col-sm-2 control-label">Group Name</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtGroupName" runat="server" class="form-control"></asp:TextBox>
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
                    <asp:Button class="btn-primary btn" ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click"></asp:Button>
                    <asp:Button class="btn-default btn" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"></asp:Button>
                    <asp:Label ID="lblStatus" runat="server" CssClass="status_msg"></asp:Label>
                    <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <table class="table">
        <tr>
            <td align="center" style="width: 50%">
                <asp:GridView ID="grdMembers" runat="server" AllowPaging="true" DataKeyNames="Id"
                    CssClass="table" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="table"
                    AutoGenerateColumns="False" HorizontalAlign="Center" Width="100%"
                    PageSize="5" AllowSorting="True" BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1"
                    GridLines="None" Caption="Members:" OnPageIndexChanging="grdMembers_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" Visible="true" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="UserSelector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Id" HeaderText="No.">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="UserName" HeaderText="Name">
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
            <td align="center" style="width: 50%">
                <asp:GridView ID="grdNonMembers" runat="server" AllowPaging="true" DataKeyNames="Id"
                    CssClass="table" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="table"
                    AutoGenerateColumns="False" HorizontalAlign="Center" Width="100%"
                    PageSize="5" AllowSorting="True" BorderStyle="Ridge" CaptionAlign="Top" CellPadding="1"
                    GridLines="None" Caption="Non Members:" OnPageIndexChanging="grdNonMembers_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" Visible="true" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="UserSelector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Id" HeaderText="No.">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="UserName" HeaderText="Name">
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
        
        <br />
        <tr>
            <td>
                <asp:Button class="btn-primary btn" ID="btnDeleteMember" runat="server" Text="Remove Member"
                    OnClick="btnDeleteMember_Click"></asp:Button>
            </td>
            <td>
                <asp:Button class="btn-default btn" ID="btnAddMember" runat="server" Text="Add Member" OnClick="btnAddMember_Click"></asp:Button>
            </td>
        </tr>
        </table>
    
</asp:Content>
