using Framework.Config;
using Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.Global.CommonMethods;

namespace Framework.Global
{
    public abstract class Base
    {

        #region To access Path from resource file
        public static int Browser = Int32.Parse(Resource.Browser);
        public static String ExcelPath = Resource.ExcelPath;
        public static string ScreenshotPath = Resource.ScreenShotPath;
        public static string ReportPath = Resource.ReportPath;
        public static int LoginBase = Int32.Parse(Resource.Login);
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
           switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:

                    var options = new ChromeOptions();

                    options.AddArguments("--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    Driver.driver = new ChromeDriver(options);
                                      
                    break;

            }
                  
            extent = new ExtentReports(Resource.ReportPath, true, DisplayOrder.OldestFirst);
            extent.LoadConfig(Resource.ReportXMLPath);
           
        }

        #endregion
        #region Start teardown
        [TearDown]
        public void TearDown()
        {
            // Screenshot

            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
             extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
              extent.Flush();
            // Close the driver :)            
            Driver.driver.Close();
           Driver.driver.Dispose();
        }
        #endregion

    }
}


