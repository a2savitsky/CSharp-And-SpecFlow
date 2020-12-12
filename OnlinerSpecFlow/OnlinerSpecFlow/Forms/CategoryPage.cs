using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace OnlinerSpecFlow.Forms
{
    public class CategoryPage : Form
    {
        private ILabel CategoryLabel => ElementFactory.GetLabel(By.XPath("//*[@class='schema-header__title']"), "Category name label");

        public CategoryPage() : base(By.XPath("//h1[@class='schema-header__title']"), "Category page")
        {
        }
        
        public string GetNameOfCategory()
        {
            return CategoryLabel.Text;
        }
    }
}