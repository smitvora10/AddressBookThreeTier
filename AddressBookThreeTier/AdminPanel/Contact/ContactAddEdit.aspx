<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

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
                <span class="text-danger">*</span> <asp:Label runat="server" Text=" Name" ID="lblPersonName"></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox ValidationGroup="vgContact" ID="txtPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="revPersonName" ControlToValidate="txtPersonName" CssClass="text-danger" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$" ValidationGroup="vgContact"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="vgContact" ID="rfvContact" 
                    runat="server" ErrorMessage="Enter Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtPersonName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Address" ID="lblAddress"></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox ValidationGroup="vgContact" ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Country" ID="lblCountry"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="State" ID="lblState"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlState" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="City" ID="lblCity"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Pincode" ID="lblPincode"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ValidationGroup="vgContact" ID="txtPincode" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ErrorMessage="Enter proper Pincode" ValidationExpression="^[0-9]*" ValidationGroup="vgCity" CssClass="text-danger" ControlToValidate="txtPincode" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row mb-2">
            <div class="col-md-2 text-right">
                <span class="text-danger">*</span> <asp:Label runat="server" Text="Mobile" ID="lblMobileNo"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ValidationGroup="vgContact" ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="vgContact" ID="rfvMobileNo" runat="server" ErrorMessage="Enter Mobile Number" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtPersonName"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Enter proper data" Display="Dynamic" CssClass="text-danger" ValidationExpression="[0-9]{10}" ControlToValidate="txtMobileNo"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Gender" ID="lblGender"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                    <asp:ListItem Value="0">Select Gender</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Email" ID="lblEmail"></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox ValidationGroup="vgContact" ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter proper Email" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Birth Date" ID="lblBirthDate"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ValidationGroup="vgContact" type="date" placeholder="DD-MM-YYYY" ID="txtBirthDate" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:CompareValidator runat="server" CssClass="text-danger" ControlToValidate="txtBirthDate" ValidationGroup="vgContact" Display="Dynamic" Operator="DataTypeCheck" Type="Date" ErrorMessage="Enter Proper Birth Date"></asp:CompareValidator>
            </div>
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Blood Group" ID="lblBloodGroup"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlBloodGroup" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2 text-right">
                 <asp:Label runat="server" Text="Profession" ID="lblProfession"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtProfession" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="Enter Proper Profession" CssClass="text-danger" Display="Dynamic" ValidationGroup="vgContact" ControlToValidate="txtProfession" ValidationExpression="^[a-zA-Z]+[a-zA-Z]*"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-2 text-right">
                <span class="text-danger">*</span> <asp:Label runat="server" Text="Contact Category" ID="lblContactCategory"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlCategory" ValidationGroup="vgContact" CssClass="form-control" runat="server" ControlToValidate="ddlCddlCategory">
                </asp:DropDownList>
                <asp:CompareValidator ValidationGroup="vgContact" ID="cvContactCategory" runat="server" ErrorMessage="Choose Category" Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlCategory" Font-Underline="False" Operator="NotEqual" ValueToCompare="-1" EnableViewState="True"></asp:CompareValidator>
            </div>
        </div>

        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">
                <asp:button id="btnAdd"  runat="server"  validationgroup="vgCity" text="Add" OnClick="btnAdd_Click" cssclass="btn btn-outline-primary"/>
                &ensp;
                <asp:button id="btnCancel" OnClick="btnContactList_Click" cssclass="btn btn-outline-danger" text="Cancel" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

