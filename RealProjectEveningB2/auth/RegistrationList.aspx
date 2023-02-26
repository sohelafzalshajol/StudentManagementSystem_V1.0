<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="RealProjectEveningB2.auth.RegistrationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <%--<asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="Student Registration Info"></asp:Label>--%>
        <h1 class="h3 mb-0 text-gray-800">User Registration Info</h1>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
    </div>

    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-md-5">
                    <label class="form-label">Religion: </label>
                    <asp:DropDownList ID="ddlReligionId" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-5">
                    <label class="form-label">Gender: </label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select one--</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2" style="margin-top: 8px;">
                    <asp:Button ID="btnSearch" CssClass="btn btn-success mt-4" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <div class="card-header bg-gradient-primary text-light">
            User Registration Info
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12" style="overflow: scroll;">
                    <asp:GridView ID="gvRegList" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvRegList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" />
                            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                            <asp:BoundField DataField="ReligionName" HeaderText="ReligionName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="imgUserImage" runat="server" ImageUrl='<%# (string)BaseUrl((string)Eval("UserImage"))%>' Height="50px" />
                                    <asp:Image ID="imgUserImage1" runat="server" ImageUrl='<%# Eval("UserImage1")%>' Height="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("UserId") %>' />
                                    <div runat="server" class="text-center">
                                        <asp:ImageButton ID="imgBtnUser" runat="server" CommandName="approve" CommandArgument='<%#Container.DataItemIndex %>' Height="25px" ImageUrl="~/Assets/img/edit-icon-png-3602.png" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>


                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
