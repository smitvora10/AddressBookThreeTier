<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
      <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h1>Country List</h1>
            </div>
        </div>
        <br />
        <div class="text-right">
            <asp:HyperLink runat="server" ID="hlAddNewCountry" Text="Add New" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-info btn-sm"></asp:HyperLink>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCountryList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="gvCountryList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Code" />

                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:LinkButton ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord"  CommandArgument='<%# Eval("CountryID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

