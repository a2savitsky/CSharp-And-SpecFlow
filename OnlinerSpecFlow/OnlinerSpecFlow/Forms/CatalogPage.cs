using System.Collections.Generic;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OnlinerSpecFlow.RandomUtils;

namespace OnlinerSpecFlow.Forms
{
    public class CatalogPage : Form
    {
        private IList<ILink> CategoryLinks => ElementFactory.FindElements<ILink>(By.CssSelector("li.catalog-bar__item"), state: ElementState.Displayed, expectedCount: ElementsCount.MoreThenZero);
        
        public CatalogPage() : base(By.XPath("//div[@class='catalog-bar-main']"), "Catalog page")
        {
        }
        
        public string GetNameOfRandomCategoryAndClick()
        {
            int indexRandCategory = DataGenerator.GetRandomNumber(CategoryLinks.Count - 1);
            string nameRandCategory = CategoryLinks[indexRandCategory].Text;
            CategoryLinks[indexRandCategory].ClickAndWait();
            return nameRandCategory;
        }
    }
}