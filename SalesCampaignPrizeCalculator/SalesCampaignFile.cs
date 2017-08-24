﻿using SalesCampaignPrizeCalculator.Tools;
using System.IO;
using System.Linq;

namespace SalesCampaignPrizeCalculator
{
          public class SalesCampaignFile
          {
                    private string _filePath;
                    public SalesCampaignFile(string filePath)
                    {
                              this._filePath = filePath;
                    }

                    public string FirstLineOfFile()
                    {
                              return File.ReadLines(_filePath).First();
                    }

                    public bool IsFirstLineOfFileANumber()
                    {
                              return IsValueNumeric.IsNumeric(FirstLineOfFile());
                    }

                    public int NumberOfLinesInFile()
                    {
                              return File.ReadLines(_filePath).Count();
                    }

                    public int GetFileContents()
                    {
                              return File.ReadLines(_filePath).Count();
                    }

                    public bool IsCampaignDayValid()
                    {
                              if (IsFirstLineOfFileANumber())
                              {
                                        int row1 = int.Parse(FirstLineOfFile());
                                        if (row1 >= 1 && row1 <= 5000)
                                                  return true;
                                        else
                                                  return false;
                              }
                              else
                                        return false;
                    }

                    public bool IsNumberOfDailyOrdersValid()
                    {
                              string[] lines = System.IO.File.ReadAllLines(_filePath);
                              bool result = true;
                              for (int i = 1; i < lines.Length; i++)
                              {
                                        var array = lines[i].Split(' ');
                                        string column1 = array[0];
                                        if (IsValueNumeric.IsNumeric(column1))
                                        {
                                                  if (int.Parse(column1) < 0 || int.Parse(column1) > 100000)
                                                  {
                                                            result = false;
                                                            break;
                                                  }
                                        }
                                        else
                                        {
                                                  result = false;
                                                  break;
                                        }
                              }
                              return result;
                    }

                    public bool AreAllAmountsValid()
                    {
                              string[] lines = System.IO.File.ReadAllLines(_filePath);
                              bool result = true;
                              for (int i = 1; i < lines.Length; i++)
                              {
                                        var array = lines[i].Split(' ');
                                        
                                        for (int j = 1; j < array.Length; j++)
                                        {
                                                  if (IsValueNumeric.IsNumeric(array[j]))
                                                  {
                                                            if (int.Parse(array[j]) < 0 || int.Parse(array[j]) > 1000000)
                                                            {
                                                                      result = false;
                                                                      break;
                                                            }
                                                  }
                                                  else
                                                  {
                                                            result = false;
                                                            break;
                                                  }
                                        }
                              }
                              return result;
                    }

                    //more time needed to implement
                    //public static bool IsFileValid()
                    //{
                    //          //could build more logic
                    //          if (!string.IsNullOrWhiteSpace(_filePath) && IsFirstLineOfFileANumber())
                    //          {
                    //                    if (IsNumberOfDailyOrdersValid() && IsCampaignDayValid())
                    //                              return true;
                    //                    else
                    //                              return false;
                    //          }
                    //          return false;
                    //}
          }
}
