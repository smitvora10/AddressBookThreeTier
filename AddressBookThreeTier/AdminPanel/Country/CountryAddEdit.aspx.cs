using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblPageHeaderText.Text = "Country Edit";
                btnAdd.Text = "Edit";
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {
                lblPageHeaderText.Text = "Country Add";
                btnAdd.Text = "Add";
            }
        }
    }
    #endregion Load Event

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
            strErrorMessage += " - Enter Country Name<br />";

        if (txtCountryCode.Text.Trim() == "")
            strErrorMessage += " - Enter Country Code<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = txtCountryCode.Text.Trim();

        #endregion Collect Form Data

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balCountry.Update(entCountry))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region Clear Controls

    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();

    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.Value.ToString();

        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();

    }

    #endregion FillControls

    #region Redirects Links
    protected void btnCountryList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Redirects Links
}