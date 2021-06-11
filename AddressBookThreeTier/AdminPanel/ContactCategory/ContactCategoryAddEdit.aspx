<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

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
                 <asp:Label runat="server" Text="Contact Category Name" ID="lblContactCategoryName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgContactCategory" ID="txtContactCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revContactCategoryName" runat="server" ErrorMessage="Enter proper ContactCategory Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtContactCategoryName" ValidationExpression="^[A-Za-z]+([\ A-Za-z]+)*" ValidationGroup="vgContactCategory"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="vgContactCategory" ID="rfvContactCategory" runat="server" ErrorMessage="Enter ContactCategory Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtContactCategoryName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">

                <asp:button id="btnAdd"  runat="server"  validationgroup="vgContactCategory" text="Add" cssclass="btn btn-outline-primary" OnClick="btnAdd_Click"/>
                &ensp;
                <asp:button id="btnCancel" cssclass="btn btn-outline-danger" text="Cancel" runat="server" OnClick="btnContactCategoryList_Click" />
            </div>
        </div>
    </div>
</asp:Content>

