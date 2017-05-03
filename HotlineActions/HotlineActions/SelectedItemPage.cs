using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotlineActions
{
    class SelectedItemPage
    {
        private const string ViewIconXpathLocator = ".//span[contains(@class,'link-zoom')]";
        private const string AllPropositionsButtonXpathLocator = ".//*[contains(text(), 'Все предложения')]";
        private const string SortByPriceIconXpathLocator = ".//span[@class='sort-by-price']/a";
        private const string ShopListClassName = "price-line-shop";
        private const string ItemPriceID = "gotoshop-price";
        private const string GoToShopButtonXpath = ".//a[@id='gotoshop-price-button']";
        private const string ItemNameTagName = "h1";
        //List<IWebElement> shopList;
        private IWebDriver driver;

        public SelectedItemPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ViewIcon
        {
            get { return driver.FindElement(By.XPath(ViewIconXpathLocator)); }
        }

        public IWebElement AllPropositionsButton
        {
            get { return driver.FindElement(By.XPath(AllPropositionsButtonXpathLocator)); }
        }

        public IWebElement SortByPriceIcon
        {
            get { return driver.FindElement(By.XPath(SortByPriceIconXpathLocator)); }
        }

        public List<IWebElement> ShopList
        {
            get { return driver.FindElements(By.ClassName(ShopListClassName)).ToList(); }
        }

        public string ItemName
        {
            get { return driver.FindElement(By.TagName(ItemNameTagName)).Text; }
        }

        public PopupInnerContent OpenViews()
        {
            ViewIcon.Click();
            return new PopupInnerContent(driver); 
        }

        public void OpenAllPropositions()
        {
            AllPropositionsButton.Click();
        }

        public void ToSortByPrice()
        {
            SortByPriceIcon.Click();
        }

        public List<IWebElement> ItemPrice
        {
            get { return driver.FindElements(By.Id(ItemPriceID)).ToList(); }
        }

        // Method shows item price
        public void GetAllPrices()
        {
            int length = ShopList.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(ItemPrice[i].Text); 
            }
        }

        public Shop OpenMinPriceShop(int index)
        {
            var lowPriceShop = ShopList[index].FindElement(By.XPath(GoToShopButtonXpath));
            lowPriceShop.Click();
            return new Shop(driver);
        }
    }
}
