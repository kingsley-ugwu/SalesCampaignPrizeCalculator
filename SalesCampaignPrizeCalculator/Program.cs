using System;
using System.Windows.Forms;

namespace SalesCampaignPrizeCalculator
{
          class Program
          {
                    [STAThread]
                    static void Main(string[] args)
                    {
                              //Get the user to select the file
                              OpenFileDialog fileDilalog = new OpenFileDialog { Multiselect = false, Title = "Select the Sales Campign File To Calulate", Filter = "Text Files |*.csv;*.txt" };
                              fileDilalog.ShowDialog();

                              //Calll a function to calculate the total prize given out
                              Console.WriteLine(Calculator.TotalPrizeMoneyGivenOut(fileDilalog.FileName));

                              Console.WriteLine("Press any key to exit."); // keep console window open
                              System.Console.ReadKey(); //Read any keyboard entry as request to exit the program
                    }
          }
}
