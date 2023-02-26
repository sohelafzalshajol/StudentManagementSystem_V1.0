<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RealProjectEveningB2.login" %>

<%@ Register Src="~/ResponseMessages.ascx" TagPrefix="uc1" TagName="ResponseMessages" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <!-- Custom fonts for this template-->
    <link href="../Assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../Assets/css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Our Custom styles-->
    <link href="../Assets/css/custom-style.css" rel="stylesheet" />
    <style>
        .input-group-text, .form-control{
            border-radius: 0px !important;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid bg-gradient-success vh-100">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-4 mt-3">
                        <div class="site_logo text-center">
                            <img class="img-fluid w-50" alt="SiteLogo" src="Assets/img/logo.jpg" />
                        </div>
                        <%--<div id="divMessage" runat="server" class="alert alert-danger mt-3 text-center">
                            <asp:Label ID="lblMessage" CssClass="text-danger" runat="server" Text=""></asp:Label>
                        </div>--%>
                        <uc1:ResponseMessages runat="server" id="ucRmMsg" />
                        <div class="card mt-3">
                            <div class="card-body">
                                <div class="input-group flex-nowrap mt-1">
                                    <span class="input-group-text" id=""><i class="fas fa-user"></i></span>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="UserName" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="input-group flex-nowrap mt-4 mb-2">
                                    <span class="input-group-text" id=""><i class="fas fa-lock"></i></span>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                    <asp:CheckBox CssClass="mt-2" ID="cbRemember" runat="server" Text="&nbsp;Remember Me" />
                                <div class="input-group flex-nowrap mt-2">
                                    <span class="input-group-text" id=""><i class="fas fa-paper-plane"></i></span>
                                    <asp:Button CssClass="form-control btn btn-success" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                </div>
                                <div class="login_links mt-3">
                                    <a href="#">Forgot Password</a>
                                    <a href="auth/register.aspx" class="float-right">Register now</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap core JavaScript-->
    <script src="../Assets/vendor/jquery/jquery.min.js"></script>
    <script src="../Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../Assets/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../Assets/js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="../Assets/vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="../Assets/js/demo/chart-area-demo.js"></script>
    <script src="../Assets/js/demo/chart-pie-demo.js"></script>

</body>
    <!-- 
        Home Server: DESKTOP-5J0I5J4
        BITM Server: DESKTOP-VHHBPK5
    -->

</html>
