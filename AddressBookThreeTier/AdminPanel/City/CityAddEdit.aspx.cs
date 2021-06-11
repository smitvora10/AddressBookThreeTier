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
public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblPageHeaderText.Text = "City Edit";
                btnAdd.Text = "Edit";
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
            else
            {
                lblPageHeaderText.Text = "City Add";
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

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "- Select State<br />";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += " - Enter City Name<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        CityENT entCity = new CityENT();

        if (ddlStateID.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();

        if (txtPincode.Text.Trim() != "")
            entCity.Pincode = txtPincode.Text.Trim();

        #endregion Collect Form Data

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.Update(entCity))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlStateID);
    }

    #endregion FillDropDownList

    #region Clear Controls

    private void ClearControls()
    {
        ddlStateID.SelectedIndex = 0;
        txtCityName.Text = "";
        txtPincode.Text = "";
        txtSTDCode.Text = "";

        ddlStateID.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

        if (!entCity.Pincode.IsNull)
            txtPincode.Text = entCity.Pincode.Value.ToString();

        if (!entCity.STDCode.IsNull)
            txtSTDCode.Text = entCity.STDCode.Value.ToString();

        if (!entCity.StateID.IsNull)
            ddlStateID.SelectedValue = entCity.StateID.Value.ToString();
    }

    #endregion FillControls

    #region Redirects Links
    protected void btnCityList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Redirects Links
}