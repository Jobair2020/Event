<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="Event.events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="w3ls-banner-1">
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-md-12">
                <br />
                <br />

                <center>
                   <h2 class="heading-agileinfo">Events List<span>Events is a professionally managed </span></h2>
                </center>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row">


                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eventConnectionString %>" SelectCommand="SELECT * FROM [hall_table]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="hall_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="hall_id" HeaderText="Hall ID" ReadOnly="True" SortExpression="hall_id">


                                                <ControlStyle Font-Bold="True" />
                                                <ItemStyle Font-Bold="True" />
                                            </asp:BoundField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-md-10">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("hall_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <span>City - </span>
                                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("city") %>'></asp:Label>
                                                                        &nbsp;| <span><span>&nbsp;</span>Category - </span>
                                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("category") %>'></asp:Label>
                                                                        &nbsp;| 
                                                   <span>Type -<span>&nbsp;</span>
                                                       <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("type") %>'></asp:Label>
                                                   </span>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Venue -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("venue") %>'></asp:Label>
                                                                        &nbsp;| Booking Date -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("booking_date") %>'></asp:Label>
                                                                        &nbsp;| Seats -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("seat") %>'></asp:Label>
                                                                        &nbsp;| Status -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("status") %>'></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Price -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("price") %>'></asp:Label>
                                                                        &nbsp;| Actual Halls -
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_hall") %>'></asp:Label>
                                                                        &nbsp;| Available Halls -
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_hall") %>'></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("event_description") %>'></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:Image Height="150px" Width="100px" class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("hall_img_link") %>' />

                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />


</asp:Content>
