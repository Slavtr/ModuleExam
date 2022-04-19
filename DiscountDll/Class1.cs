using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountDll
{
    public static class DiscountCount
    {
        public static string CalculateDiscount(List<double> prices, string cost)
        {
            int ret = 0;
            if (prices.Count >= 3)
            {
                ret = 5;
            }
            if (prices.Count >= 5)
            {
                ret = 10;
            }
            if (prices.Count >= 10)
            {
                ret = 15;
            }
            ret += Convert.ToInt32(Convert.ToDouble(cost) / 500);
            return ret.ToString();
        }
    }
}
