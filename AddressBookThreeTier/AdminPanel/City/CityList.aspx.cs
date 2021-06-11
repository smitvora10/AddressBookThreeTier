using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Data
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Data

    #region Fill Grid View
    private void FillGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll();

        if(dtCity!= null && dtCity.Rows.Count > 0)
        {
            gvCityList.DataSource = dtCity;
            gvCityList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            CityBAL balCity = new CityBAL();

            if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }

            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }

    }
    #endregion Delete Row Command

}