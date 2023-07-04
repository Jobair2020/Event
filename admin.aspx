<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Event.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        //});
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center fw-bold text-uppercase">Wellcome Admin</h1>
    <br />
    <br />
    <br />
    

    
    <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Booking Requests</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eventConnectionString %>" SelectCommand="SELECT * FROM [user_booking_table]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="user_name" HeaderText="User Name" SortExpression="user_name" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                                        <asp:BoundField DataField="date" HeaderText="Event Date" SortExpression="date" />
                                        <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
                                        <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

    <br />
    <br />
    <br />

    <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Contact Information</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eventConnectionString2 %>" ProviderName="<%$ ConnectionStrings:eventConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [contact_table]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="subject" HeaderText="Subject" SortExpression="subject" />
                                        <asp:BoundField DataField="message" HeaderText="Message" SortExpression="message" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
    
    <br />
    <br />
    <br />
</asp:Content>
