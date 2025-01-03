﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="Event.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Signup</title>
    <link href="css/cdn.jsdelivr.net_npm_bootstrap@4.3.1_dist_css_bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container">
                <div class="row">
                    <div class="col-md-8 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <img width="100px" src="images/adminuser.png" />
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4>Create New Account</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Full Name</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Date of Birth</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Contact No</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Email ID</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Division</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                                <asp:ListItem Text="Select" Value="select" />
                                                <asp:ListItem Text="Dhaka" Value="Dhaka" />
                                                <asp:ListItem Text="Chittagong" Value="Chittagong" />
                                                <asp:ListItem Text="Maymanshing" Value="Maymanshing" />
                                                <asp:ListItem Text="Barisal" Value="Barisal" />
                                                <asp:ListItem Text="Khulna" Value="Khulna" />
                                                <asp:ListItem Text="Rajshahi" Value="Rajshahi" />
                                                <asp:ListItem Text="Sylhet" Value="Sylhet" />
                                                <asp:ListItem Text="Rangpur" Value="Rangpur" />

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>City</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Pincode</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <label>Full Address</label>
                                        <div class="form-group">
                                            <asp:TextBox Class="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <span class="badge badge-pill badge-info">Login Credentials</span>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>User name</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User name" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Create Password</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="password" TextMode="Password" required="required"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <div class="form-group">
                                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                        <p>Already Have an account?     <a href="signIn.aspx">Login</a></p>
                        
                        <br />
                         <a href="index.aspx"><< Back to Home</a><br />
                    </div>

                </div>
            </div>

        </div>
    </form>
</body>
</html>
