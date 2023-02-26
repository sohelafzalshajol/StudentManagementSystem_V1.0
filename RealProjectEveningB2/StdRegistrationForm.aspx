<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="StdRegistrationForm.aspx.cs" Inherits="RealProjectEveningB2.StdRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Registration</h1>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-3" style="display: flex;"></div>
            <form class="col-md-6">
                <div>
                    <label for="exampleInputEmail1" class="form-label">Full Name: </label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                </div>
                <div>
                    <%--<label for="exampleInputEmail1" class="form-label"> </label>--%>
                    <label class="form-label" for="customFile">Your Image: </label>
                    <input type="file" class="custom-file" id="">
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Sex: (Select One)</label>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                        <label class="form-check-label" for="flexRadioDefault1">
                            Male
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                        <label class="form-check-label" for="flexRadioDefault2">
                            Female
                        </label>
                    </div>
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Date Of Birth: </label>
                    <input type="date" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Department: </label>
                    <select class="form-select" aria-label="Default select example">
                        <option selected>Open this select menu</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Present Address: </label>
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3">Give your present address...</textarea>
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Permanent Address: </label>
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3">Give your permanent address...</textarea>
                </div>
                <div>
                    <label for="exampleInputEmail1" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                </div>
                <div>
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <input type="password" class="form-control" id="exampleInputPassword1">
                </div>
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
            </form>
            <div class="col-md-3" style="display: flex;"></div>
        </div>
    </div>
</asp:Content>
