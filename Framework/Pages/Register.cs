using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.Global.CommonMethods;


namespace Framework.Pages
{
    public class Register
    {
          internal Register()
          {
              PageFactory.InitElements(Driver.driver, this);
          
        }

          //Enter Firstname
          [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
          private IWebElement FirstName{ get; set; }

          //Enter Lastname
          [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
          private IWebElement LastName { get; set; }

          //Enter Username
          [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
          private IWebElement UserName { get; set; }

          //Enter Password
          [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
          private IWebElement Password { get; set; }


        public void UserRegistration()
        {

            ExcelLib.PopulateInCollection(Base.ExcelPath, "Register");

            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));

            //Enter Firstname
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(2, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(2, "InputValue"));


            //Enter Lastname
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(3, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(3, "InputValue"));

            //Enter Username
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(4, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"), ExcelLib.ReadData(4, "InputValue"));

            //Enter Password
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(5, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"), ExcelLib.ReadData(5, "InputValue"));

            //Click Register button
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(6, "LocatorValue")), 6);
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "LocatorValue"));

            //Full name of the user
            string fName = ExcelLib.ReadData(2, "InputValue") +" "+ ExcelLib.ReadData(3, "InputValue");
                               
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(7, "LocatorValue")), 6);
            string Actualmessage = Driver.driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text;
            string Expectedmsg = "Registration successful";
            if (Actualmessage.ToLower() == Expectedmsg.ToLower())
            {

                Login loginobj = new Login();
                loginobj.LoginSuccessfull();

                //validate first name
                loginobj.ValidateFirstName();

                //validate full name
                loginobj.ValidateFromNameList(fName);


               // Base.test.Log(LogStatus.Info, "Registration successful");
                Base.test.Log(LogStatus.Pass, "Registration successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Registration successful");
                //Adding screenshot in extendReport
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Registration");
                string screenShotPath = Global.CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Register");
               Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));   
                
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Registration is not successfull");
            }
        }

    }
}
