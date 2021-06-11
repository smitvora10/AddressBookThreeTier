using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountryList.DataSource = dtCountry;
            gvCountryList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            CountryBAL balCountry = new CountryBAL();

            if (balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balCountry.Message;
            }
        }

    }
    #endregion Delete Row Command
}