using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// SupplierProductStagingDao Domain Object
    /// </summary>
    public partial class SupplierProductStagingDao
    {

        public static int Add(SupplierProductStaging supplierproductstaging)
        {

            var r = DataFacade.GetDataRow("SupplierProductStagingInsert",

              new ParameterValue("SupplierID", supplierproductstaging.SupplierID),
              new ParameterValue("RetailBarcode", supplierproductstaging.RetailBarcode),
              new ParameterValue("RetailPackSize", supplierproductstaging.RetailPackSize),
              new ParameterValue("Ranging", supplierproductstaging.Ranging),
              new ParameterValue("OuterCaseCode", supplierproductstaging.OuterCaseCode),
              new ParameterValue("PackBarcode", supplierproductstaging.PackBarcode),
              new ParameterValue("ProductCode", supplierproductstaging.ProductCode),
              new ParameterValue("ProductDescription", supplierproductstaging.ProductDescription),
              new ParameterValue("ISISRetailItemNaming", supplierproductstaging.ISISRetailItemNaming),
              new ParameterValue("Category", supplierproductstaging.Category),
              new ParameterValue("Brand", supplierproductstaging.Brand),
              new ParameterValue("PackSizeCase", supplierproductstaging.PackSizeCase),
              new ParameterValue("UOMType", supplierproductstaging.UOMType),
              new ParameterValue("Cost", supplierproductstaging.Cost),
              new ParameterValue("CaseCost", supplierproductstaging.CaseCost)
             );

            return Convert.ToInt32(r["SupplierProductID"]);
        }

        public static int Update(SupplierProductStaging supplierproductstaging)
        {

            var r = DataFacade.GetDataRow("SupplierProductStagingUpdate",
             new ParameterValue("SupplierProductID", supplierproductstaging.SupplierProductID),
               new ParameterValue("RetailBarcode", supplierproductstaging.RetailBarcode),
              new ParameterValue("RetailPackSize", supplierproductstaging.RetailPackSize),
              new ParameterValue("Ranging", supplierproductstaging.Ranging),
              new ParameterValue("OuterCaseCode", supplierproductstaging.OuterCaseCode),
              new ParameterValue("PackBarcode", supplierproductstaging.PackBarcode),
              new ParameterValue("ProductCode", supplierproductstaging.ProductCode),
              new ParameterValue("ProductDescription", supplierproductstaging.ProductDescription),
              new ParameterValue("ISISRetailItemNaming", supplierproductstaging.ISISRetailItemNaming),
              new ParameterValue("Category", supplierproductstaging.Category),
              new ParameterValue("Brand", supplierproductstaging.Brand),
              new ParameterValue("PackSizeCase", supplierproductstaging.PackSizeCase),
              new ParameterValue("UOMType", supplierproductstaging.UOMType),
              new ParameterValue("Cost", supplierproductstaging.Cost),
              new ParameterValue("CaseCost", supplierproductstaging.CaseCost)

             );

            return Convert.ToInt32(r["SupplierProductID"]);

        }

        public static SupplierProductStaging SupplierProductStagingGet(int supplierproductid)
        {
            SupplierProductStaging supplierproductstaging = new SupplierProductStaging();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("SupplierProductID", supplierproductid));

            var r = DataFacade.GetDataRow("SupplierProductStagingGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(supplierproductstaging, r);
            }
            return supplierproductstaging;
        }

        public static List<SupplierProductStaging> GetSupplierProducts(int supplierid)
        {
          
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("SupplierID", supplierid));

            var dataTable = DataFacade.GetDataTable("SupplierProductsStagingGet",
                                          paramList.ToArray());
            var returnList = new List<SupplierProductStaging>();

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierProductStaging supplierproductstaging = new SupplierProductStaging();
                Populate(supplierproductstaging, r);
                returnList.Add(supplierproductstaging);
            }
            return returnList;
        }

        public static List<SupplierProductStaging> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("SupplierProductStagingGetAll",
                                                    paramList.ToArray());

            var returnList = new List<SupplierProductStaging>();

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierProductStaging supplierproductstaging = new SupplierProductStaging();

                Populate(supplierproductstaging, r);

                returnList.Add(supplierproductstaging);

            }

            return returnList;
        }

        public static int SaveToFinal(int stagingsupplierID, int supplierid)
        {
            var r = DataFacade.GetDataRow("SupplierProductStagingSaveToFinal",
                                        new ParameterValue("StagingSupplierID", stagingsupplierID)
                                        , new ParameterValue("SupplierID", supplierid));

            return Convert.ToInt32(r["SupplierProductID"]);
        }

        public static void Delete(int supplierid)
        {
            DataFacade.ExecuteNonQuery("SupplierProductStagingDelete",
                                        new ParameterValue("SupplierID", supplierid));
        }

        public static void DeleteProduct(int supplierproductid)
        {
            DataFacade.ExecuteNonQuery("SupplierProductStagingDeleteProduct",
                                        new ParameterValue("SupplierProductID", supplierproductid));
        }

        public static List<SupplierProductStaging> CheckProducts(int requesterid)
        {
            SupplierProductStaging supplierproductstaging = new SupplierProductStaging();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("RequesterID", requesterid));

            var dataTable = DataFacade.GetDataTable("RequesterStagingCheckProducts",
                                          paramList.ToArray());
            var returnList = new List<SupplierProductStaging>();

            foreach (DataRow r in dataTable.Rows)
            {
                Populate(supplierproductstaging, r);
                returnList.Add(supplierproductstaging);
            }
            return returnList;
        }

        private static SupplierProductStaging Populate(SupplierProductStaging supplierproductstaging, DataRow dr)
        {
            if (dr["SupplierProductID"] != DBNull.Value) supplierproductstaging.SupplierProductID = Convert.ToInt32(dr["SupplierProductID"]);

            if (dr["SupplierID"] != DBNull.Value) supplierproductstaging.SupplierID = Convert.ToInt32(dr["SupplierID"]);

            if (dr["RetailBarcode"] != DBNull.Value) supplierproductstaging.RetailBarcode = Convert.ToString(dr["RetailBarcode"]);

            if (dr["RetailPackSize"] != DBNull.Value) supplierproductstaging.RetailPackSize = Convert.ToString(dr["RetailPackSize"]);

            if (dr["Ranging"] != DBNull.Value) supplierproductstaging.Ranging = Convert.ToString(dr["Ranging"]);

            if (dr["OuterCaseCode"] != DBNull.Value) supplierproductstaging.OuterCaseCode = Convert.ToString(dr["OuterCaseCode"]);

            if (dr["PackBarcode"] != DBNull.Value) supplierproductstaging.PackBarcode = Convert.ToString(dr["PackBarcode"]);

            if (dr["ProductCode"] != DBNull.Value) supplierproductstaging.ProductCode = Convert.ToString(dr["ProductCode"]);

            if (dr["ProductDescription"] != DBNull.Value) supplierproductstaging.ProductDescription = Convert.ToString(dr["ProductDescription"]);

            if (dr["ISISRetailItemNaming"] != DBNull.Value) supplierproductstaging.ISISRetailItemNaming = Convert.ToString(dr["ISISRetailItemNaming"]);

            if (dr["Category"] != DBNull.Value) supplierproductstaging.Category = Convert.ToString(dr["Category"]);

            if (dr["Brand"] != DBNull.Value) supplierproductstaging.Brand = Convert.ToString(dr["Brand"]);

            if (dr["PackSizeCase"] != DBNull.Value) supplierproductstaging.PackSizeCase = Convert.ToInt32(dr["PackSizeCase"]);

            if (dr["UOMType"] != DBNull.Value) supplierproductstaging.UOMType = Convert.ToString(dr["UOMType"]);

            if (dr["Cost"] != DBNull.Value) supplierproductstaging.Cost = Convert.ToDecimal(dr["Cost"]);

            if (dr["CaseCost"] != DBNull.Value) supplierproductstaging.CaseCost = Convert.ToDecimal(dr["CaseCost"]);

            if (dr["Archive"] != DBNull.Value) supplierproductstaging.Archive = Convert.ToBoolean(dr["Archive"]);

            return supplierproductstaging;
        }

    }

}



