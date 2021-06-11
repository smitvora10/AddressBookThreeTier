<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h1>City List</h1>
            </div>
        </div>
        <br />
        <div class="text-right">
            <asp:HyperLink runat="server" ID="hlAddNewCity" Text="Add New" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-info btn-sm"></asp:HyperLink>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCityList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowCommand="gvCityList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:LinkButton ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord"  CommandArgument='<%# Eval("CityID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString() %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

