using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel;

namespace NorthwindServices
{
    public class ProductService : IProducts
    {
        public string GetProductName(int productID)
        {
            string productName = string.Empty;

            try
            {
                XDocument doc = XDocument.Load("C:\\products.xml");

                productName =
                    (from result in doc.Descendants("DocumentElement")
                    .Descendants("Products")
                     where result.Element("productID").Value == productID.ToString()
                     select result.Element("productname").Value)
                    .FirstOrDefault<string>();

                if (string.IsNullOrEmpty(productName))
                    throw new FaultException<ServiceException>(ExceptionManager.HandleException("Product ID does not exist in system."));   

            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceException>(ExceptionManager.HandleException(ex));
            }

            return productName;
        }
        
        public int GetProductQty(int productID)
        {   
            int ProductQty = 0;

            try
            {
                XDocument doc = XDocument.Load("C:\\products.xml");
                string strProductQty =
                    (from result in doc.Descendants("DocumentElement")
                    .Descendants("Products")
                     where result.Element("productID").Value == productID.ToString()
                     select result.Element("UnitsInStock").Value)
                    .FirstOrDefault<string>();

                if (string.IsNullOrEmpty(strProductQty))
                    throw new FaultException<ServiceException>(ExceptionManager.HandleException("Product ID does not exist in system."));   

                int.TryParse(strProductQty, out ProductQty);

            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceException>(ExceptionManager.HandleException(ex));
            }
            return ProductQty;
        }

        public string GetCategoryName(int productID)
        {
            string categoryName = string.Empty;
            try
            {
                XDocument doc = XDocument.Load("C:\\products.xml");

                categoryName =
                    (from result in doc.Descendants("DocumentElement")
                        .Descendants("Products")
                     where result.Element("productID").Value == productID.ToString()
                     select result.Element("CategoryName").Value)
                     .FirstOrDefault<string>();

                if (string.IsNullOrEmpty(categoryName))
                    throw new FaultException<ServiceException>(ExceptionManager.HandleException("Product ID does not exist in system."));   
            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceException>(ExceptionManager.HandleException(ex));
            }

            return categoryName;
        }
    }
}
