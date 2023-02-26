<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="RealProjectEveningB2.auth.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <%--<asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="Student Registration Info"></asp:Label>--%>
        <h1 class="h3 mb-0 text-gray-800">User Contact Info</h1>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
    </div>

    <div class="card">
        <div class="card-header bg-gradient-primary text-light">
            User Contact Info List
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12" style="overflow: scroll">
                    <asp:GridView ID="gvContactList" runat="server" CssClass="table table-bordered table-striped">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
