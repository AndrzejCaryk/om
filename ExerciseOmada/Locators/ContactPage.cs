using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class ContactPage
    {
        IWebDriver driver;
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement USWest => driver.FindElement(By.XPath("//*[contains(text(), 'U.S. West')]"));
        public ReadOnlyCollection<IWebElement> TabElements => driver.FindElements(By.XPath("//*[contains(@class, 'tabmenu__menu-item')]"));
    }
}
