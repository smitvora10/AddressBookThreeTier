
using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for ContactBAL
/// </summary>

namespace AddressBook.BAL
{
    public class ContactBAL
    {
        #region Local Variable

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
            }
        }


        #endregion Local Variable

        #region Constructor
        public ContactBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Insert(entContact))
            {
                return true;
            }

            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Update(entContact))
            {
                return true;
            }

            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete  Operation

        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Delete(ContactID))
            {
                return true;
            }

            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Delete  Operation

        #region Select Operation

        #region Select State DropDown List By CountryID
        public DataTable SelectForDropDownListByCountryID(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownListByCountryID(CountryID);
        }
        #endregion Select State DropDown List By CountryID

        public DataTable SelectForDropDownListByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownListByStateID(StateID);
        }

        #region SelectALL
        public DataTable SelectAll()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }
        #endregion SelectByPK

        #endregion Select Operation

    }
}
