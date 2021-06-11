using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["StateID"] != null)
            {
                lblPageHeaderText.Text = "State Edit";
                btnAdd.Text = "Edit";
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {
                lblPageHeaderText.Text = "State Add";
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

        if (txtStateName.Text.Trim() == "")
            strErrorMessage += " - Enter State Name<br />";

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "- Select State<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        StateENT entState = new StateENT();

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (ddlCountryID.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        #endregion Collect Form Data

        StateBAL balState = new StateBAL();

        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balState.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balState.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryID);
    }

    #endregion FillDropDownList

    #region Clear Controls

    private void ClearControls()
    {
        txtStateName.Text = "";
        ddlCountryID.SelectedIndex = 0;
        txtStateName.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(StateID);

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.Value.ToString();

        if (!entState.CountryID.IsNull)
            ddlCountryID.SelectedValue = entState.CountryID.Value.ToString();
    }

    #endregion FillControls

    #region Redirects Links
    protected void btnStateList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Redirects Links
}