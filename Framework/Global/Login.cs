using Framework.Config;
using OpenQA.Selenium;
using System;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.Global.CommonMethods;

namespace Framework.Global
{
    class Login
    {
        public static int LoginBase = Int32.Parse(Resource.Login);

        public void LoginSuccessfull()
        {

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");

            // Navigating to Login page using value from Excel
            // Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(LoginBase, "Url"));

            // Sending the username 
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(2, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Username"));



            // Sending the password
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(3, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Password"));

            // Clicking on the login button
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(4, "LocatorValue")), 6);
            // Driver.GetClear(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));

          
        }

        public void ValidateFirstName()
        {
            try
            {
                              
                Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(5, "LocatorValue")), 6);
                string Actualmessage = Driver.driver.FindElement(By.XPath("//div[@class='col-md-6 col-md-offset-3']/h1")).Text;
                string Expectedmsg = "Hi " + ExcelLib.ReadData(LoginBase, "Username") + "!";

                if (Actualmessage.ToLower() == Expectedmsg.ToLower())
                {
                    Base.test.Log(LogStatus.Pass, "User first name is correctly displayed");

                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "User first name is not displayed");

                }
            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Error, "There is an error: " + e);
                Console.WriteLine("There is an error: " + e);

            }
        }

        public void ValidateFromNameList(string fullName)
        {
            try
            {
                Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(6, "LocatorValue")), 6);
                string Actualmessage = Driver.driver.FindElement(By.XPath("//*[@id='app']/div/div/div/div/div/ul/li")).Text;
               
                string Expectedmsg = fullName + " - Delete";
                               
                if (Actualmessage.ToLower() == Expectedmsg.ToLower())
                {
                    Base.test.Log(LogStatus.Pass, "User full name is displayed on the list");

                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "User full name is not displayed on the list");

                }
            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Error, "There is an error: " + e);
                Console.WriteLine("There is an error: " + e);

            }
        }

    }
}
