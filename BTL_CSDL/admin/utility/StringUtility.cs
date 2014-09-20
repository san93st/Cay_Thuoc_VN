using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_CSDL.admin.utility
{
    public class StringUtility
    {
        public static Boolean isNumber(String pvalue)
        {
            foreach (char c in pvalue)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}