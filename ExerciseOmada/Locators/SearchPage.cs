using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada.Locators
{
    class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> FoundElements => driver.FindElements(By.XPath("//*[@class='search-results__item']/a"));
        public By ElementOnPage => (By.XPath("//*[@class='search-results__item']/a"));
    }
}
