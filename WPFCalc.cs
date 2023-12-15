using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace WPFCalculator
{
    [TestClass]
    public class wpfcalc
    {
        System.Diagnostics.Process winAppDriverProcess;
        AppiumOptions options;
        WindowsDriver<WindowsElement> WPFCalc;

        [TestInitialize]
        public void Initialize()
        {
            // Initiate WinAppDriver
            winAppDriverProcess = System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe");

            // Launch Caliculator 
            options = new AppiumOptions();

            options.AddAdditionalCapability("app", @"C:\gmTestBed\WPFCalculator\proj_csh\deploy\Calculator\bin\Calculator.exe"); // WPF Calculator
            
            WPFCalc = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            //Thread.Sleep(1000);
        }
        
        [TestMethod]
        public void addition()
        {
            //Additon
            WPFCalc.FindElementByName("7").Click();
            WPFCalc.FindElementByName("+").Click();

            Thread.Sleep(2000);
            WPFCalc.FindElementByName("2").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("=").Click();
            Thread.Sleep(2000);

            string equal = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Results-Addition: {0}", equal);

            Thread.Sleep(2000);

            WPFCalc.Close();
        }


        [TestMethod]
        public void substraction()
        {
            //Subtraction
            WPFCalc.FindElementByName("7").Click();
            WPFCalc.FindElementByName("-").Click();

            Thread.Sleep(2000);
            WPFCalc.FindElementByName("2").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("=").Click();
            Thread.Sleep(2000);

            string sub = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Results-Substraction: {0}", sub);

            Thread.Sleep(2000);

            WPFCalc.Close();

        }

        [TestMethod]
        public void multiply()
        {
            // Multiply 
            WPFCalc.FindElementByName("7").Click();
            WPFCalc.FindElementByName("*").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("2").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("=").Click();

            var mult = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Multiply: {0}", mult);

            WPFCalc.Close();
        }

        [TestMethod]
        public void divison()
        {
            // Division caliculation
            WPFCalc.FindElementByName("7").Click();
            WPFCalc.FindElementByName("/").Click();
            WPFCalc.FindElementByName("2").Click();
            WPFCalc.FindElementByName("=").Click();


            var divi = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Division: {0}", divi);

            WPFCalc.Close();


        }

        [TestMethod]
        public void sqr()
        {
            // Sqr caliculation
            Thread.Sleep(1000);
            WPFCalc.FindElementByName("9").Click();
            var inp = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            WPFCalc.FindElementByName("Sqrt").Click();
            var sqr = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Sqr of {0} = {1}", inp, sqr);

            var asqr = "3";

            if (sqr.Contains(asqr))
            {
                Console.WriteLine(" Results Match - Test Pass");

            }
            else
            {
                Console.WriteLine("Results unMatch - Test Fail");

            }

            WPFCalc.Close();

        }

        [TestMethod]
        public void title()
        {
            //fetch the header name and edit 
            string menu = WPFCalc.FindElementByName("Calculator").Text;
            Console.WriteLine("Title of cals = {0}", menu);
            Thread.Sleep(3000);
            string edt = WPFCalc.FindElementByName("Edit").Text;
            Thread.Sleep(3000);
            Console.WriteLine("Title of cals = {0}", edt);

            WPFCalc.Close();



        }

        [TestMethod]
        public void EditMenu()
        {
            // Copy and paste from edit menu options 
            WPFCalc.FindElementByName("3").Click();
            var cpinput = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            WPFCalc.FindElementByName("Edit").Click();
            WPFCalc.FindElementByName("Copy").Click(); // copy the data
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("C").Click();  // clear the dislay field
            WPFCalc.FindElementByName("Edit").Click();
            WPFCalc.FindElementByName("Paste").Click(); // Paste the data from copy
            Thread.Sleep(1000);

            var cp = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            if (cp.Contains(cpinput))
            {
                Console.WriteLine("Results Matched {0} = {1}", cpinput, cp);
            }
            else
            {
                Console.WriteLine("Results UnMacthed {0} = {1}", cpinput, cp);
            }


            WPFCalc.Close();
        }

        [TestMethod]
        public void Percenage()
        {
            // Percentage caliculation
            WPFCalc.FindElementByName("5").Click();
            var perinput = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;


            WPFCalc.FindElementByName("%").Click();
            Thread.Sleep(1000);

            var perc = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Console.WriteLine("Percentage of {0} = {1}", perinput, perc);

            WPFCalc.Close();

        }

        [TestMethod]
        public void Back()
        {

            // Back option
            WPFCalc.FindElementByName("7").Click();
            var gettxtbefore = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            WPFCalc.FindElementByName("6").Click();
            WPFCalc.FindElementByName("Back").Click();
            var gettxtafter = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            if (gettxtbefore == gettxtafter)
            {
                Console.WriteLine(" Reults Matched: {0} = {1}", gettxtbefore, gettxtafter);
            }
            else
            {
                Console.WriteLine(" Results UnMatched: {0} = {1}", gettxtbefore, gettxtafter);
            }

            WPFCalc.Close();
        }

        [TestMethod]
        public void Memory()
        {
            //Store the memery and recall 
            WPFCalc.FindElementByName("6").Click();
            WPFCalc.FindElementByName("+").Click();
            WPFCalc.FindElementByName("9").Click();
            WPFCalc.FindElementByName("=").Click();

            var BeforeMemory = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            WPFCalc.FindElementByName("MS").Click();
            Thread.Sleep(1000);
            //WPFCalc.FindElementByAccessibilityId("txtDisplay").Clear();
            WPFCalc.FindElementByName("C").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("MR").Click();
            Thread.Sleep(2000);
            var Memoryrecall = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            if (BeforeMemory == Memoryrecall)
            {
                Console.WriteLine("Memory recall Matched: {0} = {1}", BeforeMemory, Memoryrecall);
            }
            else
            {
                Console.WriteLine("Memory recall value unMatched; {0} = {1}", BeforeMemory, Memoryrecall);
            }

            // Clear the Memory
            WPFCalc.FindElementByName("MC").Click();
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("MR").Click();
            var MemoryClear = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            if (MemoryClear == Memoryrecall)
            {
                Console.WriteLine("Memory recall Matched after Memory clear (Fail): {0} = {1}", MemoryClear, Memoryrecall);
            }
            else
            {
                Console.WriteLine("Memory recall value unMatched after Memory clear (Pass): {0} = {1}", MemoryClear, Memoryrecall);
            }


            //Memory Add: M+ adds the currently displayed value to the value already stored in memory
            WPFCalc.FindElementByName("3").Click();
            WPFCalc.FindElementByName("+").Click();
            WPFCalc.FindElementByName("8").Click();
            WPFCalc.FindElementByName("=").Click();
            WPFCalc.FindElementByName("MS").Click(); // Save to Memory
            var saveMemory = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            Thread.Sleep(2000);
            WPFCalc.FindElementByName("6").Click();
            var add = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;
            WPFCalc.FindElementByName("M+").Click(); // Adding to existing Memory value
            WPFCalc.FindElementByName("=").Click();
            Thread.Sleep(2000);
            var addMemory = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            if (saveMemory == addMemory)
            {
                Console.WriteLine("Memory addtion unSuccessful: {0} = {1}", saveMemory, addMemory);
            }
            else
            {
                //Console.WriteLine("Memory additon is Successful ; {0} = {1}", saveMemory, addMemory);
                Console.WriteLine("Memory addition is successful; {0} + {1} = {2}", saveMemory, add, addMemory);
            }

            //Verify new value added to existing memory value
            WPFCalc.FindElementByName("C").Click();
            WPFCalc.FindElementByName("MR").Click();
            Thread.Sleep(2000);
            var recallMemory = WPFCalc.FindElementByAccessibilityId("txtDisplay").Text;

            if (recallMemory == addMemory)
            {
                Console.WriteLine("Memory recall is Successful: {0} = {1}", recallMemory, addMemory);

            }
            else
            {
                Console.WriteLine("Memory recall is unSuccessful ; {0} = {1}", recallMemory, addMemory);
            }

            WPFCalc.Close();

        }
    }
}
