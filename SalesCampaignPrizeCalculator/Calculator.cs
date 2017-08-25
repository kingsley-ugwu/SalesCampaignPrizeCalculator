using System;
using System.Collections.Generic;
using System.Linq;
using SalesCampaignPrizeCalculator.Tools;
using System.Windows.Forms;

namespace SalesCampaignPrizeCalculator
{
          public class Calculator
          {
                    /*
                     * Business logic for calculating sales campaign prize
                              •	Every order that is placed is automatically entered into the draw
                              •	At the end of every day, two orders are selected from all those entered into the draw
                              •	Firstly, the order for the largest amount is selected
                              •	Secondly, the order for the smallest amount is selected
                              •	The customer who placed the largest order receives prize money equal to the amount of their order less the amount of the smallest order
                              •	The two selected orders are removed from the draw
                              •	All other orders remain eligible for draws on subsequent days
                    */

                    public static int TotalPrizeMoneyGivenOutFromStandardInput()
                    {
                              //Console.Write("Please enter the number of days for the campaign: "); 
                              string input = Console.ReadLine(); // Get input fromthe user as a string
                              while (!IsValueNumeric.IsNumeric(input)) //Check that the input is numeric
                              {
                                        Console.Write("Only numbers are accepted, try again: ");
                                        input = Console.ReadLine();
                              }

                              //Check that the number of days is valid
                              while (int.Parse(input) < (int)NumberOfDays.MinimumNumberOfDays || int.Parse(input) > (int)NumberOfDays.MaximumNumberOfDays) //Check that the input is numeric
                              {
                                        Console.Write("Valid umbers are between {0} and {1} inclusive: ", (int)NumberOfDays.MinimumNumberOfDays, (int)NumberOfDays.MaximumNumberOfDays);
                                        input = Console.ReadLine();
                              }

                              int numOfDays = int.Parse(input); //store the number of days in rder to control the prompts

                              var lines = new List<string>(); //Store all lines entered by the user
                              for (int i = 0; i < numOfDays; i++)
                              {
                                        //Console.Write("Please enter the data for day {0}: ", i + 1); 
                                        lines.Add(Console.ReadLine());

                                        //more checks need to ensure that input is valid ...caling functions in the IsInoutValid class
                              }

                              return CalculateTotalPrizeMoneyGivenOut(lines, 0); //return total prize money given out
                    }

                    public static int TotalPrizeMoneyGivenOutFromStandardInput(List<string> lines)
                    {
                              return CalculateTotalPrizeMoneyGivenOut(lines, 0); //return total prize money given out
                    }

                    public static int TotalPrizeMoneyGivenOutFromTextFile()
                    {
                              //Get the user to select the file
                              OpenFileDialog fileDilalog = new OpenFileDialog { Multiselect = false, Title = "Select the Sales Campign File To Calulate", Filter = "Text Files |*.csv;*.txt" };
                              fileDilalog.ShowDialog();
                              string filePath = fileDilalog.FileName;

                              #region FutureEnhancements
                              //First Check that the file is valid
                              //if(SalesCampaignFile.IsFileValid())
                              //{ 
                              #endregion

                              //Read the lines from the selected file
                              List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                              return CalculateTotalPrizeMoneyGivenOut(lines, 1); //return total prize money given out
                    }

                    public static int TotalPrizeMoneyGivenOutFromTextFile(string filePath)
                    {
                              #region FutureEnhancements
                              //First Check that the file is valid
                              //if(SalesCampaignFile.IsFileValid())
                              //{ 
                              #endregion

                              //Read the lines from the selected file
                              List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                              return CalculateTotalPrizeMoneyGivenOut(lines, 1); //return total prize money given out
                    }

                    private static int CalculateTotalPrizeMoneyGivenOut(List<string> lines, int startAt)
                    {
                              int totalPaid = 0; //store cummulative total monies given out
                              List<string> combinedList = new List<string>(); //maintain a cummulative list of orders excluding customers who placed the largest orders

                              //loop through the lines in the file provided and apply business logic (above)
                              for (int i = startAt; i < lines.Count; i++)
                              {
                                        var array = lines[i].Split(' '); //convert line into an array

                                        var foos = new List<string>(array); //convert the array into a list so that we can use the RemoveAt function 

                                        foos.RemoveAt(0); //Remove the first number as it denotes the total number of orders for the day

                                        combinedList.AddRange(foos); //maintain a list of remianing orders as they are eligible for draws on subsequent days

                                        int maxNumberOfDigits = combinedList.Max(x => x.Length); //get the maximum number of digits
                                        combinedList = combinedList.OrderBy(x => x.PadLeft(maxNumberOfDigits, '0')).ToList(); //sort the array by padding with zeros because numbers are stored as text. The highest number will be the last and the lowest the first

                                        var highestNumber = int.Parse(combinedList[combinedList.Count - 1]); //get the highest number from the array
                                        var lowestNumber = int.Parse(combinedList[0]); //get the lowest number from the array

                                        totalPaid += highestNumber - lowestNumber; //maintain a running total of the amount paid out i.e. amount paid out = highest order minus smallest order

                                        combinedList.RemoveAt(combinedList.Count - 1); //remove the highest number from the list
                                        combinedList.RemoveAt(0); //remove the lowest number from the list

                              }

                              return totalPaid;
                    }
          }
}
