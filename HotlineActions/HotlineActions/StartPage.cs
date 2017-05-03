using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotlineActions
{
    class StartPage
    {
        public const string BaseUrlHotline = "http://hotline.ua";
        private const string SearchBoxId = "searchbox";
        private const string SearchButtonId = "doSearch";

        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchBox
        {
            get { return driver.FindElement(By.Id(SearchBoxId)); }
        }

        public IWebElement SearchButton
        {
            get { return driver.FindElement(By.Id(SearchButtonId)); }
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(BaseUrlHotline);
        }

        public SearchResultPage SearchItem(string value)
        {
            SearchBox.SendKeys(value);
            SearchButton.Click();
            return new SearchResultPage(driver);
        }
    }
}
