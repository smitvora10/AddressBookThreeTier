<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" Runat="Server">
         <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">
        <asp:Label ID="lblPageHeaderText" runat="server">
        </asp:Label></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
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
                 <asp:Label runat="server" Text="City Name" ID="lblCityName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgCity" ID="txtCityName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCityName" runat="server" ErrorMessage="Enter proper City Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCityName" ValidationExpression="^[A-Za-z]+([\ A-Za-z]+)*" ValidationGroup="vgCity"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="vgCity" ID="rfvCity" runat="server" ErrorMessage="Enter City Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCityName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Pincode" ID="lblPincode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgCity" ID="txtPincode" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ErrorMessage="Enter proper Pincode" ValidationExpression="^[0-9]*" ValidationGroup="vgCity" CssClass="text-danger" ControlToValidate="txtPincode" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="STD Code" ID="lblSTDCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgCity" ID="txtSTDCode" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revSTDCode" runat="server" ErrorMessage="Enter proper STDCode" ValidationExpression="^[0-9]*" ValidationGroup="vgCity" CssClass="text-danger" ControlToValidate="txtSTDCode" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="State" ID="lblState"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:CompareValidator ID="cvState" runat="server" ErrorMessage="Select State" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlStateID" ValueToCompare="-1" Operator="NotEqual" ValidationGroup="vgCity"></asp:CompareValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">

                <asp:button id="btnAdd"  runat="server"  validationgroup="vgCity" text="Add" cssclass="btn btn-outline-primary" OnClick="btnAdd_Click"/>
                &ensp;
                <asp:button id="btnCancel" OnClick="btnCityList_Click" cssclass="btn btn-outline-danger" text="Cancel" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

