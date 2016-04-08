<%@ Page Title="بیمارستان" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Hospital_asp.Forms.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="col-lg-8 main-body col-lg-offset-1 pull-left">
       
        <div class="bs-example  col-lg-10 col-lg-offset-1" data-example-id="simple-carousel">
            <div class="carousel slide row" id="mycarousel" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#mycarousel" id="0" data-slide-to="0" style="border:1px solid #808080;" class=""> </li>
                    <li data-target="#mycarousel"  id="1"  data-slide-to="1" style="border:1px solid #808080;" class=""></li>
                    <li data-target="#mycarousel"  id="2" data-slide-to="2" style="border:1px solid #808080;" class=""></li>
                    <li data-target="#mycarousel"  id="3"  data-slide-to="3" style="border:1px solid #808080;" class=""></li>
                    <li data-target="#mycarousel"  id="4" data-slide-to="4" style="border:1px solid #808080;" class="active"></li>
                </ol>
                <section class="carousel-inner  effect7" >
                    <div class="item one" >
                        <img src="../Image/Danesh.jpg" width="100%" />
                    </div>
                    <div class="item two">
                        <img src="../Image/EmanPNG.jpg" width="100%"/>
                    </div>
                    <div class="item three">
                        <img src="../Image/Honar.jpg" width="100%"/>
                    </div>
                     <div class="item Four">
                        <img src="../Image/Sarbolandi.jpg" width="100%"/>
                    </div>
                    <div class="active item Five">
                        <img src="../Image/Vatan.jpg" width="100%"/>
                    </div>
                </section>
                <a class="left carousel-control" href="#mycarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#mycarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

    </div>
</asp:Content>
