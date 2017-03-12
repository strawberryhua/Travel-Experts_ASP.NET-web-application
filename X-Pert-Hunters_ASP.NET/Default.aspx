<%--Made by Almerick and Hua--%>

<%@ Page Title="TravelExperts-Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="X_Pert_Hunters_Web_Application.WebForm4" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="w3-content" style="max-width: 1200px">
        <br />
        <br />
        <br />
        <img class="mySlides" src="images/Asian.jpg" style="width: 100%; height: 450px" />
        <img class="mySlides" src="images/caribbean6.jpg" style="width: 100%; height: 450px" />
        <img class="mySlides" src="images/Greece.jpg" style="width: 100%; height: 450px" />
        <img class="mySlides" src="images/polynesia3.jpg" style="width: 100%; height: 450px" />

        <div class="w3-row-padding w3-section">
            <div class="w3-col s3">
                <img class="demo w3-opacity w3-hover-opacity-off" src="images/Asian.jpg" style="width: 100%; height: 80px;" onclick="currentDiv(1)" />
            </div>
            <div class="w3-col s3">
                <img class="demo w3-opacity w3-hover-opacity-off" src="images/caribbean6.jpg" style="width: 100%; height: 80px;" onclick="currentDiv(2)" />
            </div>
            <div class="w3-col s3">
                <img class="demo w3-opacity w3-hover-opacity-off" src="images/Greece.jpg" style="width: 100%; height: 80px;" onclick="currentDiv(3)" />
            </div>
            <div class="w3-col s3">
                <img class="demo w3-opacity w3-hover-opacity-off" src="images/polynesia3.jpg" style="width: 100%; height: 80px;" onclick="currentDiv(4)" />
            </div>
        </div>
    </div>
    
    <article>
        <h2>Packages</h2>
        <div class="w3-row-padding w3-margin-top">
          <div class="w3-third">
            <div class="w3-card-2">
              <img src="images/japan.jpg" style="width:100%;height:250px;" />
              <div class="w3-container">
                <h5>Asian Expedition</h5>
                <h5>Airfaire, Hotel and Eco Tour</h5>
              </div>
            </div>
          </div>

          <div class="w3-third">
            <div class="w3-card-2">
              <img src="images/polynesia.jpg" style="width:100%; height:250px;" />
              <div class="w3-container">
                <h5>Polynesian Paradise</h5>
                <h5>8 Day All Inclusive Hawaiian Vacation</h5>
              </div>
            </div>
          </div>
           <div class="w3-third">
            <div class="w3-card-2">
              <img src="images/europe.jpg" style="width:100%;height:250px; " />
              <div class="w3-container">
                <h5>European Vacation</h5>
                <h5>Euro Tour with Rail Pass and Travel Insurance</h5>
              </div>
            </div>
          </div>
        </div>
    </article>

    <script>
        var slideIndex = 1;
        showDivs(slideIndex);

        function plusDivs(n) {
            showDivs(slideIndex += n);
        }

        function currentDiv(n) {
            showDivs(slideIndex = n);
        }

        function showDivs(n) {
            var i;
            var x = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("demo");
            if (n > x.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = x.length }
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" w3-opacity-off", "");
            }
            x[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " w3-opacity-off";
        }
    </script>

</asp:Content>

