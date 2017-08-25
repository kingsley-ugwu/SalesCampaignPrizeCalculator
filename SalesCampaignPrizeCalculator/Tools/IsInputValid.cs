using System.Collections.Generic;

namespace SalesCampaignPrizeCalculator.Tools
{
          public class IsInputValid
          {
                    public static bool IsNumberOfDaysValid(string s)
                    {
                              if (!IsValueNumeric.IsNumeric(s))
                                        return false;

                              int numOfDays = int.Parse(s);
                              if (numOfDays >= (int)NumberOfDays.MinimumNumberOfDays && numOfDays <= (int)NumberOfDays.MaximumNumberOfDays)
                                        return true;
                              else
                                        return false;
                    }

                    public static bool IsNumberOfOrdersValid(string s)
                    {
                              var x = s.Split(' ');
                              if (!IsValueNumeric.IsNumeric(x[0]))
                                        return false;

                              if (int.Parse(x[0]) < (int)NumberOfDailyOrders.Minimum || int.Parse(x[0]) > (int)NumberOfDailyOrders.Maximum)
                                        return false;
                              else
                                        return true;
                    }

                    public static bool IsAmountValid(string s)
                    {
                              var x = s.Split(' ');
                              if (!IsValueNumeric.IsNumeric(x[0]))
                                        return false;

                              if (int.Parse(x[0]) < (int)AmountOfEachOrder.Minimum || int.Parse(x[0]) > (int)AmountOfEachOrder.Maximum)
                                        return false;
                              else
                                        return true;
                    }

                    public static void TotalNumberOfOrdersValid(List<string> ls)
                    {
                              //....requires implementation
                    }
          }
}
