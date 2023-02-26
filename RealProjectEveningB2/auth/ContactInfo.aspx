<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="RealProjectEveningB2.auth.ContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function checkNumber(cntrlId) {
            var val = document.getElementById(cntrlId).value;
            var mainCntrl = document.getElementById(cntrlId);
            var checkDigit = /^\d*$/;
            if (checkDigit.test(val)) {
                mainCntrl.style.backgroundColor = "white";

            }
            else {
                alert("Invalid Number!!!");
                mainCntrl.value = "";
                mainCntrl.style.backgroundColor = "pink";
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <%--<asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="Student Registration Info"></asp:Label>--%>
        <h1 class="h3 mb-0 text-gray-800">User Contact Info</h1>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
    </div>

    <div class="card my-3">
        <div id="divMessage" runat="server" class="alert alert-danger mt-3 text-center">
            <asp:Label ID="lblMessage" CssClass="text-danger" runat="server" Text=""></asp:Label>
        </div>
        <div id="divMessageSuccess" runat="server" class="alert alert-success mt-3 text-center">
            <asp:Label ID="lblMessageSuccess" CssClass="text-success" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-header bg-gradient-primary text-light">
            Contact Info
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Name: </label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Contact No: </label>
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revContactNo" CssClass="text-danger" runat="server" ControlToValidate="txtContactNo" ValidationExpression="(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\d{8})$" ErrorMessage="Invalid Contact No!!!"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Email: </label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" CssClass="text-danger" runat="server" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Invalid Email Format!!!"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Social URL: </label>
                    <asp:TextBox ID="txtSocialURL" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10">
                </div>
                <div class="col-md-2 mt-3">
                    <asp:HiddenField ID="hdnEditCId" runat="server" />
                    <asp:Button CssClass="btn btn-primary form-control mt-2" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>

        <div class="card-header bg-gradient-primary text-light">
            User Contact Info List
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvContactList" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvContactList_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="Name" />
                            <asp:BoundField HeaderText="Contact No." DataField="ContactNo" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="Social" DataField="Social" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Action
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnCId" runat="server" Value='<%# Eval("CId") %>' />
                                    <div runat="server" class="text-center">
                                        <asp:ImageButton ID="imgBtnEdit" runat="server" CommandName="editC" CommandArgument="<%#Container.DataItemIndex %>" AlternateText="Edit" Height="20px" ImageUrl="~/Assets/img/edit-icon-png-3602.png" />
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
