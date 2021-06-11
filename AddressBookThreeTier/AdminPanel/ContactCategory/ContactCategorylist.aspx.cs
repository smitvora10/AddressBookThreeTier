using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategorylist : System.Web.UI.Page
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
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        dtContactCategory = balContactCategory.SelectAll();

        if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
        {
            gvContactCategoryList.DataSource = dtContactCategory;
            gvContactCategoryList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

            if (balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balContactCategory.Message;
            }
        }

    }
    #endregion Delete Row Command
}