using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Fill State DrpoDownList
        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill State DrpoDownList

        #region Fill City DrpoDownList
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill City DrpoDownList

        #region Fill Country DrpoDownList
        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropDownList();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        #endregion Fill Country DrpoDownList

        #region Fill ContactCategory DrpoDownList
        public static void FillDropDownListContactCategory(DropDownList ddl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectForDropDownList();
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
        }
        #endregion Fill ContactCategory DrpoDownList

        #region Fill BloodGroup DrpoDownList
        public static void FillDropDownListBloodGroup(DropDownList ddl)
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            ddl.DataSource = balBloodGroup.SelectForDropDownList();
            ddl.DataValueField = "BloodGroupID";
            ddl.DataTextField = "BloodGroupName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select BloodGroup", "-1"));
        }
        #endregion Fill BloodGroup DrpoDownList

        #region Fill State DropDownList By CountryID
        public static void FillDropDownListStateByCountryID(DropDownList ddl, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownListByCountryID(CountryID);
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill State DropDownList By CountryID

        #region Fill City DropDownList By StateID
        public static void FillDropDownListCityByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownListByStateID(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill City DropDownList By StateID

        #region Fill Empty DropDownList
        public static void FillEmptyDropDownList(DropDownList ddl, String TableName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select " + TableName, "-1"));
        }
        #endregion Fill Empty DropDownList
    }
}