using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if (dtState != null && dtState.Rows.Count > 0)
        {
            gvStateList.DataSource = dtState;
            gvStateList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            StateBAL balState = new StateBAL();

            if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balState.Message;
            }
        }

    }
    #endregion Delete Row Command
}