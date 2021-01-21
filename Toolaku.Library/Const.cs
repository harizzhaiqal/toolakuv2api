namespace Toolaku.Library
{
    public class Const
    {
        /// <summary>
        /// "1900-01-01"
        /// </summary>
        /// <remarks></remarks>

        public const string constDate_MinDate = "1900-01-01";
        /// <summary>
        /// "1900-01-01"
        /// </summary>
        /// <remarks></remarks>

        public const string constDate_MinDateTime = "1900-01-01 00:00:00";
        //Public Const constDate_MinDate As Date = CDate("1900-01-01")

        /// <summary>
        /// Format "dd/MMM/yyyy"
        /// </summary>
        /// <remarks></remarks>
        public const string constDate_DateFmt = "{0:yyyy-MM-dd}";
        public const string constDate_yyyy_MM_DD = "{0:yyyy-MM-dd}";
        public const string constDate_yyyy_MM_DD_time = "{0:yyyy-MM-dd hh:mm tt}";
        public const string constDate_dd_MM_yyyy = "{0:dd-MM-yyyy}";

        public const string constDate_DateCulture = "en-CA";
        /// <summary>
        /// Format "dd/MM/yyyy HH:mm:ss"
        /// </summary>
        /// <remarks></remarks>

        public const string constDate_DateTimeFmt = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// "yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <remarks></remarks>

        public const string constDate_SQLDateTimeFmt = "yyyy-MM-dd HH:mm:ss";
        public const string constDate_SQLDateFmt = "yyyy-MM-dd";

        public const string constDate_HtmlDateFmt = "yyyy-mm-dd";

        public const string constWebConfig_ProjectCode = "ProjectCode";
        public const string constWebConfig_ErrorLog = "ErrorLog";
        public const string constWebConfig_Host = "Host";

        public const string constWebConfig_ConnectionString = "ConnectionString";
        public const string constXmlString_StartTableNode = "<xmlTable>";
        public const string constXmlString_EndTableNode = "</xmlTable>";
        public const string constXmlString_StartRowNode = "<xmlRow>";
        public const string constXmlString_EndRowNode = "</xmlRow>";

        public const string constImageFileName_NoImage = "~/Images/no_image.gif";
        public const string constImageFolder_CountryFlagPath = "~/Images/Country/";
        public const string constImageFolder_ExportImagePath = "~/Images/Export/";

        public const string constImageFolder_Menu = "~/Images/Menu/";
        public const string constImageFolder_RankingPath = "~/Images/Ranking/";

        public const string constImageFolder_RankingNormalHtmlPath = "Images/Ranking/";
        public const string constImageFolder_NetworkPath = "~/Images/Network/";

        public const string constImageFolder_NetworkNormalHtmlPath = "Images/Network/";

        public const string constImageFolder_MessageBox = "~/Images/MyMessageBox/";
        public const int constAction_Insert = 1;
        public const int constAction_Update = 2;
        public const int constAction_Delete = 3;

        public const int constAction_Print = 4;

        public const int constSearchStatus_SearchAll = -1;
        public const int constLoginStatus_Active = 1;

        public const int constLoginStatus_Inactive = 0;
        public const int constMasterDataStatus_Active = 1;

        public const int constMasterDataStatus_Inactive = 0;

        public const int constDistributorBonusStatus_Active = 1;
        public const int constDistributorBonusStatus_InActive = 0;
        public const int constDistributorBonusStatus_Suspend = 2;
        public const int constDistributorBonusStatus_Terminated = 3;
        public const int constDistributorBonusStatus_Pending = 4;

        public const int const_Result_NO_ERROR = 1;
        public const int const_Result_ERROR = 0;

        public const string constMasterDataStatusCode_Active = "MasterDataActive";

        public const string constMasterDataStatusCode_InActive = "MasterDataInactive";

        public const string constDistributorStatusCode_InActive = "Inactive";
        public const string constDistributorStatusCode_Active = "Active";
        public const string constDistributorStatusCode_Suspend = "Suspend";
        public const string constDistributorStatusCode_Terminated = "Terminated";

        public const string constDistributorStatusCode_Pending = "Pending";
        public const string constTransactionStatusCode_PaymentPending = "PaymentPending";
        public const string constTransactionStatusCode_DraftCopy = "DraftCopy";
        public const string constTransactionStatusCode_WaitingApproval = "WaitingApproval";
        public const string constTransactionStatusCode_PaymentConfirmed = "PaymentConfirmed";
        public const string constTransactionStatusCode_Approved = "Approved";
        public const string constTransactionStatusCode_Shipped = "Shipped";
        public const string constTransactionStatusCode_GoodInTransit = "GoodsInTransit";
        public const string constTransactionStatusCode_GoodReceived = "GoodsReceived";
        public const string constTransactionStatusCode_GoodsReturn = "GoodsReturn";
        public const string constTransactionStatusCode_AdminRejected = "AdminRejected";

        public const string constTransactionStatusCode_Cancellation = "Cancellation";

        public const string constShippingTypeStatusCode_CompanyShipping = "CompanyShipping";
        public const string constShippingTypeStatusCode_SelfCollect = "SelfCollect";

        public const string constShippingTypeStatusCode_PickupLocation = "PickupLocation";
        public const string constEwalletTransactionCode_EwalletAdminTopup_In = "EwalletAdminTopup_In";
        public const string constEwalletTransactionCode_EwalletAdminDeduct_Out = "EwalletAdminDeduct_Out";
        public const string constEwalletTransactionCode_EwalletDistributorTopup_In = "EwalletDistributorTopup_In";
        public const string constEwalletTransactionCode_EwalletDistributorDeduct_Out = "EwalletDistributorDeduct_Out";
        public const string constEwalletTransactionCode_EwalletTransfer_In = "EwalletTransfer_In";
        public const string constEwalletTransactionCode_EwalletTransfer_Out = "EwalletTransfer_Out";
        public const string constEwalletTransactionCode_EwalletRegistraionRefund_In = "EwalletRegistraionRefund_In";
        public const string constEwalletTransactionCode_EwalletRegistraionPayment_Out = "EwalletRegistraionPayment_Out";
        public const string constEwalletTransactionCode_EwalletPurchaseRefund_In = "EwalletPurchaseRefund_In";
        public const string constEwalletTransactionCode_EwalletPurchasePayment_Out = "EwalletPurchasePayment_Out";
        public const string constEwalletTransactionCode_EwalletBonusPayout_In = "EwalletBonusPayout_In";
        public const string constEwalletTransactionCode_EwalletBonusPayoutReverse_Out = "EwalletBonusPayoutReverse_Out";
        public const string constEwalletTransactionCode_EwalletWithdrawal_Out = "EwalletWithdrawal_Out";

        public const string constEwalletTransactionCode_EwalletWithdrawalRefund_In = "EwalletWithdrawalRefund_In";
        public const string constSalesTransactionCode_DistributorRegistrationSales = "DistributorRegistrationSales";
        public const string constSalesTransactionCode_DistributorUpgradeSales = "DistributorUpgradeSales";
        public const string constSalesTransactionCode_DistributorMaintenanceSales = "DistributorMaintenanceSales";
        public const string constSalesTransactionCode_DistributorRedemptionSales = "DistributorRedemptionSales";
        public const string constSalesTransactionCode_DistributorAutoshipSales = "DistributorAutoshipSales";
        public const string constSalesTransactionCode_DistributorRepeatSales = "DistributorRepeatSales";

        public const string constSalesTransactionCode_DistributorRenewSales = "DistributorRenewSales";
        public const string constSalesTransactionCode_DistributorSalesReturn = "DistributorSalesReturn";
        public const string constSalesTransactionCode_DistributorMobileSales = "DistributorMobileSales";
        public const string constSalesTransactionCode_DistributorMobileOrder = "DistributorMobileOrder";
        public const string constSalesTransactionCode_DistributorMobileOrderReturn = "DistributorMobileOrderReturn";
        public const string constSalesTransactionCode_DistributorOnlineSales = "DistributorOnlineSales";
        public const string constSalesTransactionCode_DistributorOnlineRedemptionSales = "DistributorOnlineRedemptionSales";
        public const string constSalesTransactionCode_StockistConsignment = "StockistConsignment";
        public const string constSalesTransactionCode_StockistReplenishment = "StockistReplenishment";
        public const string constSalesTransactionCode_StockistConsignmentReturn = "StockistConsignmentReturn";
        public const string constSalesTransactionCode_StockistReplenishmentReturn = "StockistReplenishmentReturn";
        public const string constSalesTransactionCode_DeliveryOrder = "DeliveryOrder";
        public const string constSalesTransactionCode_DeliveryBackOrder = "DeliveryBackOrder";
        public const string constSalesTransactionCode_SalesSubmission = "SalesSubmission";
        public const string constSalesTransactionCode_SubmissionApproval = "SubmissionApproval";
        public const string constSalesTransactionCode_StockAdjustment_In = "StockAdjustment_In";
        public const string constSalesTransactionCode_StockAdjustment_Out = "StockAdjustment_Out";
        public const string constSalesTransactionCode_WarehouseTransfer_In = "WarehouseTransfer_In";

        public const string constSalesTransactionCode_WarehouseTransfer_Out = "WarehouseTransfer_Out";
        public const string constYesNoFlag_Yes = "Y";

        public const string constYesNoFlag_No = "N";
        public const bool constBooleanFlag_Yes = true;

        public const bool constBooleanFlag_No = false;
        public const string constLocationType_HQ = "HQ";
        public const string constLocationType_Stockist = "SK";
        public const string constLocationType_Warehouse = "WS";
        public const string constLocationType_Branch = "BR";

        public const string constLocationType_MobileStockist = "MS";
        public const string constComboBox_FormatString_Default = "{0} ({1})";
        public const string constComboBox_Delimiter = " - ";
        public const string constBlankCreatedDate = "-";
        public const string constRunningNumber_Delimiter = "-";

        public const string constDropdownEdit_Delimiter = ";";
        public const string constRankCode_AddNew = "new";
        public const string constRankCode_Invalid = "invalid";
        public const string constRankImage_AddNew = "register.jpg";
        public const string constRankImage_Invalid = "Invalid.jpg";
        public const string constRankImage_unknown = "unknown.jpg";
        public const string constRankImage_Inactive = "Inactive.jpg";
        public const string constRankImage_Suspend = "Suspend.jpg";
        public const string constRankImage_Terminated = "Terminated.jpg";

        public const string constRankImage_Pending = "Pending.jpg";

        public const string constProjectCode_ABO = "ABO";
        public const string constProjectCode_MBO = "MBO";
        public const string constProjectCode_SBO = "SBO";
        public const string constProjectCode_MSBO = "MSOMS";

        public const string constProjectCode_BROMS = "BROMS";
        public const string constStockAdjustmentType_InFlag = "I";

        public const string constStockAdjustmentType_OutFlag = "O";

        public const int constSleepTimeExpiryRenewal = 400000;
        public const int constPlacementPosition_Left = 1;
        public const int constPlacementPosition_Middle = 2;

        public const int constPlacementPosition_Right = 3;

        public const int constPlacementLeg_MaxPerDistributor = 2;

        public const int constWebTraffic_SearchType_Click = 1;

        public const int constWebTraffic_SearchType_IP = 2;

        public const int constPassword_MinLength = 6;
        public const int constLoginType_DistributorCode = 1;

        public const int constLoginType_UserName = 2;
        public const int constRankNameType_ShortName = 1;

        public const int constRankNameType_ByLanguage = 2;
        public const string constComboBoxFieldName_ComboBoxCode = "ComboBoxCode";
        public const string constComboBoxFieldName_ComboBoxValue = "ComboBoxValue";
        public const string constComboBoxFieldName_ComboBoxText = "ComboBoxText";

        public const string constComboBoxFieldName_ComboBoxImage = "ComboBoxImage";
        public const string constDevexpress_ErrorDisplayMode = "ImageWithText";
        public const bool constDevexpress_ValidateOnLeave = true;

        public const bool constDevexpress_SetFocusOnError = true;

        public const int constCaptcha_CodeLength = 5;
        public const string constKeyType_Login_PageAfterLogin_BSOMS = "PageAfterLoginBSOMS";
        public const string constKeyType_Login_PageAfterLogin_DIOMS = "PageAfterLoginDIOMS";
        public const string constKeyType_Login_PageAfterLogin_STOMS = "PageAfterLoginSTOMS";
        public const string constKeyType_Login_PageAfterLogin_BROMS = "PageAfterLoginBROMS";

        public const string constKeyType_Login_PageAfterLogin_MSOMS = "PageAfterLoginMSOMS";
        public const string constKeyType_Login_FailCountBlocking_BSOMS = "LoginFailCountBlockingBSOMS";
        public const string constKeyType_Login_FailCountBlocking_DIOMS = "LoginFailCountBlockingDIOMS";
        public const string constKeyType_Login_FailCountBlocking_STOMS = "LoginFailCountBlockingSTOMS";
        public const string constKeyType_Login_FailCountBlocking_BROMS = "LoginFailCountBlockingBROMS";

        public const string constKeyType_Login_FailCountBlocking_MSOMS = "LoginFailCountBlockingMSOMS";

        public const string constKeyType_Login_FailSuspendedMinute = "LoginFailSuspendedMinute";

        public const string constKeyType_LoginUserType_DIOMS = "LoginTypeDIOMS";

        public const string constKeyType_Export_Enabled = "ExportEnabled";
        public const string constKeyType_ComboBoxType_CountryAccessType = "CountryAccessType";
        public const string constKeyType_ComboBoxType_MasterDataStatus = "MasterDataStatus";
        public const string constKeyType_ComboBoxType_Export = "Export";
        public const string constKeyType_ComboBoxType_GridPageSize = "GridPageSize";
        public const string constKeyType_ComboBoxType_ProjectCode = "ProjectCode";
        //Public Const constKeyType_ComboBoxType_TransactionType As String = "TransactionType"
        public const string constKeyType_ComboBoxType_SalesOrderType = "SalesOrderType";

        public const string constKeyType_ComboBoxType_YesNo = "YesNo";

        public const string constKeyType_GridView_PageSize = "GridViewPageSize";
        public const string constKeyType_NetworkTree_RankNameType = "RankNameType";

        public const string constKeyType_NetworkTree_DistributorNameType = "DistributorNameType";

        //public const string constWebConfig_ProjectCode = "ProjectCode";
        //public const string constWebConfig_ErrorLog = "ErrorLog";

        public const string constWebConfig_UrlLink = "UrlLink";

        public const int constSystemDefault_GridViewPageSize = 10;

        public const string constSystemDefault_Language = "en-us";
        public const string constSessionID_LanguageCode = "languagecode";
        public const string constSessionID_UserCode = "UserCode";

        public const string constSessionID_DistributorGUID = "DistributorGUID";
        public const string constFileType_Xls = "xls";
        public const string constFileType_Xlsx = "xlsx";
        public const string constFileType_Pdf = "pdf";

        public const string constFileType_Rtf = "rtf";
        public const string constQueryString_FunctionCode = "fc";

        public const string constFolder_Modules = "Modules";

        public const string constPage_ContentName = "DisplayContentPage";

        public const string constGridLookup_KeyField_Distributor = "DistributorGUID";

        public const int constSQLCommandTimeout = 6000000;

        public const int constLoginFailCount_Default_Max = 999;
        public const string constMessageBox_Error = "Error";
        public const string constMessageBox_Warning = "Warning";
        public const string constMessageBox_Success = "Success";
        public const string constMessageBox_Info = "Info";

        //Placement Network Movement------Created by Matthew Ting 20121204
        public const string constPlacementNetworkMoveToTop = "MT";
        public const string constPlacementNetworkMoveUpOneLevel = "MU";
        public const string constPlacementNetworkMoveFarLeft = "ML";
        public const string constPlacementNetworkMoveFarRight = "MR";

        public const string constPlacementNetworkDropDown = "DD";

        public const string constColumnSetting_DisplayLocation_GridView = "GridView";

        public const int constChangeType_Password = 1;
        public const int constChangeType_Epin = 2;

        //public const string constXmlString_StartTableNode = "<xmlTable>";

        //public const string constXmlString_EndTableNode = "</xmlTable>";
        //public const string constXmlString_StartRowNode = "<xmlRow>";

        //public const string constXmlString_EndRowNode = "</xmlRow>";
        //Calander Properties
        public const int constCalanderProperties_Column = 2;
        //Date Type
        public const string constDateType_CurrentDate = "CurrentDate";
        public const string constDateType_CurrentMonthFirstDay = "CurrentMonthFirstDay";
        public const string constDateType_CurrentYearFirstDay = "CurrentYearFirstDay";
        public const string constDateType_CurrentYearEnd = "CurrentYearEnd";
        public const string constDateType_CurrentMonthEnd = "CurrentMonthEnd";
        public const string constDateType_StartFromFirstDay = "StartFromFirstDay";

        public const string constDateType_NoEndDate = "NoEndDate";
        public const string constCalenderPurposeType_StartDate = "StartDate";
        public const string constCalenderPurposeType_EndDate = "EndDate";

        public const string constCalenderPurposeType_SingleDate = "SingleDate";
        public const string constCountryAccessType_AllCountry = "AllCountry";

        public const string constCountryAccessType_OwnCountry = "OwnCountry";

        public const int constEditProfile_AllInfo = 0;
        public const int constEditProfile_PersonalInfo = 1;
        public const int constEditProfile_PaymentInfo = 2;

        // Add by Daniel 2015-07-15
        public const string constHtmlTableColumnType_LinkExternal = "LinkE";
        public const string constHtmlTableColumnType_LinkInternal = "LinkI";
        public const string constHtmlTableColumnType_Hide = "Hide";
        public const string constHtmlTableColumnType_HideLinkExternal = "HideLinkE";
        public const string constHtmlTableColumnType_HideLinkInternal = "HideLinkI";

        public const int constConfirmSalesStatus_Pending = 900;
        public const int constConfirmSalesStatus_Confirmed = 910;
        public const int constConfirmSalesStatus_Canceled = 999;

        public const string constFamilyRelation_Parent = "P";
        public const string constFamilyRelation_Spouse = "L";
        public const string constFamilyRelation_Sibling = "R";
        public const string constFamilyRelation_Son = "S";

        public const string constMessageBox_ConfirmButtonColor = "#DD6B55";

        public const string constMessageBoxType_Info = "info";
        public const string constMessageBoxTitle_Success = "Successful";
        public const string constMessageBoxType_Success = "success";
        public const string constMessageBoxTitle_Error = "Failed";
        public const string constMessageBoxType_Error = "error";

        public const string constLanguageField_InvalidException = "InvalidException";

        public const string constSalesOrderNo_DefaultPrefix = "SN";

        public const int constTRegistrationPin_PinTypeAdminPaid = 110;
        public const int constTRegistrationPin_PinTypeAdminFree = 120;
        public const int constTRegistrationPin_PinTypeAdminMarketingSupport = 130;
        public const int constTRegistrationPin_PinTypeMemberGateway = 140;
        public const int constTRegistrationPin_PinTypeMemberHalf = 150;
        public const int constTRegistrationPin_PinTypeMemberFullCompany = 160;
        public const int constTRegistrationPin_PinTypeMemberFullSignUp = 170;

        public const string constMDistributor_PaidTypePaid = "Paid";
        public const string constMDistributor_PaidTypeUnpaid = "Unpaid";
        public const string constMDistributor_PaidTypeSP = "SP";

        public const int constTRegistrationPin_StatusUsed = 930;
        public const int constTRegistrationPin_StatusUnused = 950;
        public const int constTRegistrationPin_StatusCancel = 999;

        public const string constMProduct_FreePackage = "P00";

        public const string constTSalesOrderPayment_PaymentCodeRegisterPin = "EPayPin";

        public const string constMFunctionMobileFlag_Yes = "Y";
        public const string constMFunctionMobileFlag_No = "N";

        public const string constEPayPinType_Free = "F"; // Free - ABO
        public const string constEPayPinType_Paid = "P"; // Paid - ABO
        public const string constEPayPinType_Company = "C"; // 100% Company Wallet - MBO
        public const string constEPayPinType_Marketing = "M"; // Marketing - ABO
        public const string constEPayPinType_HalfPin = "H"; // Paid by combination - MBO
        public const string constEPayPinType_Gateway = "G"; // Payment Gateway - MBO

        public const string constEPayPinTransferControl_Sponsor = "S";
        public const string constEPayPinTransferControl_Placement = "P";
        public const string constEPayPinTransferControl_SponsorOrPlacement = "SP";
        public const string constEPayPinTransferControl_OpenForAll = "O";

        public const string constDefaultCurrencyCode = "SystemDefaultCurrencyCode";

        public const int constSearchCompleteTimer = 500;
    }
}
