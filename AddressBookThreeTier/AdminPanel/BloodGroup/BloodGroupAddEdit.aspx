<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BloodGroupAddEdit.aspx.cs" Inherits="AdminPanel_BloodGroup_BloodGroupAddEdit" %>

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
            <div class="col-md-2 text-right  align-middle">
                <asp:label runat="server" text="Blood Group Name" id="lblBloodGroupName"></asp:label>
            </div>
            <div class="col-md-4">
                <asp:textbox validationgroup="BloodGroup" id="txtBloodGroupName" cssclass="form-control" runat="server"></asp:textbox>
                <asp:requiredfieldvalidator validationgroup="vgBloodGroup" id="rfvBloodGroup" runat="server" errormessage="Enter BloodGroup Name" cssclass="text-danger" display="Dynamic" controltovalidate="txtBloodGroupName"></asp:requiredfieldvalidator>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-2 col-md-4">

                <asp:button id="btnAdd"  runat="server"  validationgroup="vgBloodGroup" text="Add" cssclass="btn btn-outline-primary" OnClick="btnAdd_Click"/>
                &ensp;
                <asp:button id="btnCancel" cssclass="btn btn-outline-danger" OnClick="btnBloodGroupList_Click" text="Cancel" runat="server" />
            </div>
        </div>
    </div>
     

</asp:Content>

