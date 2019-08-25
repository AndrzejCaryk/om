using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    class NewTab
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IWebDriver driver;
        public NewTab(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool TestCaseExec()
        {
            try
            {
                MainPage mainPage = new MainPage(driver);
                Actions actions = new Actions(driver);

                //classic way
                //actions.KeyDown(Keys.Control).KeyDown(Keys.LeftShift).Click(mainPage.PrivacyStatement).Build().Perform();

                //or funny way :)
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('target', '_blank'); arguments[0].click();", mainPage.PrivacyStatement);

                Thread.Sleep(1000); //this sleep is to allows browser to open new tab. 

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Assert.AreEqual("Omada | Privacy Statement", driver.Title);

                driver.SwitchTo().Window(driver.WindowHandles.First());
                mainPage.CookiebarButton.Click();

                Assert.AreEqual("understood", driver.Manage().Cookies.GetCookieNamed("cookie-notice").Value);
                driver.Navigate().Refresh();

                Assert.IsFalse(mainPage.CookiebarBrick.Displayed);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Close();
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
