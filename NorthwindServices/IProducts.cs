using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace NorthwindServices
{
    [ServiceContract]
    public interface IProducts
    {
        [OperationContract]
        [FaultContract(typeof(ServiceException))]
        string GetProductName(int productID);

        [OperationContract]
        [FaultContract(typeof(ServiceException))]
        int GetProductQty(int productID);

        [OperationContract]
        [FaultContract(typeof(ServiceException))]
        string GetCategoryName(int productID);
    }
}
