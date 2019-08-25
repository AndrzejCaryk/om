using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    class PageLoad
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;

        public PageLoad(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool TestCaseExec()
        {
            try
            {
                Assert.AreEqual("Omada Home | Do More With Identity",
                                actual: driver.Title.Trim());

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                MainPage mainPage = new MainPage(driver);
                var footer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(mainPage.ByFooter));

                Assert.IsTrue(footer.Displayed);
                Assert.IsTrue(footer.Enabled);
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
