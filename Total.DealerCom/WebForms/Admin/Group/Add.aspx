<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="TotalDealer_2008.Group.Add" %>

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
        <p>Please input a group name to add a group</p>
        <div data-widget-group="group1">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-total-red" data-widget='{"draggable": "false"}'>
                        <div class="panel-heading">
                            <h2>Add Group Form</h2>
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
                    <asp:Button class="btn-default btn" ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click"></asp:Button>
                    <asp:Label ID="lblStatus" runat="server" CssClass="status_msg"></asp:Label>
                    <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
