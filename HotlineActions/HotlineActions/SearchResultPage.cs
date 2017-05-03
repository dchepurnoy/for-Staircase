using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotlineActions
{
    class SearchResultPage
    {
        //List<IWebElement> listOfItems;
        private const string ItemsBoxClassName = "gd-box";
        private const string SearchResultPageLabelXpath = "//div[contains(text(), 'Товары, в названии которых есть ваш запрос')]";
        private IWebDriver driver;

        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchResultPageLabel
        {
            get { return driver.FindElement(By.XPath(SearchResultPageLabelXpath)); }
        }

        public List<IWebElement> ListOfItems
        {
            get { return driver.FindElements(By.ClassName(ItemsBoxClassName)).ToList(); }
        }

        public SelectedItemPage OpenSelectedItem(int number)
        {
            var firstItem = ListOfItems[number].FindElements(By.TagName("a"))[2];
            firstItem.Click();
            return new SelectedItemPage(driver);
        }

        public bool CheckSearchResultPageLabelEnabled()
        {
            return SearchResultPageLabel.Enabled;
        }

        
    }
}
