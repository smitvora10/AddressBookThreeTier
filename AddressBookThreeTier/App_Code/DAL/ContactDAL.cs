using AddressBook;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for ContactDAL
/// </summary>
/// 

namespace AddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
    {
        #region Constructor
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local variables

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

        #endregion Local variables

        #region Insert Operation

        public Boolean Insert(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_Insert";
                        //SqlParameter outputStateID = objCmd.Parameters.Add("@StateID", SqlDbType.Int);
                        //outputStateID.Direction = ParameterDirection.Output;

                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@PersonName", SqlDbType.VarChar).Value = entContact.PersonName;
                        objCmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.AddWithValue("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.AddWithValue("@Pincode", SqlDbType.VarChar).Value = entContact.Pincode;
                        objCmd.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = entContact.MobileNo;
                        objCmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = entContact.Gender;
                        objCmd.Parameters.AddWithValue("@BirthDate", SqlDbType.DateTime).Value = entContact.BirthDate;
                        objCmd.Parameters.AddWithValue("@BloodGroupID", SqlDbType.Int).Value = entContact.BloodGroupID;
                        objCmd.Parameters.AddWithValue("@Profession", SqlDbType.VarChar).Value = entContact.Profession;
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;


                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        //entState.StateID = (SqlInt32)outputStateID.Value;

                        entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdatebyPK";
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@PersonName", entContact.PersonName);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@Pincode", entContact.Pincode);
                        objCmd.Parameters.AddWithValue("@MobileNo", entContact.MobileNo);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Gender", entContact.Gender);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@BloodGroupID", entContact.BloodGroupID);
                        objCmd.Parameters.AddWithValue("@Profession", entContact.Profession);
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);


                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Delete Operation

        #region Select Operation

        #region Select City DropDown By StateID

        public DataTable SelectForDropDownListByStateID(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectForDropDownListByStateID";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Select City DropDown By StateID

        #region Select State DropDown List By CountryID
        public DataTable SelectForDropDownListByCountryID(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectForDropDownListByCountryID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select State DropDown List By CountryID

        #region Select All Operation
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select All Operation

        

        #region Select For Dropdownlist Operation
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }

        #endregion Select For Dropdownlist Operation

        #region Select By PK Operation
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                {
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);
                                }
                                if (!objSDR["PersonName"].Equals(DBNull.Value))
                                {
                                    entContact.PersonName = Convert.ToString(objSDR["PersonName"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entContact.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["Pincode"].Equals(DBNull.Value))
                                {
                                    entContact.Pincode = Convert.ToString(objSDR["Pincode"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entContact.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entContact.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                {
                                    entContact.Gender = Convert.ToString(objSDR["Gender"]);
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entContact.BirthDate = objSDR["BirthDate"].ToString().Trim();
                                }
                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                {
                                    entContact.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);
                                }
                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                {
                                    entContact.Profession = Convert.ToString(objSDR["Profession"]);
                                }
                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                {
                                    entContact.Gender = Convert.ToString(objSDR["Gender"]);
                                }
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                {
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                }

                            }
                            return entContact;
                        }

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select By PK Operation




        #endregion Select Operation
    }
}

