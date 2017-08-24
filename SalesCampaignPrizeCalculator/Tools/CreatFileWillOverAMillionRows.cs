using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCampaignPrizeCalculator.Tools
{
          public class CreatFileWillOverAMillionRows
          {
                    public static void CreateFile()
                    {
                              string path = @"C:\TEMP\test.txt";
                              int i = 0;

                              using (var writer = new StreamWriter(path))
                              {
                                        while (i < 1000002)
                                        {
                                                  writer.WriteLine(i);
                                        }
                              }
                    }
          }
}
