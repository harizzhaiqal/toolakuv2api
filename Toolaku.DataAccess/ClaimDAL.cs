using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Toolaku.Library;
using Toolaku.Models.DTO;
using Toolaku.Models.HR;
using Toolaku.Models.Pagingnation;
namespace Toolaku.DataAccess
{
    public class ClaimDAL
    {
        //-----------------------------------------GET Method------------------------------------------------------

        public static (List<PersonalClaimList>, PageInfo) GetPersonalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<PersonalClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PersonalClaimList();
                            result.ClaimId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            if (reader.GetValue(2).ToString() != "")
                            {
                                result.Status = reader.GetString(2);
                            }
                            else
                            {
                                result.Status = "";
                            }
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }


        public static PersonalClaimDetails GetPersonalClaimDetails(Adapter ad, int claimId)
        {
            var response = new PersonalClaimDetails();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaimDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Date = Convert.ToString(reader.GetValue(0));
                            response.MonthId = Convert.ToInt32(reader.GetValue(1));
                            response.VehicleNumber = reader.GetString(2);
                            response.Total = Convert.ToDouble(reader.GetValue(3));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static (List<TravelClaimList>, PageInfo) GetTravelClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<TravelClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetTravellingClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TravelClaimList();
                            result.TravelId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.ProjectCode = reader.GetString(2);
                            result.Destination = reader.GetString(3);
                            result.TotalAmount = Convert.ToDouble(reader.GetValue(4));

                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }

        public static TravellingClaimDetails GetTravellingClaimDetails(Adapter ad, int travelId)
        {
            var response = new TravellingClaimDetails();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetTravellingClaimDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = travelId, ParameterName = "@TravelId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Date = Convert.ToString(reader.GetValue(0));
                            response.MonthId = Convert.ToInt32(reader.GetValue(1));
                            response.ProjectCode = reader.GetString(2);
                            response.Destination = reader.GetString(3);
                            response.Description = reader.GetString(4);
                            response.VehicleId = Convert.ToInt32(reader.GetValue(5));
                            response.Distance = Convert.ToDouble(reader.GetValue(6));
                            response.TotalMileage = Convert.ToDouble(reader.GetValue(7));
                            response.MealAllowance = Convert.ToDouble(reader.GetValue(8));
                            response.Accomodation = Convert.ToDouble(reader.GetValue(9));
                            response.Toll = Convert.ToDouble(reader.GetValue(10));
                            response.Parking = Convert.ToDouble(reader.GetValue(11));
                            response.TotalAmount = Convert.ToDouble(reader.GetValue(12));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static (List<PhoneAllowanceClaimList>, PageInfo) GetPhoneAllowanceClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<PhoneAllowanceClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPhoneAllowanceClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PhoneAllowanceClaimList();
                            result.PhoneId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }

        public static PhoneAllowanceClaimDetails GetPhoneAllowanceClaimDetails(Adapter ad, int phoneId)
        {
            var response = new PhoneAllowanceClaimDetails();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPhoneAllowanceClaimDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = phoneId, ParameterName = "@PhoneId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Date = Convert.ToString(reader.GetValue(0));
                            response.MonthId = Convert.ToInt32(reader.GetValue(1));
                            response.BilNumber = reader.GetString(2);
                            response.Items = reader.GetString(3);
                            response.SupplierId = Convert.ToInt32(reader.GetValue(4));
                            response.Total = Convert.ToDouble(reader.GetValue(5));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static (List<MedicalClaimList>, PageInfo) GetMedicalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<MedicalClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetMedicalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new MedicalClaimList();
                            result.MedicalId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }


        public static MedicalClaimDetails GetMedicalClaimDetails(Adapter ad, int medicalId)
        {
            var response = new MedicalClaimDetails();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetMedicalClaimDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = medicalId, ParameterName = "@MedicalId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Date = Convert.ToString(reader.GetValue(0));
                            response.MonthId = Convert.ToInt32(reader.GetValue(1));
                            response.BilNumber = reader.GetString(2);
                            response.Items = reader.GetString(3);
                            response.SupplierName = reader.GetString(4);
                            response.Total = Convert.ToDouble(reader.GetValue(5));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static (List<PurchaseItemClaimList>, PageInfo) GetPurchaseItemClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<PurchaseItemClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPurchaseItemClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PurchaseItemClaimList();
                            result.PurchaseId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }

        public static PurchaseItemClaimDetails GetPurchaseItemClaimDetails(Adapter ad, int purchaseId)
        {
            var response = new PurchaseItemClaimDetails();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPurchaseItemClaimDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = purchaseId, ParameterName = "@PurchaseId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Date = Convert.ToString(reader.GetValue(0));
                            response.MonthId = Convert.ToInt32(reader.GetValue(1));
                            response.BilNumber = reader.GetString(2);
                            response.Items = reader.GetString(3);
                            response.SupplierName = reader.GetString(4);
                            response.Total = Convert.ToDouble(reader.GetValue(5));

                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<TravelClaimList> GetPersonalClaimTravellingList(Adapter ad, int claimId)
        {
            var response = new List<TravelClaimList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaimTravellingList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TravelClaimList();
                            result.TravelId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.ProjectCode = reader.GetString(2);
                            result.Destination = reader.GetString(3);
                            result.TotalAmount = Convert.ToDouble(reader.GetValue(4));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<PhoneAllowanceClaimList> GetPersonalClaimPhoneList(Adapter ad, int claimId)
        {
            var response = new List<PhoneAllowanceClaimList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaimPhoneList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PhoneAllowanceClaimList();
                            result.PhoneId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<MedicalClaimList> GetPersonalClaimMedicalList(Adapter ad, int claimId)
        {
            var response = new List<MedicalClaimList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaimMedicalList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new MedicalClaimList();
                            result.MedicalId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<PurchaseItemClaimList> GetPersonalClaimPurchaseList(Adapter ad, int claimId)
        {
            var response = new List<PurchaseItemClaimList>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetPersonalClaimPurchaseList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PurchaseItemClaimList();
                            result.PurchaseId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.Month = reader.GetString(1);
                            }
                            else
                            {
                                result.Month = "";
                            }
                            result.Items = reader.GetString(2);
                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static List<ClaimAttachment> GetAttachmentTravelling(Adapter ad, int travelId)
        {
            var response = new List<ClaimAttachment>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetAttachmentTravelling", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = travelId, ParameterName = "@TravelId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ClaimAttachment
                            {
                                travelId = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                            };

                            response.Add(result);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static List<ClaimAttachment> GetAttachmentPhoneAllowance(Adapter ad, int phoneId)
        {
            var response = new List<ClaimAttachment>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetAttachmentPhoneAllowance", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = phoneId, ParameterName = "@PhoneId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ClaimAttachment
                            {
                                phoneId = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                            };

                            response.Add(result);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<ClaimAttachment> GetAttachmentMedical(Adapter ad, int medicalId)
        {
            var response = new List<ClaimAttachment>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetAttachmentMedical", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = medicalId, ParameterName = "@MedicalId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ClaimAttachment
                            {
                                medicalId = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                            };

                            response.Add(result);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<ClaimAttachment> GetAttachmentPurchaseItem(Adapter ad, int purchaseId)
        {
            var response = new List<ClaimAttachment>();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_GetAttachmentPurchaseItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = purchaseId, ParameterName = "@PurchaseId" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ClaimAttachment
                            {
                                purchaseId = Convert.ToInt32(reader.GetValue(0)),
                                attachmentURL = reader.GetString(1),
                                description = reader.GetString(2),
                            };

                            response.Add(result);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static (List<WaitingApprovalClaimList>, PageInfo) GetWaitingApprovalClaimList(Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<WaitingApprovalClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetClaimWaitingApproval", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new WaitingApprovalClaimList();
                            result.ClaimId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.UserName = reader.GetString(1);
                            }
                            else
                            {
                                result.UserName = "";
                            }

                            if (reader.GetValue(2).ToString() != "")
                            {
                                result.Month = reader.GetString(2);
                            }
                            else
                            {
                                result.Month = "";
                            }

                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            if (reader.GetValue(4).ToString() != "")
                            {
                                result.StatusName = reader.GetString(4);
                            }
                            else
                            {
                                result.StatusName = "";
                            }


                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }

        public static (List<ApprovedClaimList>, PageInfo) GetApprovedClaimList (Adapter ad, int userId, string searchKey, Pager pager = null)
        {
            var response = new List<ApprovedClaimList>();
            var response2 = new PageInfo();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetClaimApproved", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = searchKey, ParameterName = "@SearchKey" });

                    if (pager != null)
                    {
                        command.Parameters.Add(new SqlParameter() { Value = pager.RowsPerPage, ParameterName = "@RowsPerPage" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.PageNumber, ParameterName = "@PageNumber" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.OrderScript, ParameterName = "@OrderScript" });
                        command.Parameters.Add(new SqlParameter() { Value = pager.ColumnFilterScript, ParameterName = "@ColumnFilterScript" });
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ApprovedClaimList();
                            result.ClaimId = Convert.ToInt32(reader.GetValue(0));
                            if (reader.GetValue(1).ToString() != "")
                            {
                                result.UserName = reader.GetString(1);
                            }
                            else
                            {
                                result.UserName = "";
                            }

                            if (reader.GetValue(2).ToString() != "")
                            {
                                result.Month = reader.GetString(2);
                            }
                            else
                            {
                                result.Month = "";
                            }

                            result.Total = Convert.ToDouble(reader.GetValue(3));

                            if (reader.GetValue(4).ToString() != "")
                            {
                                result.StatusName = reader.GetString(4);
                            }
                            else
                            {
                                result.StatusName = "";
                            }


                            response.Add(result);

                        }
                        reader.NextResult();
                        while (reader.Read())
                        {

                            response2.RowCount = Convert.ToInt32(reader.GetValue(0));

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return (response, response2);
        }


        public static ClaimReport GetClaimReport(Adapter ad, int claimId)
        {
            var response = new ClaimReport();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetReportClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.TenantLogo = reader.GetString(0);
                            response.Name = reader.GetString(1);
                            response.Date = Convert.ToString(reader.GetValue(2));
                            response.Month = reader.GetString(3);
                            response.VehicleNumber = reader.GetString(4);
                            response.Address = reader.GetString(5);

                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<TravellingClaimReport> GetTravellingClaimReport(Adapter ad, int claimId)
        {
            var response = new List<TravellingClaimReport>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetReportClaimTravellingList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TravellingClaimReport();
                            result.TravelDate = Convert.ToString(reader.GetValue(0));
                            result.ProjectCode = reader.GetString(1);
                            result.Destination = reader.GetString(2);
                            result.Description = reader.GetString(3);
                            result.Distance = Convert.ToDouble(reader.GetValue(4));
                            result.TotalMileage = Convert.ToDouble(reader.GetValue(5));
                            result.MealAllowance = Convert.ToDouble(reader.GetValue(6));
                            result.Accomodation = Convert.ToDouble(reader.GetValue(7));
                            result.Toll = Convert.ToDouble(reader.GetValue(8));
                            result.Parking = Convert.ToDouble(reader.GetValue(9));
                            result.TotalTravel = Convert.ToDouble(reader.GetValue(10));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<PhoneAllowanceClaimReport> GetPhoneAllowanceClaimReport(Adapter ad, int claimId)
        {
            var response = new List<PhoneAllowanceClaimReport>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetReportClaimPhoneList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PhoneAllowanceClaimReport();
                            result.Date = Convert.ToString(reader.GetValue(0));
                            result.BilNumber = reader.GetString(1);
                            result.Items = reader.GetString(2);
                            result.SupplierName = reader.GetString(3);
                            result.Total = Convert.ToDouble(reader.GetValue(4));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static List<MedicalClaimReport> GetMedicalClaimReport(Adapter ad, int claimId)
        {
            var response = new List<MedicalClaimReport>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetReportClaimMedicalList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new MedicalClaimReport();
                            result.Date = Convert.ToString(reader.GetValue(0));
                            result.BilNumber = reader.GetString(1);
                            result.Items = reader.GetString(2);
                            result.SupplierName = reader.GetString(3);
                            result.Total = Convert.ToDouble(reader.GetValue(4));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static List<PurchaseItemClaimReport> GetPurchaseItemClaimReport(Adapter ad, int claimId)
        {
            var response = new List<PurchaseItemClaimReport>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_HR_GetReportClaimPurchaseList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new PurchaseItemClaimReport();
                            result.Date = Convert.ToString(reader.GetValue(0));
                            result.BilNumber = reader.GetString(1);
                            result.Items = reader.GetString(2);
                            result.SupplierName = reader.GetString(3);
                            result.Total = Convert.ToDouble(reader.GetValue(4));

                            response.Add(result);
                        }
                        reader.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }




        //--------------------------------------------PUT Method---------------------------------------------------------

        public static BasicApiResponse UpdatePersonalClaim(Adapter ad, UpdatePersonalClaim updatePersonalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdatePersonalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.VehicleNumber, ParameterName = "@VehicleNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.TotalClaim, ParameterName = "@Total" }); ;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdateTravellingClaim(Adapter ad, UpdateTravellingClaim updateTravellingClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateTravellingClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.TravelId, ParameterName = "@TravelId" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.ProjectCode, ParameterName = "@ProjectCode" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Destination, ParameterName = "@Destination" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.VehicleId, ParameterName = "@VehicleId" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Distance, ParameterName = "@Distance" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.TotalMileage, ParameterName = "@TotalMileage" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.MealAllowance, ParameterName = "@MealAllowance" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Accomodation, ParameterName = "@Accomodation" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Toll, ParameterName = "@Toll" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.Parking, ParameterName = "@Parking" });
                    command.Parameters.Add(new SqlParameter() { Value = updateTravellingClaim.TotalAmount, ParameterName = "@TotalAmount" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdatePhoneAllowanceClaim(Adapter ad, UpdatePhoneAllowanceClaim updatePhoneAllowanceClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdatePhoneAllowanceClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.PhoneId, ParameterName = "@PhoneId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.SupplierId, ParameterName = "@SupplierId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePhoneAllowanceClaim.Total, ParameterName = "@Total" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdateMedicalClaim(Adapter ad, UpdateMedicalClaim updateMedicalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateMedicalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.MedicalId, ParameterName = "@MedicalId" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = updateMedicalClaim.Total, ParameterName = "@Total" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdatePurchaseClaim(Adapter ad, UpdatePurchaseClaim updatePurchaseClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdatePurchaseItemClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.PurchaseId, ParameterName = "@PurchaseId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePurchaseClaim.Total, ParameterName = "@Total" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse UpdateClaimApprover(Adapter ad, int claimId, int approverId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateClaimApprover", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = approverId, ParameterName = "@ApproverId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdateClaimStatusApprove(Adapter ad, UpdateClaimStatus updateClaimStatus)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateClaimStatusApprove", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updateClaimStatus.ClaimId, ParameterName = "@ClaimId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse UpdateClaimStatusReject (Adapter ad, UpdatePersonalClaim updatePersonalClaim)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_UpdateClaimStatusReject", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = updatePersonalClaim.RejectDescription, ParameterName = "@RejectDescription" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(0);
                            response.ResponseMessage = reader.GetString(1);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }






        //--------------------------------------------POST Method---------------------------------------------------------

        public static PostApiResponse InsertPersonalClaim(Adapter ad, InsertPersonalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPersonalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.VehicleNumber, ParameterName = "@VehicleNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }



        public static PostApiResponse InsertTravellingClaim(Adapter ad, InsertTravellingClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertTravellingClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ProjectCode, ParameterName = "@ProjectCode" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Destination, ParameterName = "@Destination" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.VehicleId, ParameterName = "@VehicleId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Distance, ParameterName = "@Distance" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TotalMileage, ParameterName = "@TotalMileage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MealAllowance, ParameterName = "@MealAllowance" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Accomodation, ParameterName = "@Accomodation" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Toll, ParameterName = "@Toll" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Parking, ParameterName = "@Parking" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TotalMileage + request.MealAllowance +
                                                                        request.Accomodation + request.Toll + request.Parking,
                                                                        ParameterName = "@TotalAmount" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPhoneAllowanceClaim(Adapter ad, InsertPhoneAllowanceClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPhoneAllowanceClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierId, ParameterName = "@SupplierId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertMedicalClaim(Adapter ad, InsertMedicalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertMedicalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPurchaseItemClaim(Adapter ad, InsertPurchaseItemClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPurchaseItemClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPersonalClaimTravelling(Adapter ad, InsertTravellingClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPersonalClaimTravelling", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.ProjectCode, ParameterName = "@ProjectCode" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Destination, ParameterName = "@Destination" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Distance, ParameterName = "@Distance" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TotalMileage, ParameterName = "@TotalMileage" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MealAllowance, ParameterName = "@MealAllowance" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Accomodation, ParameterName = "@Accomodation" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Toll, ParameterName = "@Toll" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Parking, ParameterName = "@Parking" });
                    command.Parameters.Add(new SqlParameter() { Value = request.TotalMileage + request.MealAllowance +
                                                                        request.Accomodation + request.Toll + request.Parking, ParameterName = "@TotalAmount"});
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPersonalClaimPhone(Adapter ad, InsertPhoneAllowanceClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPersonalClaimPhone", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierId, ParameterName = "@SupplierId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static PostApiResponse InsertPersonalClaimMedical(Adapter ad, InsertMedicalClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPersonalClaimMedical", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertPersonalClaimPurchaseItem(Adapter ad, InsertPurchaseItemClaim request, int userId, int tenantId, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertPersonalClaimPurchaseItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.ClaimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = tenantId, ParameterName = "@TenantId" });
                    command.Parameters.Add(new SqlParameter() { Value = userId, ParameterName = "@UserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Date, ParameterName = "@Date" });
                    command.Parameters.Add(new SqlParameter() { Value = request.MonthId, ParameterName = "@MonthId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.BilNumber, ParameterName = "@BilNumber" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Items, ParameterName = "@Items" });
                    command.Parameters.Add(new SqlParameter() { Value = request.SupplierName, ParameterName = "@SupplierName" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Total, ParameterName = "@Total" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertAttachmentTravel(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertAttachmentTravelling", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.claimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.travelId, ParameterName = "@TravelId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertAttachmentPhoneAllowance(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertAttachmentPhoneAllowance", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.claimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.phoneId, ParameterName = "@PhoneId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertAttachmentMedical(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertAttachmentMedical", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.claimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.medicalId, ParameterName = "@MedicalId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static PostApiResponse InsertAttachmentPurchaseItem(Adapter ad, InsertClaimAttachment request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_InsertAttachmentPurchaseItem", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.claimId, ParameterName = "@ClaimId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.purchaseId, ParameterName = "@PurchaseId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.attachmentURL, ParameterName = "@AttachmentURL" });
                    command.Parameters.Add(new SqlParameter() { Value = request.description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = creatorUserId, ParameterName = "@CreatorUserId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                            response.Id = Convert.ToInt32(reader.GetValue(2));
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }



        //--------------------------------------------DELETE Method---------------------------------------------------------

        public static BasicApiResponse DeletePersonalClaimList(Adapter ad, int claimId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeletePersonalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }



        public static BasicApiResponse DeleteTravellingClaimList(Adapter ad, int travelId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteTravellingClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = travelId, ParameterName = "@TravelId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeletePhoneAllowanceClaimList(Adapter ad, int phoneId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeletePhoneAllowanceClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = phoneId, ParameterName = "@PhoneId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeleteMedicalClaimList(Adapter ad, int medicalId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteMedicalClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = medicalId, ParameterName = "@MedicalId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeletePurchaseItemClaimList(Adapter ad, int purchaseId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeletePurchaseItemClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = purchaseId, ParameterName = "@PurchaseId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteClaim_Travelling(Adapter ad, int claimId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteClaim_Travelling", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = claimId, ParameterName = "@ClaimId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ResponseMessage = reader.GetString(0);
                            response.ReturnCode = reader.GetInt32(1);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }



        public static BasicApiResponse DeleteAttachmentTravelling(Adapter ad, string travelId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteAttachmentClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = travelId, ParameterName = "@TravelId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteAttachmentPhone(Adapter ad, string phoneId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteAttachmentClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = phoneId, ParameterName = "@PhoneId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }

        public static BasicApiResponse DeleteAttachmentMedical(Adapter ad, string medicalId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteAttachmentClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = medicalId, ParameterName = "@MedicalId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }


        public static BasicApiResponse DeleteAttachmentPurchaseItem(Adapter ad, string purchaseId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_HR_DeleteAttachmentClaim", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = purchaseId, ParameterName = "@PurchaseId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
                        }
                        reader.Close();
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
            }
            return response;
        }



    }
}
