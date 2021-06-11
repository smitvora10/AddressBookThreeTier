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


public partial class AdminPanel_BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BloodGroupID"] != null)
            {
                lblPageHeaderText.Text = "Blood Group Edit";
                btnAdd.Text = "Edit";
                FillControls(Convert.ToInt32(Request.QueryString["BloodGroupID"]));
            }
            else
            {
                lblPageHeaderText.Text = "Blood Group Add";
                btnAdd.Text = "Add";
            }
        }
    }
    #endregion Load Event

    #region Clear Controls

    private void ClearControls()
    {
        txtBloodGroupName.Text = "";
        txtBloodGroupName.Focus();
    }

    #endregion Clear Controls

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtBloodGroupName.Text.Trim() == "")
            strErrorMessage += " - Enter BloodGroup Name<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        BloodGroupENT entBloodGroup = new BloodGroupENT();

        if (txtBloodGroupName.Text.Trim() != "")
            entBloodGroup.BloodGroupName = txtBloodGroupName.Text.Trim();

        #endregion Collect Form Data

        BloodGroupBAL balBloodGroup = new BloodGroupBAL();

        if (Request.QueryString["BloodGroupID"] == null)
        {
            if (balBloodGroup.Insert(entBloodGroup))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entBloodGroup.BloodGroupID = Convert.ToInt32(Request.QueryString["BloodGroupID"]);
            if (balBloodGroup.Update(entBloodGroup))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region FillControls

    private void FillControls(SqlInt32 BloodGroupID)
    {
        BloodGroupENT entBloodGroup = new BloodGroupENT();
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();

        entBloodGroup = balBloodGroup.SelectByPK(BloodGroupID);

        if (!entBloodGroup.BloodGroupName.IsNull)
            txtBloodGroupName.Text = entBloodGroup.BloodGroupName.Value.ToString();
    }

    #endregion FillControls

    #region Redirects Links
    protected void btnBloodGroupList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
    }
    #endregion Redirects Links
}