using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace OnlinerSpecFlow.Forms
{
    class LoginForm : Form
    {
        private ITextBox UserNameField => ElementFactory.GetTextBox(By.XPath("//div[@class='auth-form__field']//input[@type='text']"), "User_name_field");
        
        private ITextBox PasswordField => ElementFactory.GetTextBox(By.XPath("//input[@type='password']"), "Password_field");
        
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//div[@class='auth-form']//button[@type='submit']"), "Submit_button");
        
        public LoginForm() : base(By.XPath("//div[@class='auth-form']"), "Login_form")
        {
        }
        
        public void FillLoginFormAndClickSubmit(string userName, string password)
        {
            UserNameField.ClearAndType(userName);
            PasswordField.ClearAndType(password);
            SubmitButton.ClickAndWait();
        }
    }
}