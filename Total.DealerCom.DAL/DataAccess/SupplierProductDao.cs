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
    /// SupplierProductDao Domain Object
    /// </summary>
    public partial class SupplierProductDao
    {

        public static int Add(SupplierProduct supplierproduct)
        {

            var r = DataFacade.GetDataRow("SupplierProductInsert",
              new ParameterValue("SupplierID", supplierproduct.SupplierID),
              new ParameterValue("RetailBarcode", supplierproduct.RetailBarcode),
              new ParameterValue("RetailPackSize", supplierproduct.RetailPackSize),
              new ParameterValue("Ranging", supplierproduct.Ranging),
              new ParameterValue("OuterCaseCode", supplierproduct.OuterCaseCode),
              new ParameterValue("PackBarcode", supplierproduct.PackBarcode),
              new ParameterValue("ProductCode", supplierproduct.ProductCode),
              new ParameterValue("ProductDescription", supplierproduct.ProductDescription),
              new ParameterValue("ISISRetailItemNaming", supplierproduct.ISISRetailItemNaming),
              new ParameterValue("Category", supplierproduct.Category),
              new ParameterValue("Brand", supplierproduct.Brand),
              new ParameterValue("PackSizeCase", supplierproduct.PackSizeCase),
              new ParameterValue("UOMType", supplierproduct.UOMType),
              new ParameterValue("Cost", supplierproduct.Cost),
              new ParameterValue("CaseCost", supplierproduct.CaseCost),
              new ParameterValue("Archive", supplierproduct.Archive),
              new ParameterValue("CategoryManagerStatus", supplierproduct.CategoryManagerStatus),
              new ParameterValue("CategoryManagerStatusDate", supplierproduct.CategoryManagerStatusDate),
              new ParameterValue("CategoryManagerComment", supplierproduct.CategoryManagerComment),
              new ParameterValue("MasterDataComment", supplierproduct.MasterDataComment),
              new ParameterValue("MasterDataStatus", supplierproduct.MasterDataStatus),
             new ParameterValue("MasterDataStatusDate", supplierproduct.MasterDataStatusDate)

             );

            int SupplierProductID = Convert.ToInt32(r["SupplierProductID"]);
            return SupplierProductID;
        }

        public static int Update(SupplierProduct supplierproduct)
        {

            var r = DataFacade.GetDataRow("SupplierProductUpdate",
             new ParameterValue("SupplierProductID", supplierproduct.SupplierProductID),
              new ParameterValue("SupplierID", supplierproduct.SupplierID),
              new ParameterValue("RetailBarcode", supplierproduct.RetailBarcode),
              new ParameterValue("RetailPackSize", supplierproduct.RetailPackSize),
              new ParameterValue("Ranging", supplierproduct.Ranging),
              new ParameterValue("OuterCaseCode", supplierproduct.OuterCaseCode),
              new ParameterValue("PackBarcode", supplierproduct.PackBarcode),
              new ParameterValue("ProductCode", supplierproduct.ProductCode),
              new ParameterValue("ProductDescription", supplierproduct.ProductDescription),
              new ParameterValue("ISISRetailItemNaming", supplierproduct.ISISRetailItemNaming),
              new ParameterValue("Category", supplierproduct.Category),
              new ParameterValue("Brand", supplierproduct.Brand),
              new ParameterValue("PackSizeCase", supplierproduct.PackSizeCase),
              new ParameterValue("UOMType", supplierproduct.UOMType),
              new ParameterValue("Cost", supplierproduct.Cost),
              new ParameterValue("CaseCost", supplierproduct.CaseCost),
              new ParameterValue("CategoryManagerStatus", supplierproduct.CategoryManagerStatus),
              new ParameterValue("CategoryManagerStatusDate", supplierproduct.CategoryManagerStatusDate),
              new ParameterValue("MasterDataComment", supplierproduct.MasterDataComment),
              new ParameterValue("CategoryManagerComment", supplierproduct.CategoryManagerComment),
              new ParameterValue("MasterDataStatus", supplierproduct.MasterDataStatus),
             new ParameterValue("MasterDataStatusDate", supplierproduct.MasterDataStatusDate)
             );
            int SupplierProductID = Convert.ToInt32(r["SupplierProductID"]);
            return SupplierProductID;
        }

        public static SupplierProduct SupplierProductGet(int supplierproductid)
        {
            SupplierProduct supplierproduct = new SupplierProduct();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("SupplierProductID", supplierproductid));

            var r = DataFacade.GetDataRow("SupplierProductGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(supplierproduct, r);
            }
            return supplierproduct;
        }


        public static List<SupplierProduct> GetAll()
        {
            var paramList = new List<ParameterValue>();
            var dataTable = DataFacade.GetDataTable("SupplierProductGetAll",
                                        paramList.ToArray());

            var returnList = new List<SupplierProduct>();

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierProduct supplierproduct = new SupplierProduct();
                Populate(supplierproduct, r);
                returnList.Add(supplierproduct);

            }

            return returnList;
        }

        public static List<SupplierProduct> GetSupplierProducts(int supplierid)
        {

            var paramList = new List<ParameterValue>();
            paramList.Add(new ParameterValue("SupplierID", supplierid));
            var dataTable = DataFacade.GetDataTable("SupplierProductsGet",
                                          paramList.ToArray());
            var returnList = new List<SupplierProduct>();
            foreach (DataRow r in dataTable.Rows)
            {
                SupplierProduct supplierproduct = new SupplierProduct();
                Populate(supplierproduct, r);
                returnList.Add(supplierproduct);
            }
            return returnList;
        }


        private static SupplierProduct Populate(SupplierProduct supplierproduct, DataRow dr)
        {
            if (dr["SupplierProductID"] != DBNull.Value) supplierproduct.SupplierProductID = Convert.ToInt32(dr["SupplierProductID"]);
            if (dr["SupplierID"] != DBNull.Value) supplierproduct.SupplierID = Convert.ToInt32(dr["SupplierID"]);
            if (dr["RetailBarcode"] != DBNull.Value) supplierproduct.RetailBarcode = Convert.ToString(dr["RetailBarcode"]);
            if (dr["RetailPackSize"] != DBNull.Value) supplierproduct.RetailPackSize = Convert.ToString(dr["RetailPackSize"]);
            if (dr["Ranging"] != DBNull.Value) supplierproduct.Ranging = Convert.ToString(dr["Ranging"]);
            if (dr["OuterCaseCode"] != DBNull.Value) supplierproduct.OuterCaseCode = Convert.ToString(dr["OuterCaseCode"]);
            if (dr["PackBarcode"] != DBNull.Value) supplierproduct.PackBarcode = Convert.ToString(dr["PackBarcode"]);
            if (dr["ProductCode"] != DBNull.Value) supplierproduct.ProductCode = Convert.ToString(dr["ProductCode"]);
            if (dr["ProductDescription"] != DBNull.Value) supplierproduct.ProductDescription = Convert.ToString(dr["ProductDescription"]);
            if (dr["ISISRetailItemNaming"] != DBNull.Value) supplierproduct.ISISRetailItemNaming = Convert.ToString(dr["ISISRetailItemNaming"]);
            if (dr["Category"] != DBNull.Value) supplierproduct.Category = Convert.ToString(dr["Category"]);
            if (dr["Brand"] != DBNull.Value) supplierproduct.Brand = Convert.ToString(dr["Brand"]);
            if (dr["PackSizeCase"] != DBNull.Value) supplierproduct.PackSizeCase = Convert.ToInt32(dr["PackSizeCase"]);
            if (dr["UOMType"] != DBNull.Value) supplierproduct.UOMType = Convert.ToString(dr["UOMType"]);
            if (dr["Cost"] != DBNull.Value) supplierproduct.Cost = Convert.ToDecimal(dr["Cost"]);
            if (dr["CaseCost"] != DBNull.Value) supplierproduct.CaseCost = Convert.ToDecimal(dr["CaseCost"]);
            if (dr["Archive"] != DBNull.Value) supplierproduct.Archive = Convert.ToBoolean(dr["Archive"]);
            if (dr["CategoryManagerStatus"] != DBNull.Value) supplierproduct.CategoryManagerStatus = Convert.ToString(dr["CategoryManagerStatus"]);
            if (dr["CategoryManagerStatusDate"] != DBNull.Value) supplierproduct.CategoryManagerStatusDate = Convert.ToDateTime(dr["CategoryManagerStatusDate"]);
            if (dr["DateCreated"] != DBNull.Value) supplierproduct.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
            if (dr["CategoryManagerComment"] != DBNull.Value) supplierproduct.CategoryManagerComment = Convert.ToString(dr["CategoryManagerComment"]);
            if (dr["MasterDataComment"] != DBNull.Value) supplierproduct.MasterDataComment = Convert.ToString(dr["MasterDataComment"]);
            if (dr["MasterDataStatus"] != DBNull.Value) supplierproduct.MasterDataStatus = Convert.ToString(dr["MasterDataStatus"]);
            if (dr["MasterDataStatusDate"] != DBNull.Value) supplierproduct.MasterDataStatusDate = Convert.ToDateTime(dr["MasterDataStatusDate"]);
            return supplierproduct;
        }

    }

}



