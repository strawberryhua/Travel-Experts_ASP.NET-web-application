<%@ Page Title="Travelexperts-Packages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="X_Pert_Hunters_Web_Application.WebForm5" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CellPadding="4" CssClass="table table-responsive" ForeColor="Black" GridLines="Horizontal" EmptyDataText="No Products Purchased!" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <EmptyDataRowStyle BackColor="000066" ForeColor="White" Font-Size="X-Large" />
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="BasePrice" HeaderText="BasePrice" SortExpression="BasePrice" DataFormatString="{0:c}" />
            <asp:BoundField DataField="BookingNo" HeaderText="BookingNo" SortExpression="BookingNo" />
            <asp:BoundField DataField="BookDate" HeaderText="BookDate" SortExpression="BookDate" DataFormatString="{0:d}" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProducts" TypeName="X_Pert_Hunters_ASP.NET.App_Code.ProductsDB">
        <SelectParameters>
            <asp:SessionParameter Name="custUserid" SessionField="user" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    Total:<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" ShowHeader="False">
        <Columns>
            <asp:BoundField DataField="BasePrice" HeaderText="BasePrice" DataFormatString="{0:c}" />
        </Columns>
    </asp:GridView>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="TotalPrice" TypeName="X_Pert_Hunters_ASP.NET.App_Code.ProductsDB">
            <SelectParameters>
                <asp:SessionParameter Name="custUserId" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>
