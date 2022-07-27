using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VSG
{
    public class FPSManageScorecardTests
    {
        private WebDriver driver;
        private const string URL = "https://qafour.profitstarsfps.com/";

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test] 
        public void TestCase_1() //ErrorsCatching
        {
            driver.Navigate().GoToUrl(URL);
            string username = "testuser128";
            string password = "7$8,Qd;uBL";

            var usernameField = driver.FindElement(By.CssSelector("#signInName"));
            usernameField.SendKeys(username);
            var passwordField = driver.FindElement(By.CssSelector("#password"));
            passwordField.SendKeys(password);

            driver.FindElement(By.CssSelector("#next")).Click();

            driver.FindElement(By.CssSelector("" +
                "#pageHeader > div > div > div.hidden-sm.hidden-xs >" +
                " div > div > div > ul > li:nth-child(2) > a"))
                .Click();
            // need to find a better way
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > div:nth-child(2) >" +
                " div.px-margin-top-10.px-margin-bottom-15.ng-scope >" +
                " div:nth-child(1) > div:nth-child(1) > div > span > span > span"))
                .Click();

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-7 > div:nth-child(7) > div > div > span:nth-child(1) > span"))
                .Click();

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-6.col-md-push-6.px-padding-bottom-20.psi-overflow > div > span:nth-child(1) > button"))
                .Click();

            var errorName = driver.FindElement(By.CssSelector("#AddScorecardUserSelectionPanelSearchPanel"));
            var errorOrganization = driver.FindElement(By.CssSelector("#organization"));
            var errorYear = driver.FindElement(By.CssSelector("#year"));
            var errorSalary = driver.FindElement(By.CssSelector("#salary"));
            var errorOpportunity = driver.FindElement(By.CssSelector("#opportunity"));
            var errorCategory = driver.FindElement(By.CssSelector("#category-1 > div > div > div > div"));
            var errorWeight = driver.FindElement(By.CssSelector("#weight-1"));
            var errorBase = driver.FindElement(By.CssSelector("#base-1"));
            var errorThreshold = driver.FindElement(By.CssSelector("#threshold-1"));
            var errorObjective = driver.FindElement(By.CssSelector("#objective-1"));



            Assert.That(errorName.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorOrganization.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorYear.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorSalary.Text, Is.EqualTo("$\r\nThis is a required field."));
            Assert.That(errorOpportunity.Text, Is.EqualTo("%\r\n%\r\n%\r\nThis is a required field."));
            Assert.That(errorCategory.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorWeight.Text, Is.EqualTo("%\r\n%\r\n%\r\nThis is a required field."));
            Assert.That(errorBase.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorThreshold.Text, Is.EqualTo("This is a required field."));
            Assert.That(errorObjective.Text, Is.EqualTo("This is a required field."));

        }

        [Test]
        public void TestCase_2() //InvalidValue_Salary_Opportunity
        {
            driver.Navigate().GoToUrl(URL);
            string username = "testuser128";
            string password = "7$8,Qd;uBL";

            var usernameField = driver.FindElement(By.CssSelector("#signInName"));
            usernameField.SendKeys(username);
            var passwordField = driver.FindElement(By.CssSelector("#password"));
            passwordField.SendKeys(password);

            driver.FindElement(By.CssSelector("#next")).Click();

            driver.FindElement(By.CssSelector("" +
                "#pageHeader > div > div > div.hidden-sm.hidden-xs >" +
                " div > div > div > ul > li:nth-child(2) > a"))
                .Click();
            // need to find a better way
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > div:nth-child(2) >" +
                " div.px-margin-top-10.px-margin-bottom-15.ng-scope >" +
                " div:nth-child(1) > div:nth-child(1) > div > span > span"))
                .Click();

            
            var salaryField = driver.FindElement(By.CssSelector("#salaryInputField"));
            salaryField.SendKeys("-1");


            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-6.col-md-push-6.px-padding-bottom-20.psi-overflow > div > span:nth-child(1) > button"))
                .Click();

            var errorSalary = driver.FindElement(By.CssSelector("#salary"));

            Assert.That(errorSalary.Text, Is.EqualTo("$\r\nThe value must be between 0 and 999,999,999."));

            salaryField.Clear();
            salaryField.SendKeys("1000000000");

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-6.col-md-push-6.px-padding-bottom-20.psi-overflow > div > span:nth-child(1) > button"))
                .Click();

            errorSalary = driver.FindElement(By.CssSelector("#salary"));

            Assert.That(errorSalary.Text, Is.EqualTo("$\r\nThe value must be between 0 and 999,999,999."));

            var oppField = driver.FindElement(By.CssSelector("#opportunityInputField"));
            oppField.SendKeys("-1");

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-6.col-md-push-6.px-padding-bottom-20.psi-overflow > div > span:nth-child(1) > button"))
                .Click();

            var errorOpp = driver.FindElement(By.CssSelector("#opportunity"));

            Assert.That(errorOpp.Text, Is.EqualTo("%\r\n%\r\n%\r\nThe value must be between 0.00 and 200.00."));

            oppField.Clear();
            oppField.SendKeys("201");

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) >" +
                " div.col-md-6.col-md-push-6.px-padding-bottom-20.psi-overflow > div > span:nth-child(1) > button"))
                .Click();

            errorOpp = driver.FindElement(By.CssSelector("#opportunity"));

            Assert.That(errorOpp.Text, Is.EqualTo("%\r\n%\r\n%\r\nThe value must be between 0.00 and 200.00."));

        }

        [Test]
        public void TestCase_3() //CreateAndDeleteScoreCard
        {
            driver.Navigate().GoToUrl(URL);
            string username = "testuser128";
            string password = "7$8,Qd;uBL";

            var usernameField = driver.FindElement(By.CssSelector("#signInName"));
            usernameField.SendKeys(username);
            var passwordField = driver.FindElement(By.CssSelector("#password"));
            passwordField.SendKeys(password);

            driver.FindElement(By.CssSelector("#next")).Click();

            driver.FindElement(By.CssSelector("" +
                "#pageHeader > div > div > div.hidden-sm.hidden-xs >" +
                " div > div > div > ul > li:nth-child(2) > a"))
                .Click();
            // need to find a better way
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > div:nth-child(2) >" +
                " div.px-margin-top-10.px-margin-bottom-15.ng-scope >" +
                " div:nth-child(1) > div:nth-child(1) > div > span > span > span"))
                .Click();

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div.row.ng-isolate-scope >" +
                " div > div > div > div > div.col-xs-12.px-padding-vertical-10 > i"))
                .Click();

            driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form >" +
                " div:nth-child(2) > span > span"))
                .Click();

            var nameField = driver.FindElement(By.CssSelector("#AddScorecardUserSelectionPanelSearchPanelInputControl"));
            var organizationField = driver.FindElement(By.CssSelector("#organizationInputField"));
            var yearField = driver.FindElement(By.CssSelector("#yearInputField"));
            var salaryField = driver.FindElement(By.CssSelector("#salaryInputField"));
            var opportunityField = driver.FindElement(By.CssSelector("#opportunityInputField"));
            var categoryField = driver.FindElement(By.CssSelector("#category-2InputField"));

            nameField.Click();
            nameField.SendKeys("User");

            driver.FindElement(By.PartialLinkText("Test User")).Click();

            organizationField.SendKeys("Monett Branch");
            yearField.SendKeys("2022");
            salaryField.SendKeys("50000");
            opportunityField.SendKeys("15");
            categoryField.SendKeys("#");


            var weightField = driver.FindElement(By.CssSelector("#weight-2InputField"));
            var baseFieldField = driver.FindElement(By.CssSelector("#base-2InputField"));
            var thresholdField = driver.FindElement(By.CssSelector("#threshold-2InputField"));
            var objectiveField = driver.FindElement(By.CssSelector("#objective-2InputField"));

            weightField.SendKeys("100");
            baseFieldField.SendKeys("10000");
            thresholdField.SendKeys("25000");
            objectiveField.SendKeys("35000");

            driver.FindElement(By.TagName("body")).SendKeys(Keys.Home);
            // need to find a better way
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("span:nth-child(1) > button"))
               .Click();


            driver.FindElement(By.CssSelector("#scorecardsGridInner > div.k-grid-content.k-auto-scrollable >" +
                " table > tbody > tr > td:nth-child(5)"))
                .Click();

            opportunityField = driver.FindElement(By.CssSelector("#opportunityInputField"));
            opportunityField.Clear();
            opportunityField.SendKeys("20");
            // need to find a better way
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("span:nth-child(1) > button"))
               .Click();
            // should add some assertions 
            driver.FindElement(By.CssSelector("#scorecardsGridInner > div.k-grid-content.k-auto-scrollable >" +
                " table > tbody > tr > td:nth-child(4)"))
                .Click();

            driver.FindElement(By.CssSelector("body > div.modal.fade.ng-isolate-scope.in > div >" +
                " div > div.modal-footer.ng-scope > button.btn.btn-primary.ng-binding"))
                .Click();
        }
    }
}
