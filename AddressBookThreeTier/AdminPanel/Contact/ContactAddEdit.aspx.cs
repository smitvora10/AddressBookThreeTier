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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactID"] != null)
            {
                lblPageHeaderText.Text = "Contact Edit";
                btnAdd.Text = "Edit";
                FillDropDownList();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
            else
            {
                lblPageHeaderText.Text = "Contact Add";
                btnAdd.Text = "Add";

                CommonFillMethods.FillDropDownListCountry(ddlCountry);
                CommonFillMethods.FillDropDownListBloodGroup(ddlBloodGroup);
                CommonFillMethods.FillDropDownListContactCategory(ddlCategory);
            }
        }
    }
    #endregion Load Event

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtPersonName.Text == String.Empty)
        {
            strErrorMessage += "Enter Proper Name" + "<br />";
        }
        if (txtMobileNo.Text == String.Empty)
        {
            strErrorMessage += "Enter Proper Number" + "<br />";
        }
        if (ddlCategory.SelectedIndex == 0)
        {
            strErrorMessage += "Choose Proper Category";
        }

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        ContactENT entContact = new ContactENT();

        if (txtPersonName.Text != String.Empty)
        {
            entContact.PersonName = txtPersonName.Text;
        }
        if (txtAddress.Text != String.Empty)
        {
            entContact.Address = txtAddress.Text;
        }
        if (txtPincode.Text != String.Empty)
        {
            entContact.Pincode = txtPincode.Text;
        }
        if (ddlCity.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString().Trim());
        }
        if (ddlState.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString().Trim());
        }
        if (ddlCountry.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountry.SelectedValue.ToString().Trim());
        }
        if (txtMobileNo.Text != String.Empty)
        {
            entContact.MobileNo = txtMobileNo.Text;
        }
        if (ddlGender.SelectedIndex > 0)
        {
            entContact.Gender = ddlGender.SelectedValue.ToString().Trim();
        }
        if (txtEmail.Text != String.Empty)
        {
            entContact.Email = txtEmail.Text;
        }
        if (txtBirthDate.Text != String.Empty)
        {
            entContact.BirthDate = txtBirthDate.Text;
        }
        if (ddlBloodGroup.SelectedIndex > 0)
        {
            entContact.BloodGroupID = Convert.ToInt32(ddlBloodGroup.SelectedValue.ToString().Trim());
        }
        if (txtProfession.Text != String.Empty)
        {
            entContact.Profession = txtProfession.Text.ToString().Trim();
        }
        if (ddlCategory.SelectedIndex > 0)
        {
            entContact.ContactCategoryID = Convert.ToInt32(ddlCategory.SelectedValue.ToString().Trim());
        }

        #endregion Collect Form Data

        ContactBAL balContact = new ContactBAL();

        if (Request.QueryString["ContactID"] == null)
        {
            if (balContact.Insert(entContact))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balContact.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
            if (balContact.Update(entContact))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balContact.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Add

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlState);
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
        CommonFillMethods.FillDropDownListCity(ddlCity);
        CommonFillMethods.FillDropDownListBloodGroup(ddlBloodGroup);
        CommonFillMethods.FillDropDownListContactCategory(ddlCategory);
    }

    #endregion FillDropDownList

    #region Clear Controls

    private void ClearControls()
    {
        lblSuccessMessage.Text = "Added SuccessFully";
        txtPersonName.Text = "";
        txtAddress.Text = "";
        txtPincode.Text = "";
        ddlBloodGroup.SelectedIndex = 0;
        ddlCategory.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
        ddlGender.SelectedIndex = 0;
        txtProfession.Text = "";
        ddlState.SelectedIndex = 0;
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtMobileNo.Text = "";
        txtPersonName.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);

        if (!entContact.PersonName.IsNull)
        {
            txtPersonName.Text = entContact.PersonName.ToString().Trim();
        }
        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.ToString().Trim();
        }
        if (!entContact.Pincode.IsNull)
        {
            txtPincode.Text = entContact.Pincode.Value.ToString();
        }
        if (!entContact.MobileNo.IsNull)
        {
            txtMobileNo.Text = entContact.MobileNo.ToString().Trim();
        }
        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.ToString().Trim();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthDate.Text = entContact.BirthDate.ToString().Trim();
        }
        if (!entContact.StateID.IsNull)
        {
            ddlState.SelectedValue = entContact.StateID.ToString().Trim();
        }
        if (!entContact.CountryID.IsNull)
        {
            ddlCountry.SelectedValue = entContact.CountryID.ToString().Trim();
        }
        if (!entContact.CityID.IsNull)
        {
            ddlCity.SelectedValue = entContact.CityID.ToString().Trim();
        }
        if (!entContact.Gender.IsNull)
        {
            ddlGender.SelectedValue = entContact.Gender.ToString().Trim();
        }
        if (!entContact.BloodGroupID.IsNull)
        {
            ddlBloodGroup.SelectedValue = entContact.BloodGroupID.ToString().Trim();
        }
        if (!entContact.Profession.IsNull)
        {
            txtProfession.Text = entContact.Pincode.ToString().Trim();
        }
        if (!entContact.ContactCategoryID.IsNull)
        {
            ddlCategory.SelectedValue = entContact.ContactCategoryID.ToString().Trim();
        }
    }

    #endregion FillControls

    #region Redirects Links
    protected void btnContactList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion Redirects Links

    #region Cascading DropDownLists

    #region State By CountryID
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlState, "State");
            CommonFillMethods.FillEmptyDropDownList(ddlCity, "City");
        }
    }
    #endregion State By CountryID

    #region City By StateID
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlCity, "City");
        }
    }
    #endregion City By StateID

    #endregion Cascading DropDownLists
}