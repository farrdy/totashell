﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="TotalDealer_2008.User.Edit" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/styles/Common.css" />
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
            <li class=""><a href="#">User</a></li>
            <li class="active"><a href="#">Update User</a></li>
            <div style="float: right">
                <li style="text-align: right">Logged in user: John Doe</li>
            </div>


        </ol>
    </div>
    <div class="container-fluid">

        <h2 class="page-heading-large">Update User</h2>
        <p>Please select user in order to update user profile</p>
        <div data-widget-group="group1">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-total-red" data-widget='{"draggable": "false"}'>
                        <div class="panel-heading">
                            <h2>User Update Form</h2>
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
                                    <asp:DropDownList ID="dropdownUserType" runat="server" AutoPostBack="true"
                                        EnableViewState="true" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtEmail" class="col-sm-2 control-label">Email</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtUserID" class="col-sm-2 control-label">Outlet / Employee No.</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtUserID" runat="server" ReadOnly="True" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtName" class="col-sm-2 control-label">Service Station / Employee Name</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">

                                <label for="dropdownSalesArea" class="col-sm-2 control-label">Sales Area</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="dropdownSalesArea" runat="server" AutoPostBack="False" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="dropdownRegion" class="col-sm-2 control-label">Region</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="dropdownRegion" runat="server" AutoPostBack="False" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="chkBoutique" class="col-sm-2 control-label">La Boutique</label>
                                <div class="col-sm-8">
                                    <asp:CheckBox ID="chkBoutique" runat="server" />
                                </div>
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
                <asp:Button class="btn-primary btn" ID="btnOk" runat="server" Text="Ok" 
                    OnClick="btnOk_Click"></asp:Button>
                <asp:Button class="btn-default btn" ID="btnCancel" runat="server" Text="Cancel" 
                    OnClick="btnCancel_Click"></asp:Button>
                <asp:Label ID="lblError" runat="server" CssClass="error_msg"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
