<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">
        <asp:Label ID="lblPageHeaderText" runat="server">
        </asp:Label></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container">
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4 alert alert-danger" id="divError" visible="false" runat="server">
                <asp:label id="lblErrorMessage" runat="server" text=""></asp:label>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4 alert alert-success" id="divSuccess" visible="false" runat="server">
                <asp:label id="lblSuccessMessage" runat="server" text=""></asp:label>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Country Name" ID="lblCountryName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgCountry" ID="txtCountryName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCountryName" runat="server" ErrorMessage="Enter proper Country Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCountryName" ValidationExpression="^[A-Za-z]+([\ A-Za-z]+)*" ValidationGroup="vgCountry"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="vgCountry" ID="rfvCountry" runat="server" ErrorMessage="Enter Country Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCountryName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Country Code" ID="lblCountryCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgCountry" ID="txtCountryCode" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="vgCountry" ID="rfvCountryCode" runat="server" ErrorMessage="Enter Country Code" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCountryCode"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">

                <asp:button id="btnAdd"  runat="server"  validationgroup="vgCountry" text="Add" cssclass="btn btn-outline-primary" OnClick="btnAdd_Click"/>
                &ensp;
                <asp:button id="btnCancel" cssclass="btn btn-outline-danger" text="Cancel" runat="server" OnClick="btnCountryList_Click" />
            </div>
        </div>
    </div>
</asp:Content>

