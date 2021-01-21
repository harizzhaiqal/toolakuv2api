using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models;
using System.Data.SqlClient;
using Toolaku.Library;
using System.Data;
using Toolaku.Models.Reference;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.DataAccess
{
    public class ReferenceDAL
    {
        public static List<DayType> GetDayType(Adapter ad)
        {
            var DayTypes = new List<DayType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetDayType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var DayType = new DayType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            DayTypes.Add(DayType);
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
            return DayTypes;
        }



        public static List<Edition> GetEdition(Adapter ad)
        {
            var Editions = new List<Edition>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetEdition", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Edition = new Edition
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            Editions.Add(Edition);
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
            return Editions;
        }



        public static List<DocumentType> GetDocumentType(Adapter ad)
        {
            var DocumentTypes = new List<DocumentType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetDocumentType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var DocumentType = new DocumentType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            DocumentTypes.Add(DocumentType);
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
            return DocumentTypes;
        }


        public static List<Frequency> GetFrequency(Adapter ad)
        {
            var Frequencys = new List<Frequency>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetFrequency", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Frequency = new Frequency
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            Frequencys.Add(Frequency);
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
            return Frequencys;
        }


        public static List<Gender> GetGender(Adapter ad)
        {
            var Genders = new List<Gender>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetGender", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Gender = new Gender
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            Genders.Add(Gender);
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
            return Genders;
        }


        public static List<LeaveDurationType> GetLeaveDurationType(Adapter ad)
        {
            var LeaveDurationTypes = new List<LeaveDurationType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetLeaveDurationType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var LeaveDurationType = new LeaveDurationType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            LeaveDurationTypes.Add(LeaveDurationType);
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
            return LeaveDurationTypes;
        }



        public static List<LeaveType> GetLeaveType(Adapter ad)
        {
            var LeaveTypes = new List<LeaveType>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetLeaveType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var LeaveType = new LeaveType
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            LeaveTypes.Add(LeaveType);
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
            return LeaveTypes;
        }


        public static List<MaritalStatus> GetMaritalStatus(Adapter ad)
        {
            var MaritalStatuss = new List<MaritalStatus>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetMaritalStatus", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var MaritalStatus = new MaritalStatus
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            MaritalStatuss.Add(MaritalStatus);
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
            return MaritalStatuss;
        }


        public static List<EmploymentStatus> GetEmploymentStatus(Adapter ad)
        {
            var EmploymentStatuss = new List<EmploymentStatus>();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetEmploymentStatus", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var EmploymentStatus = new EmploymentStatus
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            EmploymentStatuss.Add(EmploymentStatus);
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
            return EmploymentStatuss;
        }

        public static List<CategoryType> GetCategoryType(Adapter ad)
        {
            var categoryTypes = new List<CategoryType>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetCategoryType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoryType = new CategoryType
                            {
                                Id = reader.GetInt32(0),
                                TypeName = reader.GetString(1)
                            };

                            categoryTypes.Add(categoryType);
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
            return categoryTypes;
        }

        public static List<ProductCategory> GetProductCategoryParent(Adapter ad)
        {
            var productCategories = new List<ProductCategory>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetProductCategoryParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productCategory = new ProductCategory
                            {
                                categoryId = reader.GetInt32(0),
                                categoryName = reader.GetString(1)
                            };

                            productCategories.Add(productCategory);
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
            return productCategories;
        }

        public static List<ProductCategory> GetProductCategory(Adapter ad, int categoryId)
        {
            var productCategories = new List<ProductCategory>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetProductCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productCategory = new ProductCategory
                            {
                                categoryId = reader.GetInt32(0),
                                categoryName = reader.GetString(1)
                            };

                            productCategories.Add(productCategory);
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
            return productCategories;
        }

        public static List<ServiceCategory> GetServiceCategoryParent(Adapter ad)
        {
            var serviceCategories = new List<ServiceCategory>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetServiceCategoryParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceCategory = new ServiceCategory
                            {
                                categoryId = reader.GetInt32(0),
                                categoryName = reader.GetString(1)
                            };

                            serviceCategories.Add(serviceCategory);
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
            return serviceCategories;
        }

        public static List<ServiceCategory> GetServiceCategory(Adapter ad, int categoryId)
        {
            var serviceCategories = new List<ServiceCategory>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetServiceCategory", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryId, ParameterName = "@CategoryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var serviceCategory = new ServiceCategory
                            {
                                categoryId = reader.GetInt32(0),
                                categoryName = reader.GetString(1)
                            };

                            serviceCategories.Add(serviceCategory);
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
            return serviceCategories;
        }

        public static List<Country> GetCountry(Adapter ad)
        {
            var countries = new List<Country>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetCountry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var country = new Country
                            {
                                CountryId = reader.GetInt32(0),
                                CountryCode = reader.GetString(1),
                                CountryName = reader.GetString(2)
                            };

                            countries.Add(country);
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
            return countries;
        }

        public static List<Month> GetMonth(Adapter ad)
        {
            var response = new List<Month>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetMonth", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Month
                            {
                                MonthId = reader.GetInt32(0),
                                MonthName = reader.GetString(1)
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

        public static List<Vehicle> GetVehicle(Adapter ad)
        {
            var response = new List<Vehicle>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetVehicle", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Vehicle
                            {
                                VehicleId = reader.GetInt32(0),
                                VehicleName = reader.GetString(1),
                                /*VehicleRate = reader.GetFloat(0)*/
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

        public static List<TelcoSupplier> GetTelcoSupplier(Adapter ad)
        {
            var response = new List<TelcoSupplier>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetTelcoSupplier", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new TelcoSupplier
                            {
                                TelcoId = reader.GetInt32(0),
                                TelcoName = reader.GetString(1)
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


        public static List<State> GetState(Adapter ad, int countryId)
        {
            var states = new List<State>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = countryId, ParameterName = "@CountryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var state = new State
                            {
                                StateId = reader.GetInt32(0),
                                StateCode = reader.GetString(1),
                                StateName = reader.GetString(2)
                            };

                            states.Add(state);
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
            return states;
        }

        public static List<City> GetCity(Adapter ad, int stateId)
        {
            var cities = new List<City>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetCity", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = stateId, ParameterName = "@StateId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var city = new City
                            {
                                CityId = reader.GetInt32(0),
                                CityName = reader.GetString(1)
                            };

                            cities.Add(city);
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
            return cities;
        }

        public static List<ProductCountry> GetProductCountry(Adapter ad)
        {
            var countries = new List<ProductCountry>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetCountry", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var country = new ProductCountry
                            {
                                countryId = reader.GetInt32(0),
                                countryCode = reader.GetString(1),
                                countryName = reader.GetString(2)
                            };

                            countries.Add(country);
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
            return countries;
        }

        public static List<ProductState> GetProductState(Adapter ad, int countryId)
        {
            var states = new List<ProductState>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetState", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = countryId, ParameterName = "@CountryId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var state = new ProductState
                            {
                                stateId = reader.GetInt32(0),
                                stateCode = reader.GetString(1),
                                stateName = reader.GetString(2)
                            };

                            states.Add(state);
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
            return states;
        }

        public static List<ProductCity> GetProductCity(Adapter ad, int stateId)
        {
            var cities = new List<ProductCity>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetCity", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = stateId, ParameterName = "@StateId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var city = new ProductCity
                            {
                                cityId = reader.GetInt32(0),
                                cityName = reader.GetString(1)
                            };

                            cities.Add(city);
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
            return cities;
        }

        public static List<LocationType> GetLocationType(Adapter ad)
        {
            var locationTypes = new List<LocationType>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetLocationType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var locationType = new LocationType
                            {
                                locationTypeId = reader.GetInt32(0),
                                locationCode = reader.GetString(1),
                                locationTypeName = reader.GetString(2)
                            };

                            locationTypes.Add(locationType);
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
            return locationTypes;
        }

        public static List<Condition> GetPoductCondition(Adapter ad)
        {
            var response = new List<Condition>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetProductCondition", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Condition
                            {
                                ConditionId = reader.GetInt32(0),
                                ConditionCode = reader.GetString(1)
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

        public static List<ProductMaterial> GetPoductMaterial(Adapter ad)
        {
            var response = new List<ProductMaterial>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetProductMaterial", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new ProductMaterial
                            {
                                MaterialId = reader.GetInt32(0),
                                MaterialName = reader.GetString(1)
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

        public static List<Uom> GetUnitOfMeasurement(Adapter ad)
        {
            var response = new List<Uom>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetUOM", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Uom
                            {
                                uomId = reader.GetInt32(0),
                                symbol = reader.GetString(1),
                                unitName = reader.GetString(2)
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

        public static List<Agency> GetAgency(Adapter ad)
        {
            var response = new List<Agency>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetAgency", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Agency
                            {
                                AgencyId = reader.GetInt32(0),
                                AgencyName = reader.GetString(1)
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

        public static List<AgencyGrade> GetAgencyGrade(Adapter ad, int agencyId)
        {
            var response = new List<AgencyGrade>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetAgencyGrade", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = agencyId, ParameterName = "@AgencyId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new AgencyGrade
                            {
                                AgencyGradeId = Convert.ToInt32(reader.GetValue(0)),
                                Code = Convert.ToString(reader.GetValue(1))
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

        public static List<AgencyCodeParent> GetAgencyCodeParent(Adapter ad, int agencyId)
        {
            var response = new List<AgencyCodeParent>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetAgencyCodeParent", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = agencyId, ParameterName = "@AgencyId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new AgencyCodeParent
                            {
                                AgencyCodeId = Convert.ToInt32(reader.GetValue(0)),
                                CodeName = Convert.ToString(reader.GetValue(1))
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

        public static List<AgencyCode> GetAgencyCode(Adapter ad, int agencyCodeId)
        {
            var response = new List<AgencyCode>();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_GetAgencyCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = agencyCodeId, ParameterName = "@AgencyCodeId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new AgencyCode
                            {
                                AgencyCodeId = Convert.ToInt32(reader.GetValue(0)),
                                CodeName = Convert.ToString(reader.GetValue(1))
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



        public static (List<DepartmentRoleList>, PageInfo) GetDepartmentRoleList(Adapter ad, string searchKey, Pager pager = null)
        {
            var response = new List<DepartmentRoleList>();
            var response2 = new PageInfo();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetDepartmentRoleList", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    
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
                        int Id = reader.GetOrdinal("Id");
                        int Name = reader.GetOrdinal("Name");
                        int IsDeleted = reader.GetOrdinal("IsDeleted");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            var result = new DepartmentRoleList
                            {
                                Id = Convert.ToInt32(reader.GetValue(Id)),
                                Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name),
                                IsDeleted = Convert.ToInt32(reader.GetValue(IsDeleted)),
                                IsEnable = Convert.ToInt32(reader.GetValue(IsEnable)),
                            };
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


        public static DepartmentRoleDetails GetDepartmentRoleDetails(Adapter ad, int id)
        {
            var response = new DepartmentRoleDetails();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_GetDepartmentRoleDetails", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = id, ParameterName = "@Id" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Id = reader.GetOrdinal("Id");
                        int Name = reader.GetOrdinal("Name");
                        int IsEnable = reader.GetOrdinal("IsEnable");

                        while (reader.Read())
                        {
                            response.Id = Convert.ToInt32(reader.GetValue(Id));
                            response.Name = (reader.GetValue(Name) == DBNull.Value) ? "" : reader.GetString(Name);
                            response.IsEnable = Convert.ToInt32(reader.GetValue(IsEnable));
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return response;
        }



        //--------------PUT Method--------------
        public static PostApiResponse UpdateCategoryType(Adapter ad, CategoryType categoryType)
        {
            //var categoryTypes = new List<CategoryType>();
            var response = new PostApiResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateCategoryType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryType.Id, ParameterName = "@CategoryTypeId" });
                    command.Parameters.Add(new SqlParameter() { Value = categoryType.TypeName, ParameterName = "@CategoryTypeName" });

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
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }


        public static BasicApiResponse DeleteCategoryTypeList(Adapter ad, int categoryTypeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteCategoryType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryTypeId, ParameterName = "@CategoryTypeId" });

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



        public static PostApiResponse UpdateAgency(Adapter ad, Agency Agency)
        {
            var response = new PostApiResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateAgency", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyId, ParameterName = "@AgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyName, ParameterName = "@AgencyName" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyLogo, ParameterName = "@AgencyLogo" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyCode, ParameterName = "@AgencyCode" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyDecription, ParameterName = "@AgencyDecription" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyTypeId, ParameterName = "@AgencyTypeId" });
                    
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
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static BasicApiResponse DeleteAgencyList(Adapter ad, int AgencyId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteAgency", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyId, ParameterName = "@AgencyId" });

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


        public static PostApiResponse UpdateAgencyCode(Adapter ad, AgencyCode AgencyCode)
        {
            var response = new PostApiResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateAgencyCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.AgencyCodeId, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Code, ParameterName = "@Code" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.AgencyId, ParameterName = "@AgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.ParentId, ParameterName = "@ParentId" });

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
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static BasicApiResponse DeleteAgencyCodeList(Adapter ad, int AgencyCodeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteAgencyCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyCodeId, ParameterName = "@AgencyCodeId" });

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


        public static PostApiResponse UpdateAgencyGrade(Adapter ad, AgencyGrade AgencyGrade)
        {
            var response = new PostApiResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateAgencyGrade", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.AgencyGradeId, ParameterName = "@AgencyGradeId" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Code, ParameterName = "@Code" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.AgencyId, ParameterName = "@AgencyId" });

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
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static BasicApiResponse DeleteAgencyGradeList(Adapter ad, int AgencyGradeId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteAgencyGrade", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyGradeId, ParameterName = "@AgencyGradeId" });

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
               
        public static PostApiResponse UpdateProductMaterial(Adapter ad, ProductMaterial ProductMaterial)
        {
            var response = new PostApiResponse();

            try
            {

                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateProductMaterial", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterial.MaterialId, ParameterName = "@ProductMaterialId" });
                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterial.MaterialName, ParameterName = "@ProductMaterialName" });
                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterial.Description, ParameterName = "@ProductMaterialDecription" });

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
            catch (SqlException ex)
            {
                //clsErrorLog.ErrorLog(_PageName, ex);
                throw ex;
            }
            return response;
        }

        public static BasicApiResponse DeleteProductMaterialList(Adapter ad, int ProductMaterialId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteProductMaterial", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterialId, ParameterName = "@ProductMaterialId" });

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


        public static BasicApiResponse UpdateDepartmentRole(Adapter ad, UpdateDepartmentRole request, int updatorUserId)
        {
            var response = new BasicApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_UpdateDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { Value = request.Id, ParameterName = "@Id" });
                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = updatorUserId, ParameterName = "@UpdatorUserId" });
                    command.Parameters.Add(new SqlParameter() { Value = request.IsEnable, ParameterName = "@IsEnable" });

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
            }
            return response;
        }


        //--------------POST Method--------------
        public static PostApiResponse InsertCategoryType(Adapter ad, CategoryType categoryType)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertCategoryType", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = categoryType.TypeName, ParameterName = "@CategoryTypeName" });


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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


        public static PostApiResponse InsertAgency(Adapter ad, Agency Agency)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertAgency", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyName, ParameterName = "@AgencyName" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyLogo, ParameterName = "@AgencyLogo" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyCode, ParameterName = "@AgencyCode" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyDecription, ParameterName = "@AgencyDecription" });
                    command.Parameters.Add(new SqlParameter() { Value = Agency.AgencyTypeId, ParameterName = "@AgencyTypeId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static PostApiResponse InsertAgencyCode(Adapter ad, AgencyCode AgencyCode)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertAgencyCode", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;
                                        
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Code, ParameterName = "@Code" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.AgencyId, ParameterName = "@AgencyId" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyCode.ParentId, ParameterName = "@ParentId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static PostApiResponse InsertAgencyGrade(Adapter ad, AgencyGrade AgencyGrade)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertAgencyGrade", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Code, ParameterName = "@Code" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Name, ParameterName = "@Name" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.Description, ParameterName = "@Description" });
                    command.Parameters.Add(new SqlParameter() { Value = AgencyGrade.AgencyId, ParameterName = "@AgencyId" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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

        public static PostApiResponse InsertProductMaterial(Adapter ad, ProductMaterial ProductMaterial)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertProductMaterial", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterial.MaterialName, ParameterName = "@ProductMaterialName" });
                    command.Parameters.Add(new SqlParameter() { Value = ProductMaterial.Description, ParameterName = "@ProductMaterialDecription" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ReturnCode = reader.GetInt32(1);
                            response.ResponseMessage = reader.GetString(0);
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


        public static PostApiResponse InsertDepartmentRole(Adapter ad, InsertDepartmentRole request, int creatorUserId)
        {
            var response = new PostApiResponse();

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_InsertDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = request.Name, ParameterName = "@Name" });
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
            }
            return response;
        }

        //DELETE--------------------------------
        public static BasicApiResponse DeleteDepartmentRole(Adapter ad, string ids, int deleteUserId)
        {
            var response = new BasicApiResponse();
            response.ReturnCode = -1;

            try
            {
                using (SqlCommand command = new SqlCommand("sp_Reference_DeleteDepartmentRole", ad.SQLConn, ad.SQLTran))
                {
                    SqlParameter Param = new SqlParameter();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { Value = ids, ParameterName = "@Ids" });
                    command.Parameters.Add(new SqlParameter() { Value = deleteUserId, ParameterName = "@DeleteUserId" });

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
            }
            return response;
        }


    }



}
