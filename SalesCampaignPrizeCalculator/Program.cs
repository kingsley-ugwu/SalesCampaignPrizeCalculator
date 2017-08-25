using System;
using System.Windows.Forms;

namespace SalesCampaignPrizeCalculator
{
          class Program
          {
                    [STAThread]
                    static void Main(string[] args)
                    {
                              //Calll a function to calculate the total prize given out from a text file
                              //Console.WriteLine(Calculator.TotalPrizeMoneyGivenOutFromTextFile());

                              //Calll a function to calculate the total prize given out from a text file
                              Console.WriteLine(Calculator.TotalPrizeMoneyGivenOutFromStandardInput());

                              Console.WriteLine("Press any key to exit."); // keep console window open
                              Console.ReadKey(); //Read any keyboard entry as request to exit the program
                    }
          }
}
