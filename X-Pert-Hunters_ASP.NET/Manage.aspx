<%--Made by Almerick and Hua--%>

<%@ Page Title="TravelExperts-Manage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="X_Pert_Hunters_Web_Application.WebForm6" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    </h3>
    <asp:Label ID="lblUpdate" runat="server" CssClass="auto-style1"></asp:Label>
    <div class="w3-row-padding w3-section">
        <div class="w3-col s6" style="text-align: center">
            <a runat="server" href="~/ShoppingCart.aspx">
                <img src="images/booking.jpg" style="width: 100%; height: 300px;" /><h3 class="w3-center">My Products</h3>
            </a>
        </div>
        <div class="w3-col s6" style="text-align: center">
            <a runat="server" href="~/ModifyCustInfo.aspx">
                <img src="images/myaccount.png" style="width: 100%; height: 300px;" /><h3 class="w3-center">Manage Account</h3>
            </a>
        </div>
    </div>
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        font-size: x-large;
    }
</style>
</asp:Content>

