using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class CasesPage
    {
        IWebDriver driver;
        public CasesPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement FirstCaseFromList => driver.FindElement(By.XPath("//*[contains(@class, 'cases__button button--variant2')]"));
    }
}
