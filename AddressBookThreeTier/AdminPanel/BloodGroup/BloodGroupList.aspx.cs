using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_BloodGroup_BloodGroupList : System.Web.UI.Page
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
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        DataTable dtBloodGroup = new DataTable();

        dtBloodGroup = balBloodGroup.SelectAll();

        if (dtBloodGroup != null && dtBloodGroup.Rows.Count > 0)
        {
            gvBloodGroupList.DataSource = dtBloodGroup;
            gvBloodGroupList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvBloodGroupList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();

            if (balBloodGroup.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;
            }
        }

    }
    #endregion Delete Row Command

}