<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategorylist.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategorylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
        <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h1>ContactCategory List</h1>
            </div>
        </div>
        <br />
        <div class="text-right">
            <asp:HyperLink runat="server" ID="hlAddNewContactCategory" Text="Add New" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" CssClass="btn btn-info btn-sm"></asp:HyperLink>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvContactCategoryList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="gvContactCategoryList_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="<i class='fas fa-trash-alt'></i> Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="<i class='far fa-edit'></i> Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString() %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

