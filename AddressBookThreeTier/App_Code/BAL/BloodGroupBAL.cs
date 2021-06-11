using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for BloodGroupBAL
/// </summary>

namespace AddressBook.BAL
{
    public class BloodGroupBAL
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
        public BloodGroupBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        public Boolean Insert(BloodGroupENT entBloodGroup)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

            if (dalBloodGroup.Insert(entBloodGroup))
            {
                return true;
            }

            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(BloodGroupENT entBloodGroup)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

            if (dalBloodGroup.Update(entBloodGroup))
            {
                return true;
            }

            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete  Operation

        public Boolean Delete(SqlInt32 BloodGroupID)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

            if (dalBloodGroup.Delete(BloodGroupID))
            {
                return true;
            }

            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }

        #endregion Delete  Operation

        #region Select Operation

        #region SelectALL
        public DataTable SelectAll()
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectByPK(BloodGroupID);
        }
        #endregion SelectByPK

        #endregion Select Operation

    }
}
