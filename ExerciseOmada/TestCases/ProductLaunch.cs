using ExerciseOmada.Locators;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    class ProductLaunch
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IWebDriver driver;
        public ProductLaunch(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool TestCaseExec()
        {
            try
            {
                Actions action = new Actions(driver);

                MainPage mainPage = new MainPage(driver);
                action.MoveToElement(mainPage.MenuMore).Build().Perform();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(mainPage.PressRelease)).Click();

                new CasesPage(driver).FirstCaseFromList.Click();
                Assert.IsTrue(driver.Url.Contains("press-releases"));
                Assert.IsTrue(driver.PageSource.Length > 1000);

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("error: {0}", ex);
                throw ex;
            }

        }
    }
}
