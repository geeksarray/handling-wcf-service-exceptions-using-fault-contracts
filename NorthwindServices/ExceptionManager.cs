using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NorthwindServices
{
    public sealed class ExceptionManager
    {
        /// <summary>
        /// Private Constructor to ensure that the class cannot be instantiated
        /// </summary>
        private ExceptionManager()
        {

        }

        public static ServiceException HandleException(string message)
        {
            return HandleException(message, false);
        }

        public static ServiceException HandleException(string message, bool isCritical)
        {
            ServiceException exception = new ServiceException();
            exception.Message = message;
            exception.IsCritical = isCritical;

            // Log exception details if it is critical

            return exception;
        }

        public static ServiceException HandleException(System.Exception ex)
        {
            ServiceException exception = new ServiceException();
            exception.Message = ex.Message;
            exception.IsCritical = IsCritical(ex);

            // Log exception details if it is critical

            return exception;
        }

        /// <summary>
        /// If error is not user defined then IsCritical should be true.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>returns true if exception is not user defined</returns>
        private static bool IsCritical(System.Exception ex)
        {
            bool returnValue = true;
            if (ex is SqlException)
            {
                SqlException sqlEx = (SqlException)ex;
                returnValue = sqlEx.Number > 50000 ? false : true;
            }
            return returnValue;
        }

        public static bool HandleException(System.Exception ex, string policyName)
        {
            throw new NotImplementedException();
        }
    }
}
