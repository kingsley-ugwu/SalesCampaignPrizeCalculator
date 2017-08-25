using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SalesCampaignPrizeCalculator.Tools;
using System.Collections.Generic;

namespace SalesCampaignPrizeCalculator.Tests
{
          [TestClass]
          public class SalesCampaignPrizeCalculatorFixture
          {
                    string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170824_SalesCampaignFile.txt";

                    [TestMethod]
                    public void CheckThatFileExists()
                    {
                              //arrange - structure of what to test
                              bool expected = true;

                              //act - make the call to the operations we are trying to assert
                              bool actual = File.Exists(filePath);

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    [TestMethod]
                    public void CheckThatFileDoesNotExists()
                    {
                              //arrange - structure of what to test
                              string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170825_SalesCampaignFile.txt";
                              bool expected = false;

                              //act - make the call to the operations we are trying to assert
                              bool actual = File.Exists(filePath);

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    [TestMethod]
                    public void CheckThatFirstLineOfFileIsANumber()
                    {
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              bool expected = true;

                              //act - make the call to the operations we are trying to assert
                              bool actual = systemUnderTest.IsFirstLineOfFileANumber();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }
                    
                    [TestMethod]
                    public void CheckCampaignDayIsNotValidIfLessThanOne()
                    {
                              string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170824_SalesCampaignFile_Wrong_FirstLineLessThanOne.txt";
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              bool expected = false;

                              //act - make the call to the operations we are trying to assert
                              bool actual = systemUnderTest.IsCampaignDayValid();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }


                    [TestMethod]
                    public void CheckCampaignDayIsNotValidIfGreaterThanFiveThousand()
                    {
                              string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170824_SalesCampaignFile_Wrong_FirstLineOver5000.txt";
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              bool expected = false;

                              //act - make the call to the operations we are trying to assert
                              bool actual = systemUnderTest.IsCampaignDayValid();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    [TestMethod]
                    public void CheckTotalNumberOfDailyOrdersDoesNotExceedOneHundredThousand()
                    {
                              string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170824_SalesCampaignFile_Wrong_NumberOfOrdersDayOneOverOneHundredThousand.txt";
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              bool expected = false;

                              //act - make the call to the operations we are trying to assert
                              bool actual = systemUnderTest.IsNumberOfDailyOrdersValid();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    [TestMethod]
                    public void CheckThatNoAmountExceedsOneMillion()
                    {
                              string filePath = @"C:\Users\Kingsley\Documents\Visual Studio 2015\Projects\SalesCampaignPrizeCalculator\SalesCampaignPrizeCalculator\20170824_SalesCampaignFile_Wrong_AmountExceedsAMillion.txt";
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              bool expected = false;

                              //act - make the call to the operations we are trying to assert
                              bool actual = systemUnderTest.AreAllAmountsValid();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    //[TestMethod]
                    //public void CheckTotalOrdersPlacedNotOverAMillion()
                    //{
                    //          //arrange - structure of what to test
                    //          string filePath = @"C:\TEMP\test.txt";
                    //          bool expected = false;

                    //          //act - make the call to the operations we are trying to assert
                    //          int actual = Calculator.TotalPrizeMoneyGivenOut(filePath);

                    //          //assert - assert the results
                    //          Assert.AreEqual(expected, actual);
                    //}

                    [TestMethod]
                    public void CheckThatFileContainsRightNumberOfRows()
                    {
                              //arrange - structure of what to test
                              var systemUnderTest = new SalesCampaignFile(filePath);
                              int expected = 6; 

                              //act - make the call to the operations we are trying to assert
                              int actual = systemUnderTest.NumberOfLinesInFile();

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }

                    [TestMethod]
                    public void CalculateTotalPrizeGivenOutUsingExampleGivenUsingTextFile()
                    {
                              //arrange - structure of what to test
                              int expected = 19;

                              //act - make the call to the operations we are trying to assert
                              int actual = Calculator.TotalPrizeMoneyGivenOutFromTextFile(filePath);

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }


                    [TestMethod]
                    public void CalculateTotalPrizeGivenOutUsingExampleFromStandardInput()
                    {
                              //arrange - structure of what to test
                              List<string> lines = new List<string>(); ;
                              lines.Add("3 1 2 3");
                              lines.Add("2 1 1");
                              lines.Add("4 10 5 5 1");
                              lines.Add("0");
                              lines.Add("1 2");
                              int expected = 19;

                              //act - make the call to the operations we are trying to assert
                              int actual = Calculator.TotalPrizeMoneyGivenOutFromStandardInput(lines);

                              //assert - assert the results
                              Assert.AreEqual(expected, actual);
                    }
          }
}
