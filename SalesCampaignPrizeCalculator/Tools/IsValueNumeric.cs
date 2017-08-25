using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCampaignPrizeCalculator.Tools
{
          public class IsValueNumeric
          {
                    public static bool IsNumeric(object value)
                    {
                              try
                              {
                                        int i = Convert.ToInt32(value.ToString());
                                        return true;
                              }
                              catch (FormatException)
                              {
                                        return false;
                              }
                    }
          }
}
