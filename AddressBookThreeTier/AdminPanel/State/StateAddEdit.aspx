<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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
                 <asp:Label runat="server" Text="State Name" ID="lblStateName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ValidationGroup="vgState" ID="txtStateName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revStateName" runat="server" ErrorMessage="Enter proper State Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtStateName" ValidationExpression="^[A-Za-z]+([\ A-Za-z]+)*" ValidationGroup="vgState"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="vgState" ID="rfvState" runat="server" ErrorMessage="Enter State Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtStateName"></asp:RequiredFieldValidator>
            </div>
        </div>
        
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Country Name" ID="lblCountryName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCountryID" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:CompareValidator ID="cvCountryID" runat="server" ErrorMessage="Select Country" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlCountryID" ValueToCompare="-1" Operator="NotEqual" ValidationGroup="vgState"></asp:CompareValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">

                <asp:button id="btnAdd"  runat="server"  validationgroup="vgState" text="Add" cssclass="btn btn-outline-primary" OnClick="btnAdd_Click"/>
                &ensp;
                <asp:button id="btnCancel" cssclass="btn btn-outline-danger" OnClick="btnStateList_Click" text="Cancel" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

