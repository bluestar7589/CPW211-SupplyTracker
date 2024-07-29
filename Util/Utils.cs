using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Util
{
    public static class Utils
    {
        /// <summary>
        /// This method will check the range between dateFrom and dateTo
        /// It will return true if the dateFrom less than or equal dateTo. Otherwise return false
        /// </summary>
        /// <param name="strDateFrom">From Date</param>
        /// <param name="strDateTo">To Date</param>
        /// <returns>Return true if dateFrom less than or equal dateTo, otherwise return false</returns>
        public static bool IsValidRangeDate(string strDateFrom, string strDateTo)
        {
            DateTime dateFrom = DateTime.Parse(strDateFrom);
            DateTime dateTo = DateTime.Parse(strDateTo);
            if (dateFrom > dateTo)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method will check if the string is a number or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return true if it is a number, otherwise return false.</returns>
        public static Boolean IsPositiveNumber(string str)
        {
            return double.TryParse(str, out _);
        }
        
    }
}
