<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/BlankMaster.Master" AutoEventWireup="true" CodeBehind="UserApproval.aspx.cs" Inherits="RealProjectEveningB2.auth.UserApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="card">
            <div class="card-header">
                <h3>User Approval</h3>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Label ID="lblUserName" runat="server" CssClass="form-label" Text="User Name"></asp:Label>
                        <asp:TextBox ID="txtUserName" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="lblFullName" runat="server" CssClass="form-label" Text="Full Name"></asp:Label>
                        <asp:TextBox ID="txtFullName" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="lblContactNo" runat="server" CssClass="form-label" Text="ContactNo"></asp:Label>
                        <asp:TextBox ID="txtContactNo" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <asp:Label ID="lblApprovedStatus" runat="server" CssClass="form-label" Text="Approved Status"></asp:Label>
                        <asp:DropDownList ID="ddlApprovedStatus" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApprovedStatus_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select...</asp:ListItem>
                            <asp:ListItem>Approved</asp:ListItem>
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Not Approved</asp:ListItem>
                            <asp:ListItem>Disabled</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-5" runat="server" id="divPassword" visible="false">
                        <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" Enabled="true" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:HiddenField ID="hdnUpdateUserId" runat="server" />
                    </div>
                    <div class="col-sm-2 pt-4">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
