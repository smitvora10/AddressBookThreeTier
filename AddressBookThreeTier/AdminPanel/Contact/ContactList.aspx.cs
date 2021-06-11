using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Data
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Data

    #region Fill Grid View
    private void FillGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact != null && dtContact.Rows.Count > 0)
        {
            gvContactList.DataSource = dtContact;
            gvContactList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            ContactBAL balContact = new ContactBAL();

            if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balContact.Message;
            }
        }

    }
    #endregion Delete Row Command
}