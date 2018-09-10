using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Global
{
    public static class Driver
    {
        //initialising driver
        public static IWebDriver driver { get; set; }
        //public static IJavaScriptExecutor Driver { get; internal set; }

        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion


        #region Element Present

        //Method to check the element is showing on screen
        public static bool isDialogPresent(IWebDriver driver, string Locator, string Lvalue)
        {
            try
            {
                if (Locator == "Id")
                    return driver.FindElement(By.Id(Lvalue)).Displayed && driver.FindElement(By.Id(Lvalue)).Enabled;
                else if (Locator == "XPath")
                    return driver.FindElement(By.XPath(Lvalue)).Displayed && driver.FindElement(By.XPath(Lvalue)).Enabled;
                else if (Locator == "CSS")
                    return driver.FindElement(By.CssSelector(Lvalue)).Displayed && driver.FindElement(By.CssSelector(Lvalue)).Enabled;
                else
                {
                    Console.WriteLine("Invalid Locator value");
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;

            }
        }
        public static bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #endregion

        #region Check for Alert Present
        //check for if alert present
        public static bool isDialogPresent(IWebDriver driver)
        {
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(driver);
            return (alert != null);
        }
        #endregion

        #region DynamicIWebELement

        public static void Textbox(IWebDriver driver, string Locator, string Lvalue, string InputValue)
        {
            if (Locator == "Id")
            {
                driver.FindElement(By.Id(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "XPath")
            {
                driver.FindElement(By.XPath(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "Name")
            {
                driver.FindElement(By.Name(Lvalue)).SendKeys(InputValue);
            }
            else if (Locator == "CSS")
            {
                driver.FindElement(By.CssSelector(Lvalue)).SendKeys(InputValue);
            }
            else
                Console.WriteLine("Invalid Locator value");

        }
        public static string GetTextValue(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
            {
                return driver.FindElement(By.Id(Lvalue)).Text;
            }
            else if (Locator == "XPath")
            {
                return driver.FindElement(By.XPath(Lvalue)).Text;
            }
            else if (Locator == "Name")
            {
                return driver.FindElement(By.Name(Lvalue)).Text;
            }
            else if (Locator == "CSS")
            {
                return driver.FindElement(By.CssSelector(Lvalue)).Text;
            }
            else
                Console.WriteLine("Invalid Locator value");
            return "";

        }

        public static void GetClear(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
            {
                driver.FindElement(By.Id(Lvalue)).Clear();
            }
            else if (Locator == "XPath")
            {
                driver.FindElement(By.XPath(Lvalue)).Clear();
            }
            else if (Locator == "Name")
            {
                driver.FindElement(By.Name(Lvalue)).Clear();
            }
            else if (Locator == "CSS")
            {
                driver.FindElement(By.CssSelector(Lvalue)).Clear();
            }
            else
                Console.WriteLine("Invalid Locator value");


        }

        public static void ActionButton(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(Lvalue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(Lvalue)).Click();
            else if (Locator == "Name")
                driver.FindElement(By.Name(Lvalue)).Click();
            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(Lvalue)).Click();
            else
                Console.WriteLine("Invalid Locator value");
        }



        public static void SelectDropDown(IWebDriver driver, string Locator, string Lvalue, IWebElement elementR, SelectElement SelectR, string excelVal)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(Lvalue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(Lvalue)).Click();
            else if (Locator == "Name")
                driver.FindElement(By.Name(Lvalue)).Click();
            else if (Locator == "CssSelector")
                driver.FindElement(By.CssSelector(Lvalue)).Click();
            else
                Console.WriteLine("Invalid Locator value");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(dr => dr.FindElement(By.XPath(Lvalue)).Displayed);

            elementR = driver.FindElement(By.XPath(Lvalue));
            elementR.Click();
            SelectR = new SelectElement(elementR);
            SelectR.SelectByText(excelVal);

        }

        public static void DropdownList(IWebDriver driver, string Locator, string Lvalue, string listValueElement, string selectValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(Lvalue)).Click();
            else if (Locator == "XPath")
                driver.FindElement(By.XPath(Lvalue)).Click();
            else if (Locator == "CssSelector")
                driver.FindElement(By.CssSelector(Lvalue)).Click();
            else
                Console.WriteLine("Invalid Locator value");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(dr => dr.FindElement(By.XPath(listValueElement)).Displayed);

            IList<IWebElement> listValue = driver.FindElements(By.XPath(listValueElement));

            for (int i = 0; i < listValue.Count; i++)
            {
                if (listValue[i].Text == selectValue)
                {
                    listValue[i].Click();
                    break;
                }
            }


        }



        #endregion
    }
}
