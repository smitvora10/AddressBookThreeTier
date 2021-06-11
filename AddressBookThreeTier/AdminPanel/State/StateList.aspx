<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
      <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h1>State List</h1>
            </div>
        </div>
        <br />
        <div class="text-right">
            <asp:HyperLink runat="server" ID="hlAddNewState" Text="Add New" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" CssClass="btn btn-info btn-sm"></asp:HyperLink>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvStateList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="gvStateList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CountryName" HeaderText="CountryName" />

                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:LinkButton ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord"  CommandArgument='<%# Eval("StateID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

