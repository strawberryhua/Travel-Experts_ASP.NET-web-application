<%--Made by Almerick and Hua--%>

<%@ Page Title="TravelExperts-ModifyCustInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyCustInfo.aspx.cs" Inherits="X_Pert_Hunters_Web_Application.WebForm3" %>
<%--Hua designed the page and added validation--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><br />
    <div class="form-horizontal">
        <p>
            <asp:Label ID="lblSuccMessage" runat="server" CssClass="auto-style1"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblError" runat="server" CssClass="auto-style2"></asp:Label>
        </p>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCustomerId" CssClass="col-md-2 control-label">CustomerId</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtCustomerId" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="The 'First Name' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="The 'Last Name' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="The 'Address' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col-md-2 control-label">City</asp:Label>
           <%-- <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control">
                    <asp:ListItem>Other</asp:ListItem>
                    <asp:ListItem>Airdir</asp:ListItem>
                    <asp:ListItem>Brooks</asp:ListItem>
                    <asp:ListItem>Calgary</asp:ListItem>
                    <asp:ListItem>Camrose</asp:ListItem>
                    <asp:ListItem>Chestermere</asp:ListItem>
                    <asp:ListItem>Cold Lake</asp:ListItem>
                    <asp:ListItem>Edmonton</asp:ListItem>
                    <asp:ListItem>Red Deer</asp:ListItem>
                    <asp:ListItem>Lacombe</asp:ListItem>
                    <asp:ListItem>Victoria</asp:ListItem>
                    <asp:ListItem>Winnipeg</asp:ListItem>
                    <asp:ListItem>Fredericton</asp:ListItem>
                    <asp:ListItem>St.Join&#39;s</asp:ListItem>
                    <asp:ListItem>Halifax</asp:ListItem>
                    <asp:ListItem>Toronto</asp:ListItem>
                    <asp:ListItem>Charlottetown</asp:ListItem>
                    <asp:ListItem>Quebec City</asp:ListItem>
                    <asp:ListItem>Regina</asp:ListItem>
                    <asp:ListItem>YellowKnife</asp:ListItem>
                    <asp:ListItem>Iqaluit</asp:ListItem>
                    <asp:ListItem>Whitehorse</asp:ListItem>
                </asp:DropDownList>
                
            </div>--%>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity"
                    CssClass="text-danger" ErrorMessage="The 'City' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtProv" CssClass="col-md-2 control-label">Province</asp:Label>
            <%--<div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlProv" CssClass="form-control">
                    <asp:ListItem>Other</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>ON</asp:ListItem>
                    <asp:ListItem>QC</asp:ListItem>
                    <asp:ListItem>NS</asp:ListItem>
                    <asp:ListItem>NB</asp:ListItem>
                    <asp:ListItem>MB</asp:ListItem>
                    <asp:ListItem>BC</asp:ListItem>
                    <asp:ListItem>PE</asp:ListItem>
                    <asp:ListItem>SK</asp:ListItem>
                    <asp:ListItem>NL</asp:ListItem>
                </asp:DropDownList>

              

            </div>--%>
             <div class="col-md-3">
                
                <asp:TextBox runat="server" ID="txtProv" CssClass="form-control" />
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProv"
                    CssClass="text-danger" ErrorMessage="The 'Province' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPostal" CssClass="col-md-2 control-label">Postal</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtPostal" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPostal"
                    CssClass="text-danger" ErrorMessage="The 'Postal' field is required." />
            </div>
            <div class="col-md-4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostal" ErrorMessage="Please follow the postal code format:X3X 4Y1" ValidationExpression="[A-Z]\d[A-Z] ?\d[A-Z]\d" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCountry" CssClass="col-md-2 control-label">Country</asp:Label>
            <div class="col-md-3" style="left: 0px; top: 0px; height: 54px">
                <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control" Enabled="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCountry"
                    CssClass="text-danger" ErrorMessage="The 'Country' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtHomePhone" CssClass="col-md-2 control-label">Home Phone</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHomePhone"
                    CssClass="text-danger" ErrorMessage="The 'Home Phone' field is required." />
            </div>
            <div class="col-md-4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="Please follow the phone format:8888888888" ValidationExpression="[0-9]{3}[0-9]{7}" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBusPhone" CssClass="col-md-2 control-label">Business Phone</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtBusPhone" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBusPhone" ErrorMessage="Please follow the phone format:8888888888" ValidationExpression="[0-9]{3}[0-9]{7}" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-3" style="left: 0px; top: 0px; height: 56px">
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" />
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAgent" CssClass="col-md-2 control-label">Agent</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtAgent" CssClass="form-control" Enabled="False" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">User Name</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" Enabled="False" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                    CssClass="text-danger" ErrorMessage="The 'User Name' field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
            <div class="col-md-4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter at least 4 characters" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,}$"  CssClass="text-danger" ControlToValidate="txtPassword" ></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                <br />
                <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        <br />
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>

