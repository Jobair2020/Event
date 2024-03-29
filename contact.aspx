﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Event.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="w3ls-banner-1">
    </div>



</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3ls_address_mail_footer_grids">
        <div class="container">
            <h2 class="heading-agileinfo">Contact<span>Events is a professionally managed Event</span></h2>
            <div class="map">
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3539.812628729253!2d153.014155!3d-27.4750921!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6b915a0835840a2f%3A0xdd5e3f5c208dc0e1!2sMelbourne+St%2C+South+Brisbane+QLD+4101%2C+Australia!5e0!3m2!1sen!2sin!4v1492257477691"></iframe>
            </div>
            <div class="col-md-6 contact-form">
                <h4 class="white-w3ls">Contact Form</h4>
                <form action="#" method="post">
                    <div class="styled-input agile-styled-input-top">
                        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                        
                        <label>Name</label>
                        <span></span>
                    </div>
                    <div class="styled-input">
                        <asp:TextBox ID="TextBox2" runat="server"  TextMode="Email"></asp:TextBox>
                        
                        <label>Email</label>
                        <span></span>
                    </div>
                    <div class="styled-input">
                        <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                        
                        <label>Subject</label>
                        <span></span>
                    </div>
                    <div class="styled-input">
                        <asp:TextBox ID="TextBox4" runat="server"  TextMode="MultiLine"></asp:TextBox>
                        
                        <label>Message</label>
                        <span></span>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="SEND" OnClick="Button1_Click" />
                    
                </form>
            </div>
            <div class="col-md-6 contactright">
                <h3>Contact Address</h3>
                <div class="w3ls_footer_grid_left">
                    <div class="wthree_footer_grid_left">
                        <i class="fa fa-map-marker" aria-hidden="true"></i>
                    </div>
                    <p>3481 Melrose Place, Beverly Hills, <span>New York City 90210.</span></p>
                </div>
                <div class="w3ls_footer_grid_left">
                    <div class="wthree_footer_grid_left">
                        <i class="fa fa-phone" aria-hidden="true"></i>
                    </div>
                    <p>+(000) 123 4565 32 <span>+(010) 123 4565 35</span></p>
                </div>
                <div class="w3ls_footer_grid_left">
                    <div class="wthree_footer_grid_left">
                        <i class="fa fa-envelope-o" aria-hidden="true"></i>
                    </div>
                    <p>
                        <a href="mailto:info@example.com">info@example1.com</a>
                        <span><a href="mailto:info@example.com">info@example2.com</a></span>
                    </p>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>


    
    <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>

    <script src="js/jquery-2.2.3.min.js"></script>

   
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    
    <script src="js/bootstrap.js"></script>
   
    <script type="text/javascript">
        $(document).ready(function () {
            

            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>




</asp:Content>
