using ExerciseOmada.Locators;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    class Contact
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IWebDriver driver;
        private readonly string tag = DateTime.Now.Ticks.ToString();

        public Contact(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool TestCaseExec()
        {
            try
            {
                MainPage mainPage = new MainPage(driver);
                mainPage.CompanyContact.Click();
                TakeScreenShot("Contact.jpg");

                ContactPage contactPage = new ContactPage(driver);
                contactPage.USWest.Click();
                string className = contactPage.USWest.GetAttribute("outerHTML");
                Assert.IsTrue(className.Contains("tabmenu__menu-item selected"));
                TakeScreenShot("Contact.jpg");

                HoverMouse();
                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("error: {0}", ex);
                throw ex;
            }
        }
        private void TakeScreenShot(string fileName)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:/AndrzejCarykZadanieRekrutacyjne/" + tag + fileName);
        }
        private void HoverMouse()
        {
            ContactPage contactPage = new ContactPage(driver);
            try
            {
                Actions action = new Actions(driver);
                foreach (IWebElement item in contactPage.TabElements)
                {
                    TakeScreenShot("Before action " + item.Text + ".jpg");
                    action.MoveToElement(item).Build().Perform();
                    TakeScreenShot("After action " + item.Text + ".jpg");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("error in HoverMouse: {0}", ex);
                throw ex;
            }
        }
    }
}
