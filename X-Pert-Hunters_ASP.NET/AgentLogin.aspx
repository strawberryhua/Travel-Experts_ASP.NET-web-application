<%@ Page Title="AgentLogin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentLogin.aspx.cs" Inherits="X_Pert_Hunters_ASP.NET.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: red;
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-horizontal">
        <br />
        <br />

        <h4>&nbsp;</h4>
        <h1>Agent Login</h1>
        <h4>Please sign in below.</h4>
        <p>
            <asp:Label ID="lblError" runat="server" CssClass="auto-style1"></asp:Label>
        </p>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">User Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                    CssClass="text-danger" ErrorMessage="The 'User Name' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The 'Password' field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" ID="btnLogin" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
    <p>
        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Register.aspx">Join us now!</asp:HyperLink>
    </p>
</asp:Content>
